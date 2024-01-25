namespace OODemo3
{
    public class Company
    {
        //Customer[] customer = new Customer[100]; // HAS-A - Association
        List<Customer> customers = new List<Customer>();

        // Fields - Properties
        DiscountCalculator calculator = new DiscountCalculator(); // HAS-A

        public int GetDiscount()
        {
            // Local Variables
            DiscountCalculator calculator = new DiscountCalculator(); // USES
            return calculator.CalculateDiscount();
        }

        public void PrintBill()
        {

        }

    }
}