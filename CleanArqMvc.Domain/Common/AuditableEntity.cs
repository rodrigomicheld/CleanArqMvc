using System;

namespace CleanArqMvc.Domain.Common
{
    public class AuditableEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public bool Deleted { get; set; }

        protected AuditableEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}