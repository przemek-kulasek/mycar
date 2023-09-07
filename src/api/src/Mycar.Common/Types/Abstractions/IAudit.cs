namespace Mycar.Common.Types.Abstractions
{
    public interface IAudit
    {
        public Guid? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? LastModifiedUserId { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
