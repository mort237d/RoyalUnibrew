using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniBase.Model.K2;

namespace UniBase.Model
{
    class OutOfBoundColorChange
    {
        private ManageTables manageTables = ManageTables.Instance;
        private ConstantValues constantValues = new ConstantValues();

        public string WeightTextBoxColor { get; set; }

        public void ChangeListViewColor()
        {
            foreach (var item in manageTables.ControlSchedulesList)
            {
                //if (expr)
                //{
                    
                //}
                //if (item.Weight < constantValues.MinWeight && item.Weight > constantValues.MaxWeight)
                //{
                //    WeightTextBoxColor = "Red";
                //}
                //else
                //{
                //    WeightTextBoxColor = "White";
                //}

            }
            
        }
    }
}
