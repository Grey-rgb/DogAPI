using DTOs.domains;

namespace HttpClients.clientInterfaces;

public interface IDogService
{
    Task<DogDTO> getRandomDogAsync();
}