﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockAppWebAPI11.Models
{
    [Table("watchlists")]
    public class WatchList
    {
        [Key]
        [ForeignKey("User")]
        [Column("user_id")]
        public int? UserId { get; set; }

        public User? User { get; set; }

        [Key]
        [ForeignKey("Stock")]
        [Column("stock_id")]
        public int? StockId { get; set; }

        public Stock? Stock { get; set; }
    }
}
