using System.ComponentModel;

namespace UniBase.Model.K2.TableMethods
{
    interface IManageTableMethods : INotifyPropertyChanged
    {
        void RefreshAll();
        void RefreshLastTen();
        void SaveAll();
        void DeleteItem();
        void AddNewItem();
        void SelectParentItem(object obj);
        void SortButtonClick(object id);
    }
}
