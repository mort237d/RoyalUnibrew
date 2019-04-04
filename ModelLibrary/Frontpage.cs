﻿using System;

namespace ModelLibrary
{
    public class Frontpage
    {
        public int ProcessOrder_No { get; set; } //PK
        public int FinishedProduct_No { get; set; } //FK
        public int Contro_ID { get; set; } //FK
        public int LabelContro_ID { get; set; } //FK
        public int ShiftReg_ID { get; set; } //FK
        public int Production_ID { get; set; } //FK
        public int TU_ID { get; set; } //FK
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public int Column { get; set; }
    }
}
