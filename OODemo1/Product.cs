namespace OODemo1
{
    public class Product // Entity Classes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public int Price { get; set; }
        private int price;
        public int Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                    price = value;
                else
                    price = 0;
            }
        }
        public string Brand { get; set; }
    }
}
