namespace Mycar.Common.Types.Abstractions;

public interface ISoftDelete
{
    public bool IsDeleted { get; set; }
}