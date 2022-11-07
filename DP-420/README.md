# AZ-420
- [DP-420 - Designing and Implementing Cloud-Native Applications Using Microsoft Azure Cosmos DB](https://learn.microsoft.com/en-us/certifications/exams/dp-420)

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

### Basic Hierachy
Account -> Database -> Containers -> Items

### Time-to-live
| DefaultTimeToLive | Item.ttl | Expiry |
| ----------------- | -------- | ------ |
| 1000              | null     | 1000   |
| 1000              | -1       | never  |
| 1000              | 2000     | 2000   |
| null              | null     | never  |
| null              | -1       | never  |
| null              | 2000     | never  |

## Labs
- [Create an Azure Cosmos DB Account](https://learn.microsoft.com/en-us/training/modules/try-azure-cosmos-db-sql-api/4-exercise-create-account)
- [Configure throughput for Azure Cosmos DB](https://learn.microsoft.com/en-us/training/modules/configure-azure-cosmos-db-sql-api/7-exercise-configure-throughput-for-azure-portal)