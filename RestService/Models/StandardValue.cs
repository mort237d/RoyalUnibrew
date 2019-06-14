using System.ComponentModel.DataAnnotations;

namespace RestService.Models
{
    public partial class StandardValue
    {
        [Key]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Value { get; set; }
    }
}
