#!/bin/bash
# Create a resource group
resourceGroupName="taskCanceled-dev-group"

az group create --name $resourceGroupName --location westus2

# Create a Service Bus messaging namespace with a unique name
namespaceName=taskCanceledNamespace$RANDOM
az servicebus namespace create --resource-group $resourceGroupName --name $namespaceName --location westus2

# Create a Service Bus queue
az servicebus queue create --resource-group $resourceGroupName --namespace-name $namespaceName --name TaskCanceledQueue

# Get the connection string for the namespace
connectionString=$(az servicebus namespace authorization-rule keys list --resource-group $resourceGroupName --namespace-name $namespaceName --name RootManageSharedAccessKey --query primaryConnectionString --output tsv)
echo $connectionString