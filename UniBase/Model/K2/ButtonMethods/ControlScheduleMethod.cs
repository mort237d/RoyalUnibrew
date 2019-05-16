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

        private Message _message = new Message();
        
        private XamlBindings _xamlBindings = new XamlBindings();
        private GenericMethod _genericMethod = new GenericMethod();
        private PropertyInfo[] PropertyInfos = typeof(ControlSchedules).GetProperties();

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

                _genericMethod.Filter(new ControlSchedules(), ControlSchedulesList, CompleteControlSchedulesList, PropertyInfos[0].Name, _controlScheduleIdTextBoxOutput, Initialize);
            }
        }

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;

                _genericMethod.Filter(new ControlSchedules(), ControlSchedulesList, CompleteControlSchedulesList, PropertyInfos[1].Name, _processOrderNoTextBoxOutput, Initialize);
            }
        }

        public string TimeTextBoxOutput
        {
            get { return _timeTextBoxOutput; }
            set
            {
                _timeTextBoxOutput = value;

                _genericMethod.Filter(new ControlSchedules(), ControlSchedulesList, CompleteControlSchedulesList, PropertyInfos[2].Name, _timeTextBoxOutput, Initialize);
            }
        }

        public string WeightTextBoxOutput
        {
            get { return _weightTextBoxOutput; }
            set
            {
                _weightTextBoxOutput = value;

                _genericMethod.Filter(new ControlSchedules(), ControlSchedulesList, CompleteControlSchedulesList, PropertyInfos[3].Name, _weightTextBoxOutput, Initialize);
            }
        }

        public string KegTestTextBoxOutput
        {
            get { return _kegTestTextBoxOutput; }
            set
            {
                _kegTestTextBoxOutput = value;

                _genericMethod.Filter(new ControlSchedules(), ControlSchedulesList, CompleteControlSchedulesList, PropertyInfos[4].Name, _kegTestTextBoxOutput, Initialize);
            }
        }

        public string LudKoncentrationTextBoxOutput
        {
            get { return _ludKoncentrationTextBoxOutput; }
            set
            {
                _ludKoncentrationTextBoxOutput = value;

                _genericMethod.Filter(new ControlSchedules(), ControlSchedulesList, CompleteControlSchedulesList, PropertyInfos[5].Name, _ludKoncentrationTextBoxOutput, Initialize);
            }
        }

        public string MipMaTextBoxOutput
        {
            get { return _mipMaTextBoxOutput; }
            set
            {
                _mipMaTextBoxOutput = value;

                _genericMethod.Filter(new ControlSchedules(), ControlSchedulesList, CompleteControlSchedulesList, PropertyInfos[6].Name, _mipMaTextBoxOutput, Initialize);
            }
        }

        public string SignatureTextBoxOutput
        {
            get { return _signatureTextBoxOutput; }
            set
            {
                _signatureTextBoxOutput = value;

                _genericMethod.Filter(new ControlSchedules(), ControlSchedulesList, CompleteControlSchedulesList, PropertyInfos[7].Name, _signatureTextBoxOutput, Initialize);
            }
        }

        public string NoteTextBoxOutput
        {
            get { return _noteTextBoxOutput; }
            set
            {
                _noteTextBoxOutput = value;

                _genericMethod.Filter(new ControlSchedules(), ControlSchedulesList, CompleteControlSchedulesList, PropertyInfos[8].Name, _noteTextBoxOutput, Initialize);
            }
        }

        public ObservableCollection<ControlSchedules> CompleteControlSchedulesList
        {
            get { return _completeControlSchedulesList; }
            set { _completeControlSchedulesList = value; }
        }

        #endregion

        public void Initialize()
        {
            ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
            Parallel.ForEach(ControlSchedulesList, controleSchedule =>
            {
                controleSchedule.TimeStringHelper = controleSchedule.Time.ToString(@"hh\:mm");
            });
        }

        public void RefreshAll()
        {
            ControlSchedulesList = ModelGenerics.GetAll(new ControlSchedules());
            Parallel.ForEach(ControlSchedulesList, controleSchedule =>
            {
                controleSchedule.TimeStringHelper = controleSchedule.Time.ToString(@"hh\:mm");
            });
            _message.ShowToastNotification("Opdateret", "Kontrol Skema-tabellen er opdateret");
        }

        public void RefreshLastTen()
        {
            ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
            Parallel.ForEach(ControlSchedulesList, controleSchedule =>
            {
                controleSchedule.TimeStringHelper = controleSchedule.Time.ToString(@"hh:mm:ss");
            });
            _message.ShowToastNotification("Opdateret", "Kontrol Skema-tabellen er opdateret");
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
            _message.ShowToastNotification("Gemt", "Kontrol Skema-tabellen er gemt");
        }

        public void DeleteItem()
        {
            if (SelectedControlSchedule != null)
            {
                _genericMethod.DeleteSelected(SelectedControlSchedule, new ControlSchedules(), CompleteControlSchedulesList, ControlSchedulesList, "ControlSchedule_ID");
                _message.ShowToastNotification("Slettet", "Kontrol Skema slettet");
            }
            else
            {
                _message.ShowToastNotification("Fejl", "Marker venligst ønskede Kontrol Skema, for at slette");
            }
        }

        public void AddNewItem()
        {
            var objectToAdd = NewControlSchedules;
            InputValidator.CheckIfInputsAreValid(ref objectToAdd);
            
           
            if (ModelGenerics.CreateByObject(objectToAdd))
            {
                Initialize();

                NewControlSchedules = new ControlSchedules
                {
                    ProcessOrder_No = ControlSchedulesList.Last().ProcessOrder_No
                };
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

        public void SortButtonClick(object id)
        {
            if (id.ToString() == _xamlBindings.ControlSchedulesHeaderList[0].Header)
                ControlSchedulesList = _genericMethod.Sort<ControlSchedules>(ControlSchedulesList,
                    PropertyInfos[0].Name);
            else if (id.ToString() == _xamlBindings.ControlSchedulesHeaderList[1].Header)
                ControlSchedulesList = _genericMethod.Sort<ControlSchedules>(ControlSchedulesList,
                    PropertyInfos[1].Name);
            else if (id.ToString() == _xamlBindings.ControlSchedulesHeaderList[2].Header)
                ControlSchedulesList = _genericMethod.Sort<ControlSchedules>(ControlSchedulesList,
                    PropertyInfos[2].Name);
            else if (id.ToString() == _xamlBindings.ControlSchedulesHeaderList[3].Header)
                ControlSchedulesList = _genericMethod.Sort<ControlSchedules>(ControlSchedulesList,
                    PropertyInfos[3].Name);
            else if (id.ToString() == _xamlBindings.ControlSchedulesHeaderList[4].Header)
                ControlSchedulesList = _genericMethod.Sort<ControlSchedules>(ControlSchedulesList,
                    PropertyInfos[4].Name);
            else if (id.ToString() == _xamlBindings.ControlSchedulesHeaderList[5].Header)
                ControlSchedulesList = _genericMethod.Sort<ControlSchedules>(ControlSchedulesList,
                    PropertyInfos[5].Name);
            else if (id.ToString() == _xamlBindings.ControlSchedulesHeaderList[6].Header)
                ControlSchedulesList = _genericMethod.Sort<ControlSchedules>(ControlSchedulesList,
                    PropertyInfos[6].Name);
            else if (id.ToString() == _xamlBindings.ControlSchedulesHeaderList[7].Header)
                ControlSchedulesList = _genericMethod.Sort<ControlSchedules>(ControlSchedulesList,
                    PropertyInfos[7].Name);
            else if (id.ToString() == _xamlBindings.ControlSchedulesHeaderList[8].Header)
                ControlSchedulesList = _genericMethod.Sort<ControlSchedules>(ControlSchedulesList,
                    PropertyInfos[8].Name);
            else
                Debug.WriteLine("Error");
        }

        #region SingleTon
        private static ControlScheduleMethod _instance;
        private static object syncLock = new object();

        public static ControlScheduleMethod Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ControlScheduleMethod();
                        }
                    }
                }

                return _instance;
            }
        }


        #endregion

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
