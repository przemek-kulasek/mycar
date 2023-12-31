﻿namespace Mycar.Application.Dtos;

public class CarHistoryDto
{
    public required CarDto Car { get; set; }
    public ICollection<OperationWithItemsDto>? Operations { get; set; }
}