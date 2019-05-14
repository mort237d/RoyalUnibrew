using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UniBase.Annotations;

namespace UniBase.Model.K2.ButtonMethods
{
    public class ControlScheduleMethod : IManageButtonMethods
    {
        public ControlScheduleMethod()
        {
            Initialize();
        }
        #region Fields
        private ObservableCollection<ControlSchedules> _completeControlSchedulesList = ModelGenerics.GetAll(new ControlSchedules());

        private ObservableCollection<ControlSchedules> _controlSchedulesList;

        private ControlSchedules _newControlSchedules = new ControlSchedules();

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

        #region Properties
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

        public ObservableCollection<ControlSchedules> ControlSchedulesList
        {
            get { return _controlSchedulesList; }
            set
            {
                _controlSchedulesList = value;
                OnPropertyChanged();
            }
        }

        public ControlSchedules NewControlSchedules
        {
            get { return _newControlSchedules; }
            set
            {
                _newControlSchedules = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Filters
        public string ControlScheduleIdTextBoxOutput
        {
            get { return _controlScheduleIdTextBoxOutput; }
            set
            {
                _controlScheduleIdTextBoxOutput = value;

                ControlSchedulesList.Clear();

                foreach (var f in _completeControlSchedulesList)
                {
                    var v = f.ControlSchedule_ID.ToString().ToLower();
                    if (v.Contains(_controlScheduleIdTextBoxOutput.ToLower()))
                    {
                        ControlSchedulesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_controlScheduleIdTextBoxOutput))
                {
                    ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
                }
            }
        }

        public string TimeTextBoxOutput
        {
            get { return _timeTextBoxOutput; }
            set
            {
                _timeTextBoxOutput = value;

                ControlSchedulesList.Clear();

                foreach (var f in _completeControlSchedulesList)
                {
                    var v = f.Time.ToString().ToLower();
                    if (v.Contains(_timeTextBoxOutput.ToLower()))
                    {
                        ControlSchedulesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_timeTextBoxOutput))
                {
                    ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
                }
            }
        }

        public string WeightTextBoxOutput
        {
            get { return _weightTextBoxOutput; }
            set
            {
                _weightTextBoxOutput = value;

                ControlSchedulesList.Clear();

                foreach (var f in _completeControlSchedulesList)
                {
                    var v = f.Weight.ToString().ToLower();
                    if (v.Contains(_weightTextBoxOutput.ToLower()))
                    {
                        ControlSchedulesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_weightTextBoxOutput))
                {
                    ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
                }
            }
        }

        public string KegTestTextBoxOutput
        {
            get { return _kegTestTextBoxOutput; }
            set
            {
                _kegTestTextBoxOutput = value;
                ControlSchedulesList.Clear();

                foreach (var f in _completeControlSchedulesList)
                {
                    var v = f.KegTest.ToString().ToLower();
                    if (v.Contains(_kegTestTextBoxOutput.ToLower()))
                    {
                        ControlSchedulesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_kegTestTextBoxOutput))
                {
                    ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
                }
            }
        }

        public string LudKoncentrationTextBoxOutput
        {
            get { return _ludKoncentrationTextBoxOutput; }
            set
            {
                _ludKoncentrationTextBoxOutput = value;

                ControlSchedulesList.Clear();

                foreach (var f in _completeControlSchedulesList)
                {
                    var v = f.LudKoncentration.ToString().ToLower();
                    if (v.Contains(_ludKoncentrationTextBoxOutput.ToLower()))
                    {
                        ControlSchedulesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_ludKoncentrationTextBoxOutput))
                {
                    ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
                }
            }
        }

        public string MipMaTextBoxOutput
        {
            get { return _mipMaTextBoxOutput; }
            set
            {
                _mipMaTextBoxOutput = value;

                ControlSchedulesList.Clear();

                foreach (var f in _completeControlSchedulesList)
                {
                    var v = f.MipMA.ToString().ToLower();
                    if (v.Contains(_mipMaTextBoxOutput.ToLower()))
                    {
                        ControlSchedulesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_mipMaTextBoxOutput))
                {
                    ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
                }
            }
        }

        public string SignatureTextBoxOutput
        {
            get { return _signatureTextBoxOutput; }
            set
            {
                _signatureTextBoxOutput = value;

                ControlSchedulesList.Clear();

                foreach (var f in _completeControlSchedulesList)
                {
                    var v = f.Signature.ToString().ToLower();
                    if (v.Contains(_signatureTextBoxOutput.ToLower()))
                    {
                        ControlSchedulesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_signatureTextBoxOutput))
                {
                    ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
                }
            }
        }

        public string NoteTextBoxOutput
        {
            get { return _noteTextBoxOutput; }
            set
            {
                _noteTextBoxOutput = value;

                ControlSchedulesList.Clear();

                foreach (var f in _completeControlSchedulesList)
                {
                    var v = f.Note.ToString().ToLower();
                    if (v.Contains(_noteTextBoxOutput.ToLower()))
                    {
                        ControlSchedulesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_noteTextBoxOutput))
                {
                    ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
                }
            }
        }

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;


                ControlSchedulesList.Clear();

                foreach (var f in _completeControlSchedulesList)
                {
                    var v = f.ProcessOrder_No.ToString().ToLower();
                    if (v.Contains(_processOrderNoTextBoxOutput.ToLower()))
                    {
                        ControlSchedulesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_processOrderNoTextBoxOutput))
                {
                    ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
                }
            }
        }
        #endregion
        public void Initialize()
        {
            ControlSchedulesList = ModelGenerics.GetAll(new ControlSchedules());
            Parallel.ForEach(ControlSchedulesList, controleSchedule =>
            {
                controleSchedule.TimeStringHelper = controleSchedule.Time.ToString(@"hh:mm:ss");
            });
        }

        public void RefreshAll()
        {
            ControlSchedulesList = ModelGenerics.GetAll(new ControlSchedules());
            Parallel.ForEach(ControlSchedulesList, controleSchedule =>
            {
                controleSchedule.TimeStringHelper = controleSchedule.Time.ToString(@"hh:mm:ss");
            });
            message.ShowToastNotification("Opdateret", "Kontrol Skema-tabellen er opdateret");
        }

        public void RefreshLastTen()
        {
            ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
            Parallel.ForEach(ControlSchedulesList, controleSchedule =>
            {
                controleSchedule.TimeStringHelper = controleSchedule.Time.ToString(@"hh:mm:ss");
            });
            message.ShowToastNotification("Opdateret", "Kontrol Skema-tabellen er opdateret");
        }

        public void SaveAll()
        {
            Parallel.ForEach(ControlSchedulesList, controleSchedule =>
            {
                InputValidator.CheckIfInputsAreValid(ref controleSchedule);
            });
            Parallel.ForEach(ControlSchedulesList, controlSchedules =>
            {
                ModelGenerics.UpdateByObjectAndId((int)controlSchedules.ControlSchedule_ID, controlSchedules);
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
            var objectToAdd = NewControlSchedules;
            InputValidator.CheckIfInputsAreValid(ref objectToAdd);

           
            if (ModelGenerics.CreateByObject(objectToAdd))
            {
                ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());

                NewControlSchedules = new ControlSchedules();

                NewControlSchedules.ProcessOrder_No = ControlSchedulesList.Last().ProcessOrder_No;
            }
            else
            {
                //error
            }
        }

        public void SelectParentItem(object obj)
        {
            int id = (int)obj;

            ControlSchedules del = ControlSchedulesList.First(d => d.ControlSchedule_ID == id);
            int index = ControlSchedulesList.IndexOf(del);

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
