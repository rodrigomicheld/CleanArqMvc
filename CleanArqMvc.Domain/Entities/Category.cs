using CleanArqMvc.Domain.Common;

namespace CleanArqMvc.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public int Code { get; set; }
        public string Name { get; set; }
    }
}
