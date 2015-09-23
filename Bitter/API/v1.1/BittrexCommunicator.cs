// Copyright 2015 Rick@AIBrain.org.
// 
// This notice must be kept visible in the source.
// 
// This section of source code belongs to Rick@AIBrain.Org unless otherwise specified, or the original license has been overwritten by the automatic formatting of this code.
// Any unmodified sections of source code borrowed from other projects retain their original license and thanks goes to the Authors.
// 
// Donations and royalties can be paid via
// PayPal: paypal@aibrain.org
// bitcoin: 1Mad8TxTqxKnMiHuZxArFvX8BuFEB9nqX2
// litecoin: LeUxdU2w3o6pLZGVys5xpDZvvo8DUrjBp9
// 
// Usage of the source code or compiled binaries is AS-IS.I am not responsible for Anything You Do.
// 
// Contact me by email if you have any questions or helpful criticism.
//  
// "Bitter/BittrexCommunicator.cs" was last cleaned by Rick on 2015/09/22 at 11:35 PM

namespace Bitter.API.v1._1 {

    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using Librainian.Maths;
    using Librainian.Measurement.Currency;
    using Librainian.Measurement.Time;
    using Librainian.Threading;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class BittrexCommunicator {

        private class ResponseResultClass {

            public Boolean success {
                get; set;
            }

            public String message {
                get; set;
            }

            public JArray result {
                get; set;
            }

        }

        private readonly String _apiKey;

        private readonly String _secret;

        private String _market;

        public BittrexCommunicator( String market, String apiKey, String secret ) {
            this._market = market;
            this._apiKey = apiKey;
            this._secret = secret;
        }

        public const String ApiVersion = "v1.1";

        /// <summary>
        ///     <para>"To be nice"</para>
        /// </summary>
        /// <see cref="http://www.cex.io/api"></see>
        public static readonly TimeSpan TimeBetweenRequests = new Seconds( 0.5m );

        private static readonly String ApiUrl = $"https://bittrex.com/api/{ApiVersion}/";

        /// <summary>
        /// Call this before each request.
        /// </summary>
        /// <returns></returns>
        public static async Task Throttle() {
            await Task.Delay( TimeBetweenRequests );
        }

        public void SetMarket( String market ) {
            this._market = market;
        }

        public static async Task<JArray> GetMarkets() {
            return await GetArrayResponse( $"{ApiUrl}public/getmarkets" );
        }

        public static async Task<JArray> GetCurrencies() {
            return await GetArrayResponse( $"{ApiUrl}public/getcurrencies" );
        }

        public async Task<JToken> GetTicker() {
            return await GetObjectResponse( $"{ApiUrl}public/getticker?market={this._market}", false );
        }

        public static Task<JArray> GetMarketSummaries() {
            return GetArrayResponse( $"{ApiUrl}public/getmarketsummaries" );
        }

        public async Task<JArray> GetMarketSummary() {
            var response = await this.GetArrayResponse( $"{ApiUrl}public/getmarketsummary?market={this._market}", false );

            return response == null || !response.Any() ? null : response;
        }

        public async Task<JToken> GetOrderBook( Int32 depth ) {
            return await GetObjectResponse( $"{ApiUrl}public/getorderbook?market={this._market}&type=both&depth={depth}", false );
        }

        public async Task<JArray> GetMarketHistory( Int32 count ) {
            return await GetArrayResponse( $"{ApiUrl}public/getmarkethistory?market={this._market}&count={count}", false );
        }

        public async Task<Guid> PlaceBuyOrder( Decimal quantity, Decimal rate ) {
            var result = await GetObjectResponse( $"{ApiUrl}market/buylimit?apikey={this._apiKey}&market={this._market}&quantity={quantity.Formatted()}&rate={rate.Formatted()}", true );
            return ( result?[ "uuid" ] == null ) ? Guid.Empty : new Guid( result[ "uuid" ].ToString() );
        }

        public async Task<Guid> PlaceSellOrder( Decimal quantity, Decimal rate ) {
            var result = await GetObjectResponse( $"{ApiUrl}market/selllimit?apikey={this._apiKey}&market={this._market}&quantity={quantity.Formatted()}&rate={rate.Formatted()}", true );
            return ( result?[ "uuid" ] == null ) ? Guid.Empty : new Guid( result[ "uuid" ].ToString() );
        }

        public async Task<Boolean> CancelOrder( Guid uuid ) {
            try {
                var jToken = await GetObjectResponse( $"{ApiUrl}market/cancel?" + $"apikey={this._apiKey}&uuid={uuid}", true );

                Boolean success;
                if ( Boolean.TryParse( jToken[ "success" ].ToString(), out success ) ) {
                    return true;
                }
            }
            catch ( Exception exception ) {
                exception.More();
            }
            return false;
        }

        public async Task<JArray> GetOpenOrders() {
            return await GetArrayResponse( $"{ApiUrl}market/getopenorders?apikey={this._apiKey}&market={this._market}", true );
        }

        public async Task<JArray> GetAllOpenOrders() {
            return await GetArrayResponse( $"{ApiUrl}market/getopenorders?apikey={this._apiKey}", true );
        }

        public async Task<JArray> GetBalances() {
            return await GetArrayResponse( $"{ApiUrl}account/getbalances?apikey={this._apiKey}", true );
        }

        public async Task<JToken> GetBalance( String currency ) {
            if ( currency == null ) {
                throw new ArgumentNullException( nameof( currency ) );
            }
            return await GetObjectResponse( $"{ApiUrl}account/getbalance?apikey={this._apiKey}&currency={currency}", true );
        }

        public async Task<String> GetDepositAddress( String currency ) {
            if ( currency == null ) {
                throw new ArgumentNullException( nameof( currency ) );
            }
            var response = await GetObjectResponse( $"{ApiUrl}account/getdepositaddress?apikey={this._apiKey}&currency={currency}", true );

            return response?[ "Address" ]?.ToString();
        }

        public async Task<String> Withdraw( String currency, Decimal quantity, String address ) {
            if ( currency == null ) {
                throw new ArgumentNullException( nameof( currency ) );
            }
            if ( address == null ) {
                throw new ArgumentNullException( nameof( address ) );
            }
            var result = await GetObjectResponse( $"{ApiUrl}account/withdraw?apikey={this._apiKey}&currency={currency}&quantity={quantity.Formatted()}&address={address}", true );

            return result?[ "uuid" ]?.ToString();
        }

        public async Task<JToken> GetOrder( String uuid ) {
            if ( uuid == null ) {
                throw new ArgumentNullException( nameof( uuid ) );
            }
            return await GetObjectResponse( $"{ApiUrl}account/getorder?apikey={this._apiKey}&uuid={uuid}", true );
        }

        public async Task<JArray> GetOrderHistory() {
            return await GetArrayResponse( $"{ApiUrl}account/getorderhistory?apikey={this._apiKey}", true );
        }

        public async Task<JArray> GetOrderHistory( String market ) {
            if ( market == null ) {
                throw new ArgumentNullException( nameof( market ) );
            }
            return await GetArrayResponse( $"{ApiUrl}account/getorderhistory?apikey={this._apiKey}&market={market}", true );
        }

        public async Task<JArray> GetOrderHistory( Int32 count ) {
            return await GetArrayResponse( $"{ApiUrl}account/getorderhistory?apikey={this._apiKey}&count={count}", true );
        }

        public async Task<JArray> GetOrderHistory( String market, Int32 count ) {
            if ( market == null ) {
                throw new ArgumentNullException( nameof( market ) );
            }
            return await GetArrayResponse( $"{ApiUrl}account/getorderhistory?apikey={this._apiKey}&market={market}&count={count}", true );
        }

        public async Task<JArray> GetWithdrawalHistory() {
            return await GetArrayResponse( $"{ApiUrl}account/getwithdrawalhistory?apikey={this._apiKey}", true );
        }

        public async Task<JArray> GetWithdrawalHistory( String currency ) {
            return await GetArrayResponse( $"{ApiUrl}account/getwithdrawalhistory?apikey={this._apiKey}&currency={currency}", true );
        }

        public async Task<JArray> GetWithdrawalHistory( Int32 count ) {
            return await GetArrayResponse( $"{ApiUrl}account/getwithdrawalhistory?apikey={this._apiKey}&count={count}", true );
        }

        public async Task<JArray> GetWithdrawalHistory( String currency, Int32 count ) {
            return await GetArrayResponse( $"{ApiUrl}account/getwithdrawalhistory?apikey={this._apiKey}&currency={currency}&count={count}", true );
        }

        public async Task<JArray> GetDepositHistory() {
            return await GetArrayResponse( $"{ApiUrl}account/getdeposithistory?apikey={this._apiKey}", true );
        }

        public async Task<JArray> GetDepositHistory( String currency ) {
            if ( currency == null ) {
                throw new ArgumentNullException( nameof( currency ) );
            }
            return await GetArrayResponse( $"{ApiUrl}account/getdeposithistory?apikey={this._apiKey}&currency={currency}", true );
        }

        public async Task<JArray> GetDepositHistory( Int32 count ) {
            return await GetArrayResponse( $"{ApiUrl}account/getdeposithistory?apikey={this._apiKey}&count={count}", true );
        }

        public async Task<JArray> GetDepositHistory( String currency, Int32 count ) {
            if ( currency == null ) {
                throw new ArgumentNullException( nameof( currency ) );
            }
            return await GetArrayResponse( $"{ApiUrl}account/getdeposithistory?apikey={this._apiKey}&currency={currency}&count={count}", true );
        }

        private async Task<HttpResponseMessage> GetResponse( String url, Boolean authenticated ) {
            try {
                //var uri = new Uri( url + ( authenticated ? ( url.Contains( "?" ) ? "&nonce=" : "?nonce=" ) + DateTime.UtcNow.Ticks : String.Empty ) );
                var nonce = String.Empty;
                if ( authenticated ) {
                    nonce = "&nonce=" + DateTime.UtcNow.Ticks;
                }
                var uri = new Uri( url + nonce );

                var con = new HttpClient();

                var requestMessage = new HttpRequestMessage( HttpMethod.Get, uri );
                requestMessage.Headers.Add( "User-Agent", $"Bitter {ApiVersion}" );
                if ( authenticated ) {
                    requestMessage.Headers.Add( "apisign", HmacDigest( uri.ToString(), this._secret ) );
                }

                if ( authenticated ) {
                    await Throttle();
                }

                return await con.SendAsync( requestMessage );
            }
            catch ( Exception exception ) {
                exception.More();
                return null;
            }
        }

        private static async Task<HttpResponseMessage> GetResponse( String url ) {
            try {
                var uri = new Uri( url );

                var con = new HttpClient();

                var requestMessage = new HttpRequestMessage( HttpMethod.Get, uri );
                requestMessage.Headers.Add( "User-Agent", $"Bitter {ApiVersion}" );

                return await con.SendAsync( requestMessage );
            }
            catch ( Exception exception ) {
                exception.More();
                return null;
            }
        }

        private async Task<JToken> GetObjectResponse( String url, Boolean authenticated ) {
            try {
                var httpResponseMessage = await GetResponse( url, authenticated );

                var value = await httpResponseMessage.Content.ReadAsStringAsync();

                var jObject = JsonConvert.DeserializeObject<JObject>( value );

                Boolean success;
                if ( Boolean.TryParse( jObject[ "success" ].ToString(), out success ) ) {
                    return jObject[ "result" ];
                }
            }
            catch ( Exception exception ) {
                exception.More();
            }
            return null;
        }

        private static async Task<JToken> GetObjectResponse( String url ) {
            try {
                var httpResponseMessage = await GetResponse( url );

                var value = await httpResponseMessage.Content.ReadAsStringAsync();

                var jObject = JsonConvert.DeserializeObject<JObject>( value );

                Boolean success;
                if ( Boolean.TryParse( jObject[ "success" ].ToString(), out success ) ) {
                    return jObject[ "result" ];
                }
            }
            catch ( Exception exception ) {
                exception.More();
            }
            return null;
        }

        private async Task<JArray> GetArrayResponse( String url, Boolean authenticated ) {
            try {
                var httpResponseMessage = await GetResponse( url, authenticated );

                if ( !httpResponseMessage.IsSuccessStatusCode ) {
                    return new JArray();
                }

                var value = await httpResponseMessage.Content.ReadAsStringAsync();

                var resultClass = JsonConvert.DeserializeObject<ResponseResultClass>( value );

                if ( resultClass.success ) {
                    return resultClass.result;
                }
            }
            catch ( Exception exception ) {
                exception.More();
            }
            return new JArray();
        }

        private static async Task<JArray> GetArrayResponse( String url ) {
            try {
                var httpResponseMessage = await GetResponse( url );

                if ( !httpResponseMessage.IsSuccessStatusCode ) {
                    return new JArray();
                }

                var value = await httpResponseMessage.Content.ReadAsStringAsync();

                var resultClass = JsonConvert.DeserializeObject<ResponseResultClass>( value );

                if ( resultClass.success ) {
                    return resultClass.result;
                }
            }
            catch ( Exception exception ) {
                exception.More();
            }
            return new JArray();
        }

        private static String HmacDigest( String message, String key ) {
            try {
                var hmacsha512 = new HMACSHA512( key: Encoding.UTF8.GetBytes( key ) );
                var hash = hmacsha512.ComputeHash( buffer: Encoding.ASCII.GetBytes( message ) );
                return hash.ToHex();
            }
            catch ( Exception exception ) {
                exception.More();
            }
            return String.Empty;
        }

    }

}
