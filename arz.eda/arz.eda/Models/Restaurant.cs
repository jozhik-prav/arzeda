using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arz.eda.Models
{
    /// <summary>
    /// Ресторан
    /// </summary>
    public class Restaurant
    {
        /// <summary>
        /// Идентификатор ресторана
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();
        
        /// <summary>
        /// Имя 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Изображение
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Время работы
        /// </summary>
        public string TimeWork { get; set; }

        /// <summary>
        /// Категория, кухня
        /// </summary>
        public ICollection<Category> Categories { get; set; }

        /// <summary>
        /// Меню
        /// </summary>
        public ICollection<Product> Products { get; set; }

        /// <summary>
        /// Цена доставки
        /// </summary>
        public decimal DeliveryPrice { get; set; }

        /// <summary>
        /// Минимальная сумма заказа
        /// </summary>
        public decimal MinSum { get; set; }
    }
}
