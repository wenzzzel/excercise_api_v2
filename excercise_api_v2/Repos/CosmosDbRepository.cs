using excercise_api_v2.Interfaces;
using Microsoft.Azure.Cosmos;

namespace excercise_api_v2.Repos;

public class CosmosDbRepository : ICosmosDbRepository
{
    private Container _container;
    public CosmosDbRepository(CosmosClient client)
    {
        _container = client.GetContainer("myTestDatabase", "myTestContainer");
    }

    public async Task<myItem> GetItemAsync(string id)
    {
        var result = _container.ReadItemAsync<myItem>(id, new PartitionKey(id));
        return await result;
    }
}
