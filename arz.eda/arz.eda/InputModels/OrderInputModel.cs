using System;
using System.Collections.Generic;

namespace arz.eda.InputModels
{
    public class OrderInputModel
    {
        public DateTime Date { get; set; }
        public string Address { get; set; } = "";
        public string? Entrance { get; set; }
        public string? Intercom { get; set; }
        public int Floor { get; set; }
        public string? Flat { get; set; }
        public decimal Price { get; set; }
        public string Comment { get; set; } = "";
        public Guid RestaurantId { get; set; }
        public List<OrderLineInputModel> OrderLines { get; set; } = new List<OrderLineInputModel>();
    }

    public class OrderLineInputModel
    {
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
