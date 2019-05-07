using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestService.Models
{
    [Table("Production")]
    public partial class Production
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Production_ID { get; set; }

        public int PalletPutInStock0001 { get; set; }

        public int Tapmachine { get; set; }

        public int TotalKegsPrPallet { get; set; }

        public int Counter { get; set; }

        public int PalletCounter { get; set; }

        [Column(TypeName = "date")]
        public DateTime BatchDate { get; set; }

        public int ProcessOrder_No { get; set; }

        public virtual Frontpage Frontpage { get; set; }
    }
}
