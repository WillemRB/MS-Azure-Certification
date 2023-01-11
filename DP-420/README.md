# DP-420 ✔
- [DP-420: Designing and Implementing Cloud-Native Applications Using Microsoft Azure Cosmos DB](https://learn.microsoft.com/en-us/certifications/exams/dp-420)
- [Study Guide](https://query.prod.cms.rt.microsoft.com/cms/api/am/binary/RWMvIJ)

## Notes
- [When should you use Cosmos DB](https://learn.microsoft.com/en-us/training/modules/introduction-to-azure-cosmos-db-sql-api/4-when-should-you-use)

### Compare serverless vs. provisioned throughput
| Compare       | provisioned                       | serverless                     |
| ------------- | --------------------------------- | ------------------------------ |
| Workload      | preditable                        | wildly varying traffic and low |
| RU            | some number of RU/s               | doesn’t require any planning   |
| Global dist.  | unlimited number of Azure regions | single Azure region            |
| storage limit | unlimited data                    | 50 GB                          |

You can provision throughput at either or both the database and container levels!

### Basic Hierachy
Account -> Database -> Containers -> Items

### Time-to-live
| DefaultTimeToLive | item.ttl | Expiry |
| ----------------- | -------- | ------ |
| 1000              | null     | 1000   |
| 1000              | -1       | never  |
| 1000              | 2000     | 2000   |
| null              | null     | never  |
| null              | -1       | never  |
| null              | 2000     | never  |

### [Consistency Levels](https://learn.microsoft.com/en-us/azure/cosmos-db/consistency-levels)
| Level             |        |
| ----------------- | ------ |
| Strong            |        |
| Bounded Staleness |        |
| Session           |        |
| Consistent Prefix |        |
| Eventual          |        |

### Private Link

### Querying
- [How to Query Container](https://learn.microsoft.com/en-us/azure/cosmos-db/nosql/how-to-query-container)
If the partition key is not specified in the query as one of the filter predicates, it is a cross-partition query. Otherwise it is considered an in-partition query.

### Calculate available RU
`Provisioned RU/s = C*T/R`

* *T*: Total vCores and/or vCPUs in your existing database **data-bearing** replica set(s). 
* *R*: Replication factor of your existing **data-bearing** replica set(s). If not known use 3.
* *C*: Recommended provisioned RU/s per vCore or vCPU. This value derives from the architecture of Azure Cosmos DB:
    * *C* = 600 RU/s/vCore* for Azure Cosmos DB for NoSQL
    * *C* = 1000 RU/s/vCore* for Azure Cosmos DB for MongoDB v4.0
    * *C* estimates for API for Cassandra, Gremlin, or other APIs are not currently available

### Status Codes
- **423**: Another scaling operation is in progress

## Links
- [Azure Cosmos DB Documentation](https://learn.microsoft.com/en-us/azure/cosmos-db/)
- [Partial document update](https://learn.microsoft.com/en-au/azure/cosmos-db/partial-document-update)
- [Migrate SDK v2 to v3](https://learn.microsoft.com/en-us/azure/cosmos-db/nosql/how-to-migrate-from-change-feed-library)
- [Index policy](https://learn.microsoft.com/en-us/azure/cosmos-db/index-policy)

## Labs
- [Create an Azure Cosmos DB Account](https://learn.microsoft.com/en-us/training/modules/try-azure-cosmos-db-sql-api/4-exercise-create-account)
- [Configure throughput for Azure Cosmos DB](https://learn.microsoft.com/en-us/training/modules/configure-azure-cosmos-db-sql-api/7-exercise-configure-throughput-for-azure-portal)

## Glossary
- **RU**: Request Units
- **TCO**: Total Cost of Ownership
- **UDF**: User Defined Function
