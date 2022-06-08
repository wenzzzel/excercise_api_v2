using excercise_api_v2.Interfaces;
using Microsoft.Azure.Cosmos;

namespace excercise_api_v2.Repos;

public class CosmosDbRepository : ICosmosDbRepository
{
    private Container _container;
    public CosmosDbRepository(CosmosClient client, string database, string container)
    {
        _container = client.GetContainer(database, container);
    }

    public async Task<myItem> GetItemAsync(string id)
    {
        var result = _container.ReadItemAsync<myItem>(id, new PartitionKey(id));
        return await result;
    }
}
