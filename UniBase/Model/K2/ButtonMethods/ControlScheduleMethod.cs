using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UniBase.Annotations;

namespace UniBase.Model.K2.ButtonMethods
{
    public class ControlScheduleMethod : INotifyPropertyChanged, IManageButtonMethods
    {
        #region Fields
        private ObservableCollection<ControlSchedules> _completeControlSchedulesList = ModelGenerics.GetAll(new ControlSchedules());

        private Message message = new Message();

        private int _selectedControlScheduleId;
        private ControlSchedules _selectedControlSchedule;

        private string _controlScheduleIdTextBoxOutput;
        private string _timeTextBoxOutput;
        private string _weightTextBoxOutput;
        private string _kegTestTextBoxOutput;
        private string _ludKoncentrationTextBoxOutput;
        private string _mipMaTextBoxOutput;
        private string _signatureTextBoxOutput;
        private string _noteTextBoxOutput;
        private string _processOrderNoTextBoxOutput;
        #endregion

        public int SelectedControlScheduleId
        {
            get { return _selectedControlScheduleId; }
            set
            {
                _selectedControlScheduleId = value;
                OnPropertyChanged();
            }
        }

        public ControlSchedules SelectedControlSchedule
        {
            get { return _selectedControlSchedule; }
            set
            {
                _selectedControlSchedule = value;
                OnPropertyChanged();
            }
        }

