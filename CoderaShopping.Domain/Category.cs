using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderaShopping.Domain
{
    public class Category
    {
        private Guid _categoryId;
        private string _name;
        private bool _isDefault; //true is default on view listing and false is not
        private bool _status;   //where true is active category and false is not active
        private IList<Product> _products;

        public Category()
        {
            _products = new List<Product>();
        }

        public virtual Guid CategoryId { get => _categoryId; set => _categoryId = value; }
        public virtual string Name { get => _name; set => _name = value; }
        public virtual bool IsDefault { get => _isDefault; set => _isDefault = value; }
        public virtual bool Status { get => _status; set => _status = value; }
        public virtual IList<Product> Products { get => _products; set => _products = value; }
    }
}