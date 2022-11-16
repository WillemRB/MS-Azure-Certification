# Account Level
az cosmosdb create --name '<account-name>' --resource-group '<resource-group>' `
    --default-consistency-level 'Eventual' `
    --locations regionName='westeu'

# Database Level
az cosmosdb sql create --name '<database-name>' --account-name '<account-name>' --resource-group '<resource-group>' `
    --account-name '<account-name>' `
    --throughput 400 `
    --partition-key-path '<partition-key-path>' `
    # indexing policy
    -idx './policy.json' # Or Raw JSON

az cosmosdb sql throughput migrate `
  --throughput-type 'autoscale'/'manual' `
  --max-throughput 5000

