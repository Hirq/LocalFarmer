using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static LocalFarmer.Domain.Models.MyType;

namespace LocalFarmer.Domain.Models
{
    [TypeName(nameof(Product))]
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

        [ForeignKey(nameof(Farmhouse))]
        public int IdFarmhouse { get; set; }

        public Farmhouse Farmhouse { get; set; }
    }
}
