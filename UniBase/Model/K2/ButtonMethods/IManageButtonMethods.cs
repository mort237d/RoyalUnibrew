using System.ComponentModel;
using System.Threading.Tasks;

namespace UniBase.Model.K2.ButtonMethods
{
    interface IManageButtonMethods : INotifyPropertyChanged
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
