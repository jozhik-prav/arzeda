using System;
using System.Collections.Generic;

namespace arz.eda.InputModels
{
    public class RestaurantInputModel
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Image { get; set; } = "";
        public string Address { get; set; } = "";
        public List<Guid> Categories { get; set; } = new();
        public DateTime TimeWorkStart { get; set; }
        public DateTime TimeWorkEnd { get; set; }
        public decimal DeliveryPrice { get; set; }
        public decimal MinSum { get; set; }
    }
}
