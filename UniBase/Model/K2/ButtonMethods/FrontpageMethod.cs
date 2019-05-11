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
        private InputValidator inputValidator = new InputValidator();

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
        public ObservableCollection<Frontpages> CompleteFrontpagesList { get => _completeFrontpagesList; set => _completeFrontpagesList = value; }

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;

                ManageTables.Instance.FrontpagesList.Clear();

                foreach (var f in CompleteFrontpagesList)
                {
                    var v = f.ProcessOrder_No.ToString();
                    if (v.Contains(_processOrderNoTextBoxOutput))
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

                foreach (var f in CompleteFrontpagesList)
                {
                    var v = f.Date.ToString();
                    if (v.Contains(_dateTextBoxOutput))
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

                foreach (var f in CompleteFrontpagesList)
                {
                    var v = f.FinishedProduct_No.ToString();
                    if (v.Contains(_finishedProductNoTextBoxOutput))
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

                foreach (var f in CompleteFrontpagesList)
                {
                    var v = f.Colunm.ToString();
                    if (v.Contains(_columnTextBoxOutput))
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

                foreach (var f in CompleteFrontpagesList)
                {
                    var v = f.Note;
                    if (v.Contains(_noteTextBoxOutput))
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

                foreach (var f in CompleteFrontpagesList)
                {
                    var v = f.Week_No.ToString();
                    if (v.Contains(_weekNoTextBoxOutput))
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
