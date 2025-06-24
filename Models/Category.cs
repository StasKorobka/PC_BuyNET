namespace PC_BuyNET.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = "Category";
        
        public List<Item> Items { get; set; } = new List<Item>();
    }
}
