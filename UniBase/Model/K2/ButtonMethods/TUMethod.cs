using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UniBase.Annotations;

namespace UniBase.Model.K2.ButtonMethods
{
    public class TUMethod : INotifyPropertyChanged, IManageButtonMethods
    {
        private Message message = new Message();

        private ObservableCollection<TUs> _tuList;

        public ObservableCollection<TUs> TuList
        {
            get { return _tuList; }
            set
            {
                _tuList = value;
                OnPropertyChanged();
            }
        }

        public TUMethod()
        {
            RefreshLastTen();
        }


        public void RefreshAll()
        {
            TuList = ModelGenerics.GetAll(new TUs());
            message.ShowToastNotification("Opdateret", "TU-tabellen er opdateret");
        }

        public void RefreshLastTen()
        {
            TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
            message.ShowToastNotification("Opdateret", "TU-tabellen er opdateret");
        }

        public void SaveAll()
        {
            Parallel.ForEach(TuList, tus =>
            {
                InputValidator.CheckIfInputsAreValid(ref tus);
            });
            Parallel.ForEach(TuList, tus =>
            {
                ModelGenerics.UpdateByObjectAndId((int)tus.TU_ID, tus);
            });
            message.ShowToastNotification("Gemt", "TU-tabellen er gemt");
        }

        public void DeleteItem()
        {
            throw new System.NotImplementedException();
        }

        public void AddNewItem()
        {
            var ObjectToAdd = ManageTables.Instance.NewTUs;
            InputValidator.CheckIfInputsAreValid(ref ObjectToAdd);

            //Autofills

            if (ModelGenerics.CreateByObject(ObjectToAdd))
            {
                TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());

                ManageTables.Instance.NewTUs = new TUs();
                
            }
            else
            {
                //error
            }
        }

        public void SelectParentItem(object obj)
        {
            int id = (int)obj;

            ControlRegistrations del = ManageTables.Instance.ControlRegistrationsList.First(d => d.ControlRegistration_ID == id);
            int index = ManageTables.Instance.ControlRegistrationsList.IndexOf(del);

           // SelectedControlRegistrationId = index;
        }

        #region InotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
