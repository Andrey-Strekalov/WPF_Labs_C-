using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;

namespace LogicTier
{
    public class ProductPosition
    {
        private Product _product;

        public ProductPosition(Product p)
        {
            _product = p;
        }
        public String CodeProduct
        {
            get { return _product.Code; }
            set { _product.Code = value; }
        }
        public String NameProduct
        {
            get { return _product.Name; }
            set { _product.Name = value; }
        }
        public float PriceProduct
        {
            get { return _product.Price; }
            set { _product.Price = value; }
        }
        public int CountProduct
        {
            get { return _product.Count; }
            set { _product.Count = value; }
        }
        public String DescriptionProduct
        {
            get { return _product.Description; }
            set { _product.Description = value; }
        }
        public float SummPriceOfProductPosition
        {
            get { return _product.Price * _product.Count; }
        }
        public String ProductPresentation
        {
            get { return _product.Code + " : " + _product.Name
                    + " (" + _product.Price.ToString("C") + ")"; }
        }
    }
}
