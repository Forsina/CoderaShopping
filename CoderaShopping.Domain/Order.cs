using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderaShopping.Domain
{
    public class Order
    {
        private Guid _orderId;
        private double _totalAmount;
        private OrderStat _orderStatus;
        private DateTime _dateOfOrder;
        private DateTime _dateOfSending;
        private User _userId;
        private IList<OrderProduct> _orderProduct;

        public Order()
        {
            _orderProduct = new List<OrderProduct>();
        }

        public virtual Guid OrderId { get => _orderId; set => _orderId = value; }
        public virtual double TotalAmount { get => _totalAmount; set => _totalAmount = value; }
        public virtual OrderStat OrderStatus { get => _orderStatus; set => _orderStatus = value; }
        public virtual DateTime DateOfOrder { get => _dateOfOrder; set => _dateOfOrder = value; }
        public virtual DateTime DateOfSending { get => _dateOfSending; set => _dateOfSending = value; }
        public virtual User UserId { get => _userId; set => _userId = value; }
        public virtual IList<OrderProduct> OrderProduct { get => _orderProduct; set => _orderProduct = value; }
    }

    public enum OrderStat
    {
        Pending = 1,
        Send = 2,
        Returned = 3,
        Declined = 4
    };
}
