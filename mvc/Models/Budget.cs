namespace mvc.Models
{
    public class Budget
    {
        public string itemName { get; set; }
        // public string ListItems { get; set; } No longer using this.
        public decimal MaxBudget { get; set; }
        // public decimal ListBudget { get; set; }
        public decimal itemPrice { get; set; }
        // public decimal ListPrice { get; set; }

        public decimal totalBalance { get;}
    }
}