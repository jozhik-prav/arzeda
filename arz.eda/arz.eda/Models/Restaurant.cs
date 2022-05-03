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
        /// Список менеджеров
        /// </summary>
        public List<Account> Managers { get; set; } = new List<Account>();
        
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
        /// Время начала работы
        /// </summary>
        public DateTime TimeWorkStart { get; set; }

        /// <summary>
        /// Время окончания работы
        /// </summary>
        public DateTime TimeWorkEnd { get; set; }

        /// <summary>
        /// Категория, кухня
        /// </summary>
        public List<Category> Categories { get; set; }

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
