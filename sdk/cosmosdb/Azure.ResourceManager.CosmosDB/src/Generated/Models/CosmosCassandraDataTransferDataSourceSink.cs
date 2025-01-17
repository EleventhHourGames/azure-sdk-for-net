// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.CosmosDB.Models
{
    /// <summary> A CosmosDB Cassandra API data source/sink. </summary>
    public partial class CosmosCassandraDataTransferDataSourceSink : DataTransferDataSourceSink
    {
        /// <summary> Initializes a new instance of CosmosCassandraDataTransferDataSourceSink. </summary>
        /// <param name="keyspaceName"></param>
        /// <param name="tableName"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="keyspaceName"/> or <paramref name="tableName"/> is null. </exception>
        public CosmosCassandraDataTransferDataSourceSink(string keyspaceName, string tableName)
        {
            Argument.AssertNotNull(keyspaceName, nameof(keyspaceName));
            Argument.AssertNotNull(tableName, nameof(tableName));

            KeyspaceName = keyspaceName;
            TableName = tableName;
            Component = DataTransferComponent.CosmosDBCassandra;
        }

        /// <summary> Initializes a new instance of CosmosCassandraDataTransferDataSourceSink. </summary>
        /// <param name="component"></param>
        /// <param name="keyspaceName"></param>
        /// <param name="tableName"></param>
        internal CosmosCassandraDataTransferDataSourceSink(DataTransferComponent component, string keyspaceName, string tableName) : base(component)
        {
            KeyspaceName = keyspaceName;
            TableName = tableName;
            Component = component;
        }

        /// <summary> Gets or sets the keyspace name. </summary>
        public string KeyspaceName { get; set; }
        /// <summary> Gets or sets the table name. </summary>
        public string TableName { get; set; }
    }
}
