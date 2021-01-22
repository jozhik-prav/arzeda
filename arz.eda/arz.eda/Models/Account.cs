using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arz.eda.Models
{
    /// <summary>
    /// Клиент
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid ID = Guid.NewGuid();

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Изображение (аватар)
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Адрес
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
        /// Список заказов
        /// </summary>
        public ICollection<Order> Orders { get; set; }
    }
}
