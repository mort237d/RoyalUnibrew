using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestService.Models
{
    [Table("ControlRegistration")]
    public partial class ControlRegistration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ControlRegistration_ID { get; set; }

        public TimeSpan Time { get; set; }

        [Column(TypeName = "date")]
        public DateTime Production_Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime Expiry_Date { get; set; }

        [Required]
        [StringLength(50)]
        public string CommentsOnChangedDate { get; set; }

        public bool ControlAlcoholSpearDispenser { get; set; }

        public int CapNo { get; set; }

        public int EtiquetteNo { get; set; }

        [Required]
        [StringLength(10)]
        public string KegSize { get; set; }

        [Required]
        [StringLength(50)]
        public string Signature { get; set; }

        public DateTime FirstPalletDepalletizing { get; set; }

        public DateTime LastPalletDepalletizing { get; set; }

        public int ProcessOrder_No { get; set; }

        public int FinishedProduct_No { get; set; }

        public virtual Product Product { get; set; }

        public virtual Frontpage Frontpage { get; set; }
    }
}
