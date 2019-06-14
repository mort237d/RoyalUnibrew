using System.ComponentModel.DataAnnotations;

namespace RestService.Models
{
    public partial class ConstantValues
    {
        [Key]
        [StringLength(255)]
        public string Name { get; set; }

        public double Minimum { get; set; }

        public double Maximum { get; set; }
    }
}
