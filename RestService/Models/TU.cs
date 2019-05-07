using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestService.Models
{
    [Table("TU")]
    public partial class TU
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TU_ID { get; set; }

        public int FirstDayStart_TU { get; set; }

        public int FirstDayEnd_TU { get; set; }

        public int FirstDay_Total { get; set; }

        public int SecoundDayStart_TU { get; set; }

        public int SecoundDayEnd_TU { get; set; }

        public int SecoundDay_Total { get; set; }

        public int ThirdDayStart_TU { get; set; }

        public int ThirdDayEnd_TU { get; set; }

        public int ThirdDay_Total { get; set; }

        public int ProcessOrder_No { get; set; }

        public virtual Frontpage Frontpage { get; set; }
    }
}
