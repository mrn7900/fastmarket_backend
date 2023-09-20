using System;
using System.Collections.Generic;

#nullable disable

namespace fastmarket_backend.DataProvide
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int? Price { get; set; }
    }
}
