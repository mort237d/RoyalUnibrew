using System;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Frontpages> _completeFrontpagesList = ModelGenerics.GetAll(new Frontpages());

        private Message message = new Message();

        private int _selectedFrontpageId;
        private Frontpages _selectedFrontpage;

        private string _processOrderNoTextBoxOutput;
        private string _dateTextBoxOutput;
        private string _finishedProductNoTextBoxOutput;
        private string _columnTextBoxOutput;
        private string _noteTextBoxOutput;
        private string _weekNoTextBoxOutput;

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

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;

                ManageTables.Instance.FrontpagesList.Clear();

                foreach (var f in _completeFrontpagesList)
                {
                    var v = f.ProcessOrder_No.ToString().ToLower();
                    if (v.Contains(_processOrderNoTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.FrontpagesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_processOrderNoTextBoxOutput))
                {
                    ManageTables.Instance.FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
                }
            }
        }

        public string DateTextBoxOutput
        {
            get { return _dateTextBoxOutput; }
            set
            {
                _dateTextBoxOutput = value;

                ManageTables.Instance.FrontpagesList.Clear();

                foreach (var f in _completeFrontpagesList)
                {
                    var v = f.Date.ToString().ToLower();
                    if (v.Contains(_dateTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.FrontpagesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_dateTextBoxOutput))
                {
                    ManageTables.Instance.FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
                }
            }
        }

        public string FinishedProductNoTextBoxOutput
        {
            get { return _finishedProductNoTextBoxOutput; }
            set
            {
                _finishedProductNoTextBoxOutput = value;

                ManageTables.Instance.FrontpagesList.Clear();

                foreach (var f in _completeFrontpagesList)
                {
                    var v = f.FinishedProduct_No.ToString().ToLower();
                    if (v.Contains(_finishedProductNoTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.FrontpagesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_finishedProductNoTextBoxOutput))
                {
                    ManageTables.Instance.FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
                }
            }
        }

        public string ColumnTextBoxOutput
        {
            get { return _columnTextBoxOutput; }
            set
            {
                _columnTextBoxOutput = value;

                ManageTables.Instance.FrontpagesList.Clear();

                foreach (var f in _completeFrontpagesList)
                {
                    var v = f.Colunm.ToString().ToLower();
                    if (v.Contains(_columnTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.FrontpagesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_columnTextBoxOutput))
                {
                    ManageTables.Instance.FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
                }
            }
        }

        public string NoteTextBoxOutput
        {
            get { return _noteTextBoxOutput; }
            set
            {
                _noteTextBoxOutput = value;

                ManageTables.Instance.FrontpagesList.Clear();

                foreach (var f in _completeFrontpagesList)
                {
                    var v = f.Note.ToLower();
                    if (v.Contains(_noteTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.FrontpagesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_noteTextBoxOutput))
                {
                    ManageTables.Instance.FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
                }
            }
        }

        public string WeekNoTextBoxOutput
        {
            get { return _weekNoTextBoxOutput; }
            set
            {
                _weekNoTextBoxOutput = value;

                ManageTables.Instance.FrontpagesList.Clear();

                foreach (var f in _completeFrontpagesList)
                {
                    var v = f.Week_No.ToString().ToLower();
                    if (v.Contains(_weekNoTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.FrontpagesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_weekNoTextBoxOutput))
                {
                    ManageTables.Instance.FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
                }
            }
        }

        public void Refresh()
        {
            ManageTables.Instance.FrontpagesList = ModelGenerics.GetAll(new Frontpages());
            Parallel.ForEach(ManageTables.Instance.FrontpagesList, frontpage =>
            {
                frontpage.DateTimeStringHelper = frontpage.Date.ToString();
            });
            message.ShowToastNotification("Opdateret", "Forside-tabellen er opdateret");
        }
        public void RefreshLastTen()
        {
            ManageTables.Instance.FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
            foreach (var frontpage in ManageTables.Instance.FrontpagesList)
            {
                frontpage.DateTimeStringHelper = frontpage.Date.ToString().Remove(10);
            }
            message.ShowToastNotification("Opdateret", "Forside-tabellen er opdateret");
        }
        public void Save()
        {

            Parallel.ForEach(ManageTables.Instance.FrontpagesList, frontpage =>
            {
                ModelGenerics.UpdateByObjectAndId(frontpage.ProcessOrder_No, frontpage);
            });
            message.ShowToastNotification("Gemt", "Forside-tabellen er gemt");
        }

        public void Delete()
        {
            if (SelectedFrontpage != null)
            {
                //TODO Make deletion method
                Debug.WriteLine(SelectedFrontpage.ProcessOrder_No);
            }
        }

        public void AddNew()
        {
            var instanceNewFrontpagesToAdd = ManageTables.Instance.NewFrontpagesToAdd;
            InputValidator.CheckIfInputsAreValid(ref instanceNewFrontpagesToAdd);
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

        public void SelectParentItem(object obj)
        {
            int id = (int)obj;

            Frontpages del = ManageTables.Instance.FrontpagesList.First(d => d.ProcessOrder_No == id);
            int index = ManageTables.Instance.FrontpagesList.IndexOf(del);

            SelectedFrontpageId = index;
        }

        #region INotify

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
