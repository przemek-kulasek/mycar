using Mycar.Common.Types.Abstractions;

namespace Mycar.Common.Types
{
    public abstract class BaseEntity : IIdentity, ISoftDelete, IAudit
    {
        private BaseEntity()
        {
            //EF Required
        }

        protected BaseEntity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? LastModifiedUserId { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
