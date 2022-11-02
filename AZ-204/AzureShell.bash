az group list

az group list --query "[].{id:name}"
az group list --query "[].location"

az group list --output table

resourceGroup=$(az group list --query "[].{id:name}" -o tsv)
appName=az204app$RANDOM

# Deploy
az webapp up -g $resourceGroup -n $appName --html