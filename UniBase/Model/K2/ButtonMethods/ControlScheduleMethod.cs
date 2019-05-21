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

        private void Filter(int propIndex, string textBox)
        {
            _genericMethod.Filter(new ControlSchedules(), ControlSchedulesList, CompleteControlSchedulesList, PropertyInfos[propIndex].Name, textBox, Initialize, FillStringHelpers);
        }

        public void Initialize()
        {
            ControlSchedulesList = ModelGenerics.GetLastTenInDatabase(new ControlSchedules());
            FillStringHelpers();

            NewControlSchedules = new ControlSchedules
            {
                ControlScheduleIdIntHelper = (ControlSchedulesList.Last().ControlSchedule_ID + 1).ToString(),
                ProcessOrderNoIntHelper = ControlSchedulesList.Last().ProcessOrder_No.ToString()
            };
        }

        public void RefreshAll()
        {
            ControlSchedulesList = ModelGenerics.GetAll(new ControlSchedules());
            FillStringHelpers();
            _message.ShowToastNotification("Opdateret", "Kontrol Skema-tabellen er opdateret");
        }

        public void RefreshLastTen()
        {
            ControlSchedulesList = ModelGenerics.GetLastTenInDatabase(new ControlSchedules());
            FillStringHelpers();
            _message.ShowToastNotification("Opdateret", "Kontrol Skema-tabellen er opdateret");
        }

        public void SaveAll()
        {
            foreach (var controlSchedules in ControlSchedulesList)
            {
                ModelGenerics.UpdateByObjectAndId((int)controlSchedules.ControlSchedule_ID, controlSchedules);
            }
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
            if (ModelGenerics.CreateByObject(NewControlSchedules))
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
            int id = (int)obj;

            ControlSchedules del = ControlSchedulesList.First(d => d.ControlSchedule_ID == id);
            int index = ControlSchedulesList.IndexOf(del);

            SelectedControlScheduleId = index;
        }

        public void SortButtonClick(object id)
        {
            if (id.ToString() == _xamlBindings.ControlSchedulesHeaderList[0].Header)
                ControlSchedulesList = _genericMethod.Sort<ControlSchedules>(ControlSchedulesList,PropertyInfos[0].Name);
            else if (id.ToString() == _xamlBindings.ControlSchedulesHeaderList[1].Header)
                ControlSchedulesList = _genericMethod.Sort<ControlSchedules>(ControlSchedulesList,PropertyInfos[1].Name);
            else if (id.ToString() == _xamlBindings.ControlSchedulesHeaderList[2].Header)
                ControlSchedulesList = _genericMethod.Sort<ControlSchedules>(ControlSchedulesList,PropertyInfos[2].Name);
            else if (id.ToString() == _xamlBindings.ControlSchedulesHeaderList[3].Header)
                ControlSchedulesList = _genericMethod.Sort<ControlSchedules>(ControlSchedulesList,PropertyInfos[3].Name);
            else if (id.ToString() == _xamlBindings.ControlSchedulesHeaderList[4].Header)
                ControlSchedulesList = _genericMethod.Sort<ControlSchedules>(ControlSchedulesList,PropertyInfos[4].Name);
            else if (id.ToString() == _xamlBindings.ControlSchedulesHeaderList[5].Header)
                ControlSchedulesList = _genericMethod.Sort<ControlSchedules>(ControlSchedulesList,PropertyInfos[5].Name);
            else if (id.ToString() == _xamlBindings.ControlSchedulesHeaderList[6].Header)
                ControlSchedulesList = _genericMethod.Sort<ControlSchedules>(ControlSchedulesList,PropertyInfos[6].Name);
            else if (id.ToString() == _xamlBindings.ControlSchedulesHeaderList[7].Header)
                ControlSchedulesList = _genericMethod.Sort<ControlSchedules>(ControlSchedulesList,PropertyInfos[7].Name);
            else if (id.ToString() == _xamlBindings.ControlSchedulesHeaderList[8].Header)
                ControlSchedulesList = _genericMethod.Sort<ControlSchedules>(ControlSchedulesList,PropertyInfos[8].Name);
            else
                Debug.WriteLine("Error");
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
            string temp, temp2;
            if (controlSchedules.Time.Hour < 10) temp = "0" + controlSchedules.Time.Hour;
            else temp = controlSchedules.Time.Hour.ToString();

            if (controlSchedules.Time.Minute == 0) temp2 = "00";
            else if (controlSchedules.Time.Minute < 10) temp2 = "0" + controlSchedules.Time.Minute;
            else temp2 = controlSchedules.Time.Minute.ToString();

            controlSchedules.TimeStringHelper = string.Format("{0}:{1}", temp, temp2);
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
