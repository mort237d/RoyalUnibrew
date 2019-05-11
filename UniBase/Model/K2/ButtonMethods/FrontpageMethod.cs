using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UniBase.Annotations;

namespace UniBase.Model.K2.ButtonMethods
{
    public class FrontpageMethod : INotifyPropertyChanged
    {
        private Message message = new Message();
        private InputValidator inputValidator = new InputValidator();

        private int _selectedFrontpageId;
        private Frontpages _selectedFrontpage;

        public int SelectedFrontpageId
        {
            get { return _selectedFrontpageId; }
            set
            {
                _selectedFrontpageId = value;
                OnPropertyChanged();
            }
        }

        public Frontpages SelectedFrontpage
        {
            get { return _selectedFrontpage; }
            set
            {
                _selectedFrontpage = value;
                OnPropertyChanged();
            }
        }

        public void RefreshFrontpages()
        {
            ManageTables.Instance.FrontpagesList = ModelGenerics.GetAll(new Frontpages());
            Parallel.ForEach(ManageTables.Instance.FrontpagesList, frontpage =>
            {
                frontpage.DateTimeStringHelper = frontpage.Date.ToString();
            });
            message.ShowToastNotification("Opdateret", "Forside-tabellen er opdateret");
        }
        public void RefreshLastTenFrontpages()
        {
            ManageTables.Instance.FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
            foreach (var frontpage in ManageTables.Instance.FrontpagesList)
            {
                frontpage.DateTimeStringHelper = frontpage.Date.ToString().Remove(10);
            }
            message.ShowToastNotification("Opdateret", "Forside-tabellen er opdateret");
        }
        public void SaveFrontpages()
        {

            Parallel.ForEach(ManageTables.Instance.FrontpagesList, frontpage =>
            {
                ModelGenerics.UpdateByObjectAndId(frontpage.ProcessOrder_No, frontpage);
            });
            message.ShowToastNotification("Gemt", "Forside-tabellen er gemt");
        }

        public void DeleteFrontpage(object id)
        {
            if (SelectedFrontpage != null)
            {
                //TODO Make deletion method
                Debug.WriteLine(SelectedFrontpage.ProcessOrder_No);
            }
        }

        public void AddNewFrontpages()
        {
            var instanceNewFrontpagesToAdd = ManageTables.Instance.NewFrontpagesToAdd;
            inputValidator.CheckIfInputsAreValid(ref instanceNewFrontpagesToAdd);
            instanceNewFrontpagesToAdd.Week_No = FindWeekNumber(instanceNewFrontpagesToAdd);

            //Checks whether any of the properties are null if any are returns true
            bool isNull = instanceNewFrontpagesToAdd.GetType().GetProperties().All(p => p.GetValue(instanceNewFrontpagesToAdd) == null);

            if (!isNull)
            {
                ManageTables.Instance.FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
                instanceNewFrontpagesToAdd.ProcessOrder_No = ManageTables.Instance.FrontpagesList.Last().ProcessOrder_No + 1;
                if (ModelGenerics.CreateByObject(instanceNewFrontpagesToAdd))
                {
                    //ManageTables.Instance.FrontpagesList.Add(NewFrontpagesToAdd);
                    ManageTables.Instance.FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
                    instanceNewFrontpagesToAdd = new Frontpages();
                    instanceNewFrontpagesToAdd.ProcessOrder_No = ManageTables.Instance.FrontpagesList[ManageTables.Instance.FrontpagesList.Count - 1].ProcessOrder_No + 1;
                    instanceNewFrontpagesToAdd.Date = DateTime.Now;
                    instanceNewFrontpagesToAdd.Week_No = FindWeekNumber(instanceNewFrontpagesToAdd);
                }
                else
                {
                    //error
                }
            }
        }

        public int FindWeekNumber(Frontpages frontpage)
        {
            int dayOfYear = frontpage.Date.DayOfYear;
            int weekNumber = 1;
            if (dayOfYear > 7)
            {
                if (dayOfYear % 1 != 0)
                {
                    weekNumber = (dayOfYear / 7) + 1;
                }
                else
                {
                    weekNumber = (dayOfYear / 7) + 1;
                }
            }

            return weekNumber;
        }

        public void SelectParentItemFrontpage(object obj)
        {
            int id = (int)obj;

            Frontpages del = ManageTables.Instance.FrontpagesList.First(d => d.ProcessOrder_No == id);
            int ix = ManageTables.Instance.FrontpagesList.IndexOf(del);

            SelectedFrontpageId = ix;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
