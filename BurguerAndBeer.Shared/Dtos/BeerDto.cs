namespace BurguerAndBeer.Shared.Dtos
{
    public record BeerDto(int Id, string Name, string Image, string Description, double Price, int CategoryId) : IItemDto;
}
