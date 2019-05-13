using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBase.Model.K2.ButtonMethods
{
    interface IManageButtonMethods
    {
        void RefreshAll();
        void RefreshLastTen();
        void SaveAll();
        void DeleteItem();
        void AddNewItem();
    }
}
