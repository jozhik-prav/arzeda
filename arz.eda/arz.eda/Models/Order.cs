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
        public Guid ID = Guid.NewGuid();

        /// <summary>
        /// Дата заказа
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Дата доставки
        /// </summary>
        public DateTime DateDelivery { get; set; }

        /// <summary>
        /// Адрес доставки
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Подъезд
        /// </summary>
        public int Entrance { get; set; }

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
        public int Flat { get; set; }

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
        public Guid AccountID { get; set; }

        /// <summary>
        /// Идентификатор ресторана
        /// </summary>
        public Guid RestaurantID { get; set;}

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
        /// <summary>
        /// Идентификатор позиции
        /// </summary>
        public Guid ID = Guid.NewGuid();

        /// <summary>
        /// Продукт
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public int Quantity { get; set; }

    }
}
