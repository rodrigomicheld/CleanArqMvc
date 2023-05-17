using CleanArqMvc.Domain.Common;

namespace CleanArqMvc.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public Category Category { get; set; }
    }
}
