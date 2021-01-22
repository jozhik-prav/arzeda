using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arz.eda.Models
{
    /// <summary>
    /// Продукт
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public Guid Id { get; set; }  = Guid.NewGuid();

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Изображение
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Идентификатор ресторана
        /// </summary>
        public Guid RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
