using System.Text.Json;
using DTOs.domains;
using HttpClients.clientInterfaces;

namespace HttpClients.implementations;

public class DogServiceImpl : IDogService
{
    private readonly HttpClient client;

    public DogServiceImpl(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<DogDTO> getRandomDogAsync()
    {
        HttpResponseMessage response = await client.GetAsync("https://dog.ceo/api/breeds/image/random");
        String content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Could not successfully access DogAPI");
        }

        DogDTO dog = JsonSerializer.Deserialize<DogDTO>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return dog;
    }
}