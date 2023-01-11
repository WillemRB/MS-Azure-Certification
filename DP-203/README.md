# DP-203 ✔
- [DP-203: Data Engineering on Microsoft Azure](https://learn.microsoft.com/en-us/certifications/exams/dp-203)
- [Study Guide](https://query.prod.cms.rt.microsoft.com/cms/api/am/binary/RE4MbYT)
- [Training](https://github.com/DidaCloud/dp-203)

# Notes

## Azure Synapse

### Analytics Types
- **Descriptive**: What is happening?
- **Diagnostics**: Why is it happening?
- **Predictive**: What is likely to happen?
- **Prescriptive**: Actions based on real-time analysis

### Resource Models:
- **Serverless**: Ad-hoc workloads
- **Dedicated**: Predictable performance and cost
- **Pipelines**: Cloud based ETL

### Synapse Link
OLTP
OLAP - Column based

### Choose between slowly changing dimension types
[Types](https://learn.microsoft.com/en-us/training/modules/populate-slowly-changing-dimensions-azure-synapse-analytics-pipelines/3-choose-between-dimension-types)

A Type 1 SCD always reflects the latest values.
A Type 2 SCD supports versioning of dimension members.
A Type 3 SCD supports storing two versions of a dimension member as separate columns.
A Type 6 SCD combines Type 1, 2, and 3.

## Azure Databricks

DropWizard voor het loggen van Spark metrics

### Architectures
- Bronze, Silver, Gold
- Lambda
- Delta Lake

## Azure Datafactory
pipelines

Data factory koppelen aan Databrick notebook

## Data Storage

| Storage   | OData | Unstructured Data |
| --------- | ----- | ----------------- |
| CosmosDB  |   x   |         x         |
| Data Lake |   ?   |                   |
| Blob      |       |         x         |
| Table     |   x   |         x         |
| SQL       |   ?   |                   |

[Parquet](https://parquet.apache.org/)

[Avro](https://avro.apache.org/)

## Azure Stream Analytics
- [Windowing Function](https://learn.microsoft.com/en-us/azure/stream-analytics/stream-analytics-window-functions)

# Glossary
- **ADLS**: Azure Data Lake Storage
- **ETL**: Extract, Transform, Load
- **DDM**: Dynamic Data Masking
- **DMV**: Dynamic Management Views
- **DWU**: Data Warehouse Unit
