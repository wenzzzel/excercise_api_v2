namespace excercise_api_v2.Interfaces;

public interface ICosmosDbRepository
{
    Task<myItem> GetItemAsync(string id);
}