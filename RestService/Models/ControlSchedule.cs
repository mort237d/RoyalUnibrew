using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestService.Models
{
    [Table("ControlSchedule")]
    public partial class ControlSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ControlSchedule_ID { get; set; }

        public DateTime Time { get; set; }

        public double Weight { get; set; }

        [Required]
        [StringLength(50)]
        public string KegTest { get; set; }

        public double LudKoncentration { get; set; }

        public double MipMA { get; set; }

        [Required]
        [StringLength(50)]
        public string Signature { get; set; }

        public string Note { get; set; }

        public int ProcessOrder_No { get; set; }

        public virtual Frontpage Frontpage { get; set; }
    }
}
