using DataTier;

namespace LogicTier
{
    public class Shop
    {
        private List<ProductPosition> _products = new List<ProductPosition>();

        public Shop()
        {
            List<Product> tmp = AllProducts.GetAllProducts();
            foreach (var t in tmp)
            {
                _products.Add(new ProductPosition(t));
            }
        }

        public List<ProductPosition> ProductList
        {
            get {  return _products; }
        }

        public String NameOfShop
        {
            get { return "Наш магазин"; }
        }

        public float SummPrice
        {
            get
            {
                return _products.Sum(p=> p.SummPriceOfProductPosition);
            }
        }

        public float SummCount
        {
            get
            {
                return _products.Sum(p=>p.CountProduct);
            }
        }
    }

}






