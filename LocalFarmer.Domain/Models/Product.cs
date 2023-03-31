﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LocalFarmer.Domain.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CountAll { get; set; }
        public string CountMinOne { get; set; }
        public string PrizeOne { get; set; }
    }
}
