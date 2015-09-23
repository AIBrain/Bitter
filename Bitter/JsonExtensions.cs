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
// "Bitter/JsonExtensions.cs" was last cleaned by Rick on 2015/09/23 at 12:09 AM

namespace Bitter {

    using System;
    using System.Collections.Generic;
    using System.Data;
    using JetBrains.Annotations;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public static class JsonExtensions {

        /// <summary>
        /// Converts JSON that is not nested into a DataTable.
        /// Typically this would be JSON that represents the contents of a table that is not nested.
        /// </summary>
        /// <param name="json"></param>
        /// <param name="tableName"></param>
        [NotNull]
        public static DataTable ToDataTable( this String json, String tableName ) {
            var dataset = JsonConvert.DeserializeObject< DataSet >( json );
            return dataset.Tables.Contains( tableName ) ? dataset.Tables[ tableName ] : new DataTable( tableName );
        }

        public static List< TKey > ToList< TKey >( this JArray jArray ) {
            return jArray.ToObject< List< TKey > >();
        }

    }

}
