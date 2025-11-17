namespace OOP_SAMPLE
{
    public class Product
    {
        private string name;
        private double price;
        private int quantity;

        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название товара не может быть пустым.");

                name = value;
            }
        }

        public double Price
        {
            get => price;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Цена не может быть отрицательной.");

                price = value;
            }
        }

        public int Quantity
        {
            get => quantity;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Количество не может быть отрицательным.");

                quantity = value;
            }
        }

        public double GetTotalCost()
        {
            return Price * Quantity;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Товар: {Name}");
            Console.WriteLine($"Цена: {Price}");
            Console.WriteLine($"Количество: {Quantity}");
            Console.WriteLine($"Общая стоимость: {GetTotalCost()}");
            Console.WriteLine();
        }
    }
}
