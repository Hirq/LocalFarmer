﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalFarmer.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey(nameof(Farmhouse))]
        public int IdFarmhouse { get; set; }


        public Farmhouse Farmhouse { get; set; }
    }
}
