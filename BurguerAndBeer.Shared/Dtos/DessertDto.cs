namespace BurguerAndBeer.Shared.Dtos
{
    public record DessertDto(int Id, string Name, string Image, string Description, double Price, int CategoryId) : IItemDto;
}
