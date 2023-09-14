namespace Mycar.Application.Dtos
{
    public class OperationWithItemsDto : OperationDto
    {
        public ICollection<ItemDto>? Items { get; set; }
    }
}
