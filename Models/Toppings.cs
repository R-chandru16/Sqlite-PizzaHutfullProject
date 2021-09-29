﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models
{
    public class Toppings
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
      
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
