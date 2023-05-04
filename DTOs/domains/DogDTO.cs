namespace DTOs.domains;

public class DogDTO
{
    public String message { get; set; }

    public DogDTO(String message)
    {
        this.message = message;
    }
}