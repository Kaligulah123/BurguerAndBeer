namespace BurguerAndBeer.Shared.Dtos
{
    public record ChipsDto(int Id, string Name, string Image, string Description, double Price, int CategoryId) : IItemDto;
}
