namespace InfinBank.Domain.Common
{
    public class BaseAuditableEntity : BaseEntity
    {
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}