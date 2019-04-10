namespace RestService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Frontpage")]
    public partial class Frontpage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProcessOrder_No { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int FinishedProduct_No { get; set; }

        public int Colunm { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public int Control_ID { get; set; }

        public int LabelControl_ID { get; set; }

        public int Shift_Reg { get; set; }

        public int Production_ID { get; set; }

        public int TU_ID { get; set; }

        public int Week_No { get; set; }

        public virtual Product Product { get; set; }
    }
}
