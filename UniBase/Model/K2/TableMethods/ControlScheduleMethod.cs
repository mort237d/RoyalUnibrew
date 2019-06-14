using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UniBase.Annotations;

namespace UniBase.Model.K2.TableMethods
{
    public class ControlScheduleMethod : IManageTableMethods
    {
        #region Fields

        private ObservableCollection<ControlSchedules> _completeControlSchedulesList;

        private ObservableCollection<ControlSchedules> _controlSchedulesList;

        private ControlSchedules _newControlSchedules = new ControlSchedules();

        private Message _message = Message.Instance;
        
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

        public ControlScheduleMethod()
        {
            Initialize();
        }

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

        #region Filters
        public string ControlScheduleIdTextBoxOutput
        {
            get { return _controlScheduleIdTextBoxOutput; }
            set
            {
                _controlScheduleIdTextBoxOutput = value;

                Filter(0, _controlScheduleIdTextBoxOutput);
            }
        }

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;

                Filter(1, _processOrderNoTextBoxOutput);
            }
        }

        public string TimeTextBoxOutput
        {
            get { return _timeTextBoxOutput; }
            set
            {
                _timeTextBoxOutput = value;

                Filter(2, _timeTextBoxOutput);
            }
        }

        public string WeightTextBoxOutput
        {
            get { return _weightTextBoxOutput; }
            set
            {
                _weightTextBoxOutput = value;

                Filter(3, _weightTextBoxOutput);
            }
        }

        public string KegTestTextBoxOutput
        {
            get { return _kegTestTextBoxOutput; }
            set
            {
                _kegTestTextBoxOutput = value;

                Filter(4, _kegTestTextBoxOutput);
            }
        }

        public string LudKoncentrationTextBoxOutput
        {
            get { return _ludKoncentrationTextBoxOutput; }
            set
            {
                _ludKoncentrationTextBoxOutput = value;

                Filter(5, _ludKoncentrationTextBoxOutput);
            }
        }

        public string MipMaTextBoxOutput
        {
            get { return _mipMaTextBoxOutput; }
            set
            {
                _mipMaTextBoxOutput = value;

                Filter(6, _mipMaTextBoxOutput);
            }
        }

        public string SignatureTextBoxOutput
        {
            get { return _signatureTextBoxOutput; }
            set
            {
                _signatureTextBoxOutput = value;

                Filter(7, _signatureTextBoxOutput);
            }
        }

        public string NoteTextBoxOutput
        {
            get { return _noteTextBoxOutput; }
            set
            {
                _noteTextBoxOutput = value;

                Filter(8, _noteTextBoxOutput);
            }
        }

        public ObservableCollection<ControlSchedules> CompleteControlSchedulesList
        {
            get { return _completeControlSchedulesList; }
            set { _completeControlSchedulesList = value; }
        }

        #endregion
        #endregion
        
        private void Filter(int propIndex, string textBox)
        {
            _genericMethod.Filter(new ControlSchedules(), ControlSchedulesList, CompleteControlSchedulesList, PropertyInfos[propIndex].Name, textBox, Initialize, FillStringHelpers);
        }

        public async void Initialize()
        {
            ControlSchedulesList = await ModelGenerics.GetLastTenInDatabase(new ControlSchedules(), "ControlSchedule_ID", "Kontrol Skema");
            FillStringHelpers();

            _completeControlSchedulesList = await ModelGenerics.GetAll(new ControlSchedules());

            NewControlSchedules = new ControlSchedules
            {
                ControlScheduleIdIntHelper = (ControlSchedulesList.Last().ControlSchedule_ID + 1).ToString(),
                ProcessOrderNoIntHelper = ControlSchedulesList.Last().ProcessOrder_No.ToString()
            };
        }
        
        private void FillStringHelpers()
        {
            foreach (var controleSchedule in ControlSchedulesList)
            {
                FillStringHelpersHelper(controleSchedule);
                controleSchedule.ControlScheduleIdIntHelper = controleSchedule.ControlSchedule_ID.ToString();
                controleSchedule.LudKoncentrationDoubleHelper = controleSchedule.LudKoncentration.ToString("F");
                controleSchedule.MipMaDoubleHelper = controleSchedule.MipMA.ToString("F");
                controleSchedule.ProcessOrderNoIntHelper = controleSchedule.ProcessOrder_No.ToString();
                controleSchedule.WeightDoubleHelper = controleSchedule.Weight.ToString("F");
            }
        }
        private void FillStringHelpersHelper(ControlSchedules controlSchedules)
        {
            string hour, minute;
            if (controlSchedules.Time.Hour < 10) hour = "0" + controlSchedules.Time.Hour;
            else hour = controlSchedules.Time.Hour.ToString();

            if (controlSchedules.Time.Minute == 0) minute = "00";
            else if (controlSchedules.Time.Minute < 10) minute = "0" + controlSchedules.Time.Minute;
            else minute = controlSchedules.Time.Minute.ToString();

            controlSchedules.TimeStringHelper = string.Format("{0}:{1}", hour, minute);
        }

        #region RelayCommandMethods

        public async void RefreshAll()
        {
            ControlSchedulesList = await ModelGenerics.GetAll(new ControlSchedules());
            FillStringHelpers();
            _message.ShowToastNotification("Opdateret", "Kontrol Skema-tabellen er opdateret");
        }

        public async void RefreshLastTen()
        {
            ControlSchedulesList = await ModelGenerics.GetLastTenInDatabase(new ControlSchedules(), "ControlSchedule_ID", "Kontrol Skema");
            FillStringHelpers();
            _message.ShowToastNotification("Opdateret", "Kontrol Skema-tabellen er opdateret");
        }

        public void SaveAll()
        {
            _genericMethod.SaveAll(ControlSchedulesList, "ControlSchedule_ID", "Kontrol Skema", "Kontrol Skema ID");
        }

        public void DeleteItem()
        {
            _genericMethod.DeleteSelected(SelectedControlSchedule, new ControlSchedules(), CompleteControlSchedulesList, ControlSchedulesList, "ControlSchedule_ID", "Kontrol Skema", "Kontrol Skema ID");
        }

        public async void AddNewItem()
        {
            var latestControlSchedule = await ModelGenerics.GetLastTenInDatabase(new ControlSchedules(), "ControlSchedule_ID", "Kontrol Skema");
            NewControlSchedules.ControlSchedule_ID = latestControlSchedule.Last().ControlSchedule_ID + 1;
            
            if (ModelGenerics.CreateByObject(NewControlSchedules, "ControlSchedule_ID", "Kontrol Skema ID"))
            {
                Initialize();

                NewControlSchedules = new ControlSchedules
                {
                    ControlScheduleIdIntHelper = (ControlSchedulesList.Last().ControlSchedule_ID + 1).ToString(),
                    ProcessOrderNoIntHelper = ControlSchedulesList.Last().ProcessOrder_No.ToString()
                };
            }
            else
            {
                _message.ShowToastNotification("Fejl", "Forsøg venligst igen og gennemkig eventuelt for tastefejl");
            }
        }

        public void SelectParentItem(object obj)
        {
            SelectedControlScheduleId = _genericMethod.SelectParentItem((int)obj, ControlSchedulesList, "ControlSchedule_ID");
        }

        public void SortButtonClick(object id)
        {
            for (int i = 0; i <= 8; i++)
            {
                if (id.ToString() == _xamlBindings.ControlSchedulesHeaderList[i].Header)
                {
                    ControlSchedulesList = _genericMethod.Sort<ControlSchedules>(ControlSchedulesList, PropertyInfos[i].Name);
                    break;
                }
            }
        }

        #endregion

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
