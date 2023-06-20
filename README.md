
# Microsserviços utilizando ASP.NET Core

Uma breve aplicação que contém dois serviços, onde o primeiro armazena um objeto no banco de dados não relacional Azure Cosmos DB e envia uma mensagem para uma fila do Azure Service Bus, e o segundo consome essa fila. 




## Instalação e configurações de ambiente

Para executar o projeto, é necessário ter instalado uma versão igual ou superior ao [.NET 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) . Após obter a versão correta, faça o clone do repositório para sua máquina.

```bash
git clone https://github.com/thiagoaure/application-cosmosdb-service-bus
```

Além disso, é necessário configurar seu "appsettings.Development.json" de cada um dos serviços de acordo com as conexões que vai obter. A primeira através da conta do seu banco não relacional, no caso, utilizado o [Cosmos DB](https://docs.microsoft.com/en-us/azure/cosmos-db/) , onde o link vai te mostrar passo a passo para criar sua conta e gerar a string de conexão. E o segundo, deve criar sua conta no [barramento de serviço azure](https://docs.microsoft.com/en-us/azure/service-bus/) para envios das mensagens e também obter sua outra string de conexão por lá. 

O appsettings do Register dever ficar como: 

```ruby
"ConnectionStrings": {
    "AccountEndpoint": "https://your-cosmos-nosql.documents.azure.com:000/",
    "AccountKey": "*************************************************************************************==",
    "BusConnectionString": "Endpoint=sb://your-bus-azure.servicebus.windows.net/;SharedAccessKeyName=*****************************************************************************************************************="
  }
```
Processer:
```ruby
"ConnectionStrings": {
    "BusConnectionString": "Endpoint=sb://your-bus-azure.servicebus.windows.net/;SharedAccessKeyName=*****************************************************************************************************************="
}
```

Após os ajustes, é hora de compilar e executar. 

## Run

Ao rodar o serviço do Register, você verá que está sendo utilizado o Swagger para visualização e consumo de API, principalmente para fazer requisições (POST e GET), mas também poderá ser feito da plataforma de testes de api de sua preferencia utilizando o localhost e a porta configurada no launchSettings.json., sendo assim para fazer a persistencia dos dados é utilizado a rota " api/customer ", onde são requisitados os seguintes campos: 

```ruby
{
    "name": "string",
    "email": "string",
    "document": "string",
    "country": "string",
    "uf": "string",
    "city": "string",
    "zipCode": "string",
    "addressNumber": "string",
    "street": "string",
    "district": "string"
}
```
Caso não ocorra nenhuma execção, é retornado o objeto com o seu id:

```ruby
{
  "id": "c916a549-a206-4bd8-a8db-08db712c5386",
  "name": "string",
  "email": "string",
  "address": {
    "country": "string",
    "uf": "string",
    "city": "string",
    "zipCode": "string",
    "addressNumber": "string",
    "street": "string",
    "district": "string"
  },
  "document": "string"
}
```
Quando é feita a persitencia dos dados, também é realizado o envio do json em forma de string para a fila do Service Bus onde será consumido pelo serviço Processer ao ser executado. Ao executar o segundo service, no console de saída dele, aparecerá todos registros enviado para a fila no seguinte formato:

```
Received: {"Name":"string","Email":"string","Document":"string","Country":"string","Uf":"string","City":"string","ZipCode":"string","AddressNumber":"string","Street":"string","District":"string"}
```
## Referência

 - [.NET com o Azure Cosmos DB](https://docs.microsoft.com/en-us/azure/cosmos-db/create-sql-api-dotnet)
 - [Azure Service Bus](https://docs.microsoft.com/en-us/azure/service-bus/)
 - [EF Core Azure Cosmos DB Provider](https://learn.microsoft.com/en-us/ef/core/providers/cosmos/?tabs=dotnet-core-cli)

