﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Favorite.Application.Models
{
    public class CreateFavoriteModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Path { get; set; }
    }
}
