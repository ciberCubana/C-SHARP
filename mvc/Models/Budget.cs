namespace mvc.Models
{
    public class Budget
    {
       public int ID{get;set;}
        public string itemName { get; set; }
        // public string ListItems { get; set; } No longer using this.
        public string itemPrice { get; set; }
        // public decimal ListPrice { get; set; }

        public string totalBalance { get; set;}
    }
}