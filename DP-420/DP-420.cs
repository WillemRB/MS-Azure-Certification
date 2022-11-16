using Azure;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;

var connectionString = "connectionString";
var databaseId = "databaseId";
var containerId = "containerId";
var partitionKeyString = "partitionKey";
var throughPut = 400;

#region Connecting with CosmosDB

// Create CosmosClientOptions
CosmosClientOptions options = new()
{
    ConnectionMode = ConnectionMode.Direct, // Cache address
    ConsistencyLevel = ConsistencyLevel.Eventual
};

// Create a CosmosClient with connection string.
// Can also use endpoint and access key.
//
// Instances are thread safe and manage connections efficiently
CosmosClient cosmosClient = new(connectionString, options);

RequestOptions requestOptions = new()
{
    IfMatchEtag = "true",
};

// AccountProperties
var account = cosmosClient.ReadAccountAsync();

// Database and Container creation return a Response type which has an implicit
// operator to return the Database or Container reference.

// Connect to a database
Database cosmosDatabase = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
//cosmosClient.GetDatabase(databaseId)
//cosmosClient.CreateDatabaseAsync(databaseId)

// Get a container
Container container = await cosmosDatabase.CreateContainerIfNotExistsAsync(containerId, partitionKeyString, throughPut);
//cosmosClient.GetContainer(databaseId, containerId);
//cosmosDatabase.GetContainer(containerId);

#endregion

#region Items
// ttl: Time to Live
// _ts: timestamp of last modify
// _etag: Entity tag
Product product1 = new("id01", "product1", "category", 25);
Product product2 = new("id02", "product2", "category", 35);

var itemResponse = await container.CreateItemAsync<dynamic>(product1);

var itemId = "unique-id";
PartitionKey partitionKey = new("category");

dynamic item = await container.ReadItemAsync<dynamic>(itemId, partitionKey);

// Updating items
container.UpsertItemAsync(item);
// Deleting items
container.DeleteItemAsync(item, partitionKey);

#endregion

#region Transactional Batch

TransactionalBatch batch = container.CreateTransactionalBatch(partitionKey)
    .CreateItem<Product>(product1)
    .CreateItem<Product>(product2);

using TransactionalBatchResponse response = await batch.ExecuteAsync();

#endregion

#region Concurrency

var eTag = itemResponse.ETag;
var itemRequestOptions = new ItemRequestOptions { IfMatchEtag = eTag };

container.UpsertItemAsync(item, partitionKey, itemRequestOptions);

#endregion

#region Queries

// Simple query
QueryDefinition query = new("SELECT * FROM Products p");

using (var feedIterator = container.GetItemQueryIterator<Product>(query))
while (feedIterator.HasMoreResults)
{
    foreach (var p in await feedIterator.ReadNextAsync())
        Console.WriteLine($"{p.name}");
}

// Adding query parameters
QueryDefinition query2 = new("SELECT * FROM Products p WHERE p.price > @price");
query2.WithParameter("price", 30);

QueryRequestOptions queryOptions = new()
{
    MaxItemCount = 100,
};


#endregion

#region Additional Properties

// ApplicationRegions on client
CosmosClient client = new CosmosClientBuilder(connectionString)
    //.WithApplicationRegion(Regions.WestEurope)
    .WithApplicationPreferredRegions(new[] { Regions.WestEurope, Regions.NorwayEast })
    .Build();

// ConflictResolution on container
ContainerProperties containerProperties = new()
{
    // Default is LastWriterWins based on _ts
    ConflictResolutionPolicy = new ConflictResolutionPolicy
    {
        Mode = ConflictResolutionMode.LastWriterWins,
        ResolutionPath = "/metadata/sortableTimestamp"
    }
};

#endregion

#region Stored Procedures

//container.Scripts.CreateStoredProcedureAsync(...)

#endregion

public record Product(string id, string name, string categoryId, int price);