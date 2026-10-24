namespace ConsoleApp21
{
    public delegate List<Product> filterlist(List<Product> products);
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public static List<Product> filteroption(List<Product> products, filterlist del)
        {
            List<Product> result = new List<Product>();

            result = del.Invoke(products);
            return result;
        }
        public static List<Product> Electronics(List<Product> products)
        {
            List<Product> result = new List<Product>();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Category == "Electronics")
                {
                    result.Add(products[i]);
                }
            }
            return result;
        }
        public static List<Product> prices(List<Product> products)
        {
            List<Product> result = new List<Product>();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Price < 50)
                {
                    result.Add(products[i]);
                }
            }
            return result;
        }
        public static List<Product> stock(List<Product> products)
        {
            List<Product> result = new List<Product>();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Stock > 0)
                {
                    result.Add(products[i]);
                }
            }
            return result;

        }
        public static List<Product> clothing(List<Product> products)
        {
            List<Product> result = new List<Product>();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Category == "Clothing" && products[i].Price < 100)
                {
                    result.Add(products[i]);
                }
            }
            return result;
        }
        public static void printreport(List<Product> products, Action<Product> action)
        {
            for (int i = 0; i < products.Count; i++)
            {
                action.Invoke(products[i]);
            }
        }
        public static void printshort(Product p)
        {
            Console.WriteLine($"category:{p.Category},,,,price:{p.Price}");
        }
        public static void printDetailed(Product p)
        {
            Console.WriteLine($"[{p.Category}],,{p.Name}|pric:{p.Price}|stock:{p.Stock}");
        }
    }
}
