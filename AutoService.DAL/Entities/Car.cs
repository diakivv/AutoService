﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AutoService.DAL.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public int? OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
