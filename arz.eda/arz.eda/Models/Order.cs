using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arz.eda.Models
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Дата и время заказа
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Дата и время доставки
        /// </summary>
        public DateTime DateDelivery { get; set; }

        /// <summary>
        /// Адрес доставки
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Подъезд
        /// </summary>
        public string Entrance { get; set; }

        /// <summary>
        /// Домофон
        /// </summary>
        public string Intercom { get; set; }

        /// <summary>
        /// Этаж
        /// </summary>
        public int Floor { get; set; }

        /// <summary>
        /// Квартира
        /// </summary>
        public string Flat { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        public decimal Price {  get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Идентификатор заказчика
        /// </summary>
        public Guid AccountId { get; set; }

        public Account Account { get; set; }

        /// <summary>
        /// Идентификатор ресторана
        /// </summary>
        public Guid RestaurantId { get; set;}

        public Restaurant Restaurant { get; set; }

        /// <summary>
        /// Позиции 
        /// </summary>
        public ICollection<OrderLine> OrderLines { get; set; }

    }

    /// <summary>
    /// Позиции
    /// </summary>
    public class OrderLine
    {
        public Guid ProductId { get; set; }
        /// <summary>
        /// Продукт
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public int Quantity { get; set; }

        public decimal Price { get; set; }

    }
}
