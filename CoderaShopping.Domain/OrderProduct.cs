using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderaShopping.Domain
{
    public class OrderProduct
    {
        private Guid _orderProductId;
        private int _quantity;
        private DateTime _dateOfProductOrder;
        private Order _order;
        private Product _product;

        //private IList<Product> _products;

        public OrderProduct()
        {
            //_products = new List<Product>();
        }

        public virtual Guid Id { get => _orderProductId; set => _orderProductId = value; }
        public virtual int Quantity { get => _quantity; set => _quantity = value; }
        public virtual DateTime DateOfProductOrder { get => _dateOfProductOrder; set => _dateOfProductOrder = value; }
        public virtual Order Order { get => _order; set => _order = value; }
        public virtual Product Product { get => _product; set => _product = value; }

        //public virtual IList<Product> Products { get => _products; set => _products = value; }
    }
}