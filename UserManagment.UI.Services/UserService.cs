using System.Net.Http.Json;
using UserManagment.UI.Services.Contracts;
using UserManagment.UserApi.Models;

namespace UserManagment.UI.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;
    private const string _baseUri = "/api/users";

    public UserService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("AdminApi");
    }

    public async Task<UserEntity> AddUserAsync(UserEntity entity)
    {
        var response = await _httpClient.PostAsJsonAsync(_baseUri, entity);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<UserEntity>())!;
    }

    public async Task DeleteUserAsync(UserEntity entity)
    {
        var deleteUri = $"{_baseUri}/{entity.Id}";
        var response = await _httpClient.DeleteAsync(deleteUri);
        response.EnsureSuccessStatusCode();
    }

    public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<UserEntity>>(_baseUri) ?? Array.Empty<UserEntity>();
    }

    public async Task UpdateUserAsync(UserEntity entity)
    {
        var updateUri = $"{_baseUri}/{entity.Id}";
        var response = await _httpClient.PutAsJsonAsync(updateUri, entity);
        response.EnsureSuccessStatusCode();
    }
}