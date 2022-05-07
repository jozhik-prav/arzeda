using System;

namespace arz.eda.InputModels
{
    public class ProductInputModel
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public string Image { get; set; } = "";
    }
}
