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
// "Bitter/MainForm.cs" was last cleaned by Rick on 2015/09/22 at 3:41 AM

namespace Bitter {

    using System;
    using System.Diagnostics.Eventing.Reader;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using API.v1._1;
    using Librainian.Persistence;
    using Librainian.Threading;

    public partial class MainForm : Form {

        public MainForm() {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click( Object sender, EventArgs e ) {
            this.Close();
        }

        private void loginToolStripMenuItem_Click( Object sender, EventArgs e ) {

            var accounts = new PersistTable<String, String>( Environment.SpecialFolder.LocalApplicationData, "Accounts" );

            if ( !accounts.Any() ) {
                accounts.Dispose();
                this.AskForNewKey();
            }

            accounts.Dispose();

            this.DisplayAccounts();
        }

        private void DisplayAccounts() {
            using ( var account = new PersistTable<String, String>( Environment.SpecialFolder.LocalApplicationData, "Accounts" ) ) {
                this.accountsToolStripMenuItem.DropDownItems.Clear();
                foreach ( var pair in account ) {
                    var item = this.accountsToolStripMenuItem.DropDownItems.Add( pair.Key );
                    item.Click += ( o, args ) => {
                        this.Login( pair.Key, pair.Value );
                    };
                }
            }

            this.accountsToolStripMenuItem.GetCurrentParent().Refresh();
        }

        private void addNewKeyToolStripMenuItem_Click( Object sender, EventArgs e ) {
            this.AskForNewKey();
        }

        private void AskForNewKey() {
            String apikey;
            String secret = null;

            var form = new AskForInput( "What is the account APIKey?" );
            switch ( form.ShowDialog( this ) ) {
                case DialogResult.OK:
                    apikey = form.Response;
                    break;
                case DialogResult.Cancel:
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            form = new AskForInput( "What is the account secret?" );
            switch ( form.ShowDialog( this ) ) {
                case DialogResult.None:
                    break;
                case DialogResult.OK:
                    secret = form.Response;
                    break;
                case DialogResult.Cancel:
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if ( String.IsNullOrWhiteSpace( apikey ) || String.IsNullOrWhiteSpace( secret ) ) {
                return;
            }

            using ( var accounts = new PersistTable<String, String>( Environment.SpecialFolder.LocalApplicationData, "Accounts" ) ) {
                accounts[ apikey ] = secret;
                accounts.Flush();
            }
        }

        private BittrexCommunicator BittrexCommunicator {
            get; set;
        }

        private void Login( String key, String secret ) {
            this.BittrexCommunicator = new BittrexCommunicator( "BTC", key, secret );
            this.DisplayWallets();
        }

        private async void DisplayWallets() {
            var wallets = await BittrexCommunicator.GetBalances();
            this.dataGridViewWallets.AutoGenerateColumns = true;
            this.dataGridViewWallets.DataSource = wallets;

            var column = this.dataGridViewWallets.Columns[ "Balance" ];
            if ( column != null ) {
                column.DefaultCellStyle.Format = "F8";
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            column = this.dataGridViewWallets.Columns[ "Available" ];
            if ( column != null ) {
                column.DefaultCellStyle.Format = "F8";
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            column = this.dataGridViewWallets.Columns[ "Pending" ];
            if ( column != null ) {
                column.DefaultCellStyle.Format = "F8";
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            column = this.dataGridViewWallets.Columns[ "CryptoAddress" ];
            if ( column != null ) {
                column.DefaultCellStyle.BackColor = Color.Aqua;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }


        }

        private async void MainForm_Shown( Object sender, EventArgs e ) {
            this.DisplayAccounts();
            await DisplayMarkets();
        }


        private async Task DisplayMarkets() {
            try {
                var markets = await BittrexCommunicator.GetMarkets();
                this.dataGridViewMarkets.AutoGenerateColumns = true;
                this.dataGridViewMarkets.DataSource = markets;

                var dataGridViewColumn = this.dataGridViewMarkets.Columns[ "MinTradeSize" ];
                if ( dataGridViewColumn != null ) {
                    dataGridViewColumn.DefaultCellStyle.Format = "F8";
                }

                var gridViewColumn = this.dataGridViewMarkets.Columns[ "IsActive" ];
                if ( gridViewColumn != null ) {
                    gridViewColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch ( Exception exception ) {
                exception.More();
            }
        }

    }

}
