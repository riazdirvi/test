namespace Core.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public CustomerType CustomerType { get; set; }
        public int CustomerTypeId { get; set; }
    }
}