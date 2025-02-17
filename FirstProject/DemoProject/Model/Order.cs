﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Model
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Users? User { get; set; }
        public Product? Product { get; set; }
        public int? quantity { get; set; }
        public decimal? Totalprice { get; set; }

    }
}
