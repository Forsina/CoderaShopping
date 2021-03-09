using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CoderaShopping.Domain
{
    public class Product
    {
        private Guid _productId;
        private string _name;
        private string _description;
        private string _size;
        private string _color;
        private string _material;
        private string _brand;
        private string _suplier;
        private string _quantity;
        private double _price;
        private double _tax;
        private double _priceWithTax;
        private bool _discountAvailable;
        private double _discountPrice;
        private int _image;
        private Category _categoryId;
        private IList<OrderProduct> _orderProducts;

        public Product()
        {
            _orderProducts = new List<OrderProduct>();
        }

        public virtual Guid ProductId { get => _productId; set => _productId = value; }
        public virtual string Name { get => _name; set => _name = value; }
        public virtual string Description { get => _description; set => _description = value; }
        public virtual string Size { get => _size; set => _size = value; }
        public virtual string Color { get => _color; set => _color = value; }
        public virtual string Material { get => _material; set => _material = value; }
        public virtual string Brand { get => _brand; set => _brand = value; }
        public virtual string Suplier { get => _suplier; set => _suplier = value; }
        public virtual string Quantity { get => _quantity; set => _quantity = value; }
        public virtual double Price { get => _price; set => _price = value; }
        public virtual double Tax { get => _tax; set => _tax = value; }
        public virtual double PriceWithTax { get => _priceWithTax; set => _priceWithTax = value; }
        public virtual bool DiscountAvailable { get => _discountAvailable; set => _discountAvailable = value; }
        public virtual double DiscountPrice { get => _discountPrice; set => _discountPrice = value; }
        public virtual int Image { get => _image; set => _image = value; }
        public virtual Category CategoryId { get => _categoryId; set => _categoryId = value; }
        public virtual IList<OrderProduct> OrderProducts { get => _orderProducts; set => _orderProducts = value; }
    }
}