        #region Filters
        public string ControlScheduleIdTextBoxOutput
        {
            get { return _controlScheduleIdTextBoxOutput; }
            set
            {
                _controlScheduleIdTextBoxOutput = value;

                ManageTables.Instance.ControlSchedulesList.Clear();

                foreach (var f in _completeControlSchedulesList)
                {
                    var v = f.ControlSchedule_ID.ToString().ToLower();
                    if (v.Contains(_controlScheduleIdTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ControlSchedulesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_controlScheduleIdTextBoxOutput))
                {
                    ManageTables.Instance.ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
                }
            }
        }

        public string TimeTextBoxOutput
        {
            get { return _timeTextBoxOutput; }
            set
            {
                _timeTextBoxOutput = value;

                ManageTables.Instance.ControlSchedulesList.Clear();

                foreach (var f in _completeControlSchedulesList)
                {
                    var v = f.Time.ToString().ToLower();
                    if (v.Contains(_timeTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ControlSchedulesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_timeTextBoxOutput))
                {
                    ManageTables.Instance.ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
                }
            }
        }

        public string WeightTextBoxOutput
        {
            get { return _weightTextBoxOutput; }
            set
            {
                _weightTextBoxOutput = value;

                ManageTables.Instance.ControlSchedulesList.Clear();

                foreach (var f in _completeControlSchedulesList)
                {
                    var v = f.Weight.ToString().ToLower();
                    if (v.Contains(_weightTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ControlSchedulesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_weightTextBoxOutput))
                {
                    ManageTables.Instance.ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
                }
            }
        }

        public string KegTestTextBoxOutput
        {
            get { return _kegTestTextBoxOutput; }
            set
            {
                _kegTestTextBoxOutput = value;
                ManageTables.Instance.ControlSchedulesList.Clear();

                foreach (var f in _completeControlSchedulesList)
                {
                    var v = f.KegTest.ToString().ToLower();
                    if (v.Contains(_kegTestTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ControlSchedulesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_kegTestTextBoxOutput))
                {
                    ManageTables.Instance.ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
                }
            }
        }

        public string LudKoncentrationTextBoxOutput
        {
            get { return _ludKoncentrationTextBoxOutput; }
            set
            {
                _ludKoncentrationTextBoxOutput = value;

                ManageTables.Instance.ControlSchedulesList.Clear();

                foreach (var f in _completeControlSchedulesList)
                {
                    var v = f.LudKoncentration.ToString().ToLower();
                    if (v.Contains(_ludKoncentrationTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ControlSchedulesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_ludKoncentrationTextBoxOutput))
                {
                    ManageTables.Instance.ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
                }
            }
        }

        public string MipMaTextBoxOutput
        {
            get { return _mipMaTextBoxOutput; }
            set
            {
                _mipMaTextBoxOutput = value;

                ManageTables.Instance.ControlSchedulesList.Clear();

                foreach (var f in _completeControlSchedulesList)
                {
                    var v = f.MipMA.ToString().ToLower();
                    if (v.Contains(_mipMaTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ControlSchedulesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_mipMaTextBoxOutput))
                {
                    ManageTables.Instance.ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
                }
            }
        }

        public string SignatureTextBoxOutput
        {
            get { return _signatureTextBoxOutput; }
            set
            {
                _signatureTextBoxOutput = value;

                ManageTables.Instance.ControlSchedulesList.Clear();

                foreach (var f in _completeControlSchedulesList)
                {
                    var v = f.Signature.ToString().ToLower();
                    if (v.Contains(_signatureTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ControlSchedulesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_signatureTextBoxOutput))
                {
                    ManageTables.Instance.ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
                }
            }
        }

        public string NoteTextBoxOutput
        {
            get { return _noteTextBoxOutput; }
            set
            {
                _noteTextBoxOutput = value;

                ManageTables.Instance.ControlSchedulesList.Clear();

                foreach (var f in _completeControlSchedulesList)
                {
                    var v = f.Note.ToString().ToLower();
                    if (v.Contains(_noteTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ControlSchedulesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_noteTextBoxOutput))
                {
                    ManageTables.Instance.ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
                }
            }
        }

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;


                ManageTables.Instance.ControlSchedulesList.Clear();

                foreach (var f in _completeControlSchedulesList)
                {
                    var v = f.ProcessOrder_No.ToString().ToLower();
                    if (v.Contains(_processOrderNoTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ControlSchedulesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_processOrderNoTextBoxOutput))
                {
                    ManageTables.Instance.ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
                }
            }
        }
        #endregion


        public void RefreshAll()
        {
            ManageTables.Instance.ControlSchedulesList = ModelGenerics.GetAll(new ControlSchedules());
            Parallel.ForEach(ManageTables.Instance.ControlSchedulesList, controleSchedule =>
            {
                controleSchedule.TimeStringHelper = controleSchedule.Time.ToString(@"hh:mm:ss");
            });
            message.ShowToastNotification("Opdateret", "Kontrol Skema-tabellen er opdateret");
        }

        public void RefreshLastTen()
        {
            ManageTables.Instance.ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
            Parallel.ForEach(ManageTables.Instance.ControlSchedulesList, controleSchedule =>
            {
                controleSchedule.TimeStringHelper = controleSchedule.Time.ToString(@"hh:mm:ss");
            });
            message.ShowToastNotification("Opdateret", "Kontrol Skema-tabellen er opdateret");
        }

        public void SaveAll()
        {
            Parallel.ForEach(ManageTables.Instance.ControlSchedulesList, controleSchedule =>
            {
                InputValidator.CheckIfInputsAreValid(ref controleSchedule);
            });
            Parallel.ForEach(ManageTables.Instance.ControlSchedulesList, controlSchedules =>
            {
                ModelGenerics.UpdateByObjectAndId(controlSchedules.ControlSchedule_ID, controlSchedules);
            });
            message.ShowToastNotification("Gemt", "Kontrol Skema-tabellen er gemt");
        }

        public void DeleteItem()
        {
            if (SelectedControlSchedule != null)
            {
                //TODO Make deletion method
                Debug.WriteLine(SelectedControlSchedule.ControlSchedule_ID);
            }
        }

        public void AddNewItem()
        {
            var objectToAdd = ManageTables.Instance.NewControlRegistrationsToAdd;
            InputValidator.CheckIfInputsAreValid(ref objectToAdd);

           
            if (ModelGenerics.CreateByObject(objectToAdd))
            {
                ManageTables.Instance.ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());

                ManageTables.Instance.NewControlRegistrationsToAdd = new ControlRegistrations();

                ManageTables.Instance.NewControlSchedules.ProcessOrder_No = ManageTables.Instance.ControlRegistrationsList.Last().ProcessOrder_No;
            }
            else
            {
                //error
            }
        }

        public void SelectParentItem(object obj)
        {
            int id = (int)obj;

            ControlSchedules del = ManageTables.Instance.ControlSchedulesList.First(d => d.ControlSchedule_ID == id);
            int index = ManageTables.Instance.ControlSchedulesList.IndexOf(del);

            SelectedControlScheduleId = index;
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
