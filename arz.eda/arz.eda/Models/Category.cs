﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace arz.eda.Models
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
