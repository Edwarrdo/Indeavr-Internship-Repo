namespace Problem8.Models
{
    public class Customer
    {
        public CustomerType Type { get; set; }
        public string Name { get; set; }

        public Customer(CustomerType type, string name)
        {
            this.Type = type;
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
