using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBase.Model.K2.TableMethods
{
    public abstract class AbstractManageTableMethods
    {
        public abstract void RefreshAll();
        public abstract void RefreshLastTen();

        public virtual void SaveAll(int i)
        {

        }
        public abstract void DeleteItem();
        public abstract void AddNewItem();
        public abstract void SelectParentItem(object obj);
        public abstract void SortButtonClick(object id);
    }
}
