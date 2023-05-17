using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LocalFarmer.Domain.Models.MyType;

namespace LocalFarmer.Domain.Models
{
    [TypeName(nameof(Farmhouse))]
    public class Farmhouse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual IList<Product> Products { get; set; }
    }
}
