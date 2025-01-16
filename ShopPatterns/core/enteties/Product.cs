namespace ShopPatterns.core.enteties
{
    public interface IPrototype
    {
        IPrototype Clone();
    }

    public abstract class Prototype : IPrototype
    {
        public abstract IPrototype Clone();
    }


    public class Product : Prototype
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public override Prototype Clone() // Prototype
        {
            return (Product)this.MemberwiseClone();
        }

        public override string ToString() // __str__
        {
            return $"ID: {Id}, Name: {Name}, Price: {Price}";
        }
    }
}
