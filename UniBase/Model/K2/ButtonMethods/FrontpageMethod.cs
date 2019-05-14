using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UniBase.Annotations;

namespace UniBase.Model.K2.ButtonMethods
{
    public class FrontpageMethod : IManageButtonMethods
    {

        #region Fields
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
        #endregion



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

        #region Filter
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
        #endregion

        public void RefreshAll()
        {
            ManageTables.Instance.FrontpagesList = ModelGenerics.GetAll(new Frontpages());
            Parallel.ForEach(ManageTables.Instance.FrontpagesList, frontpage =>
            {
                frontpage.DateTimeStringHelper = frontpage.Date.ToString("yyyy/MM/dd");
            });
            message.ShowToastNotification("Opdateret", "Forside-tabellen er opdateret");
        }
        public void RefreshLastTen()
        {
            ManageTables.Instance.FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
            foreach (var frontpage in ManageTables.Instance.FrontpagesList)
            {
                frontpage.DateTimeStringHelper = frontpage.Date.ToString("yyyy/MM/dd");
            }
            message.ShowToastNotification("Opdateret", "Forside-tabellen er opdateret");
        }
        public void SaveAll()
        {
            Parallel.ForEach(ManageTables.Instance.FrontpagesList, frontpage =>
            {
                InputValidator.CheckIfInputsAreValid(ref frontpage);
            });

            Parallel.ForEach(ManageTables.Instance.FrontpagesList, frontpage =>
            {
                ModelGenerics.UpdateByObjectAndId((int)frontpage.ProcessOrder_No, frontpage);
            });
            message.ShowToastNotification("Gemt", "Forside-tabellen er gemt");
        }

        public void DeleteItem()
        {
            if (SelectedFrontpage != null)
            {
                //TODO Make deletion method
                Debug.WriteLine(SelectedFrontpage.ProcessOrder_No);
            }
        }

        public void AddNewItem()
        {
            var instanceNewFrontpagesToAdd = ManageTables.Instance.NewFrontpagesToAdd;
            InputValidator.CheckIfInputsAreValid(ref instanceNewFrontpagesToAdd);

            //Autofills
            instanceNewFrontpagesToAdd.Week_No = FindWeekNumber(instanceNewFrontpagesToAdd.Date);

            
            if (ModelGenerics.CreateByObject(instanceNewFrontpagesToAdd))
            {
                ManageTables.Instance.FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
                ManageTables.Instance.NewFrontpagesToAdd = new Frontpages();
            }
            else
            {
                //error
            }
        }

        public int FindWeekNumber(DateTime time)
        {
            // https://stackoverflow.com/questions/11154673/get-the-correct-week-number-of-a-given-date
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
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
