using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using UniBase.Annotations;

namespace UniBase.Model.K2.ButtonMethods
{
    public class ControlRegistrationMethod : IManageButtonMethods
    {
        public ControlRegistrationMethod()
        {
            Initialize();

            foreach (var p in PropertyInfos)
            {
                Debug.WriteLine("\t \n " + p, "ControlRegistrationMethod");
            }
        }

        #region Fields

        private ComboBoxItem _kegSize = new ComboBoxItem();

        private ObservableCollection<ControlRegistrations> _completeControlRegistrationsList = ModelGenerics.GetAll(new ControlRegistrations());

        private ObservableCollection<ControlRegistrations> _controlRegistrationsList;

        private ControlRegistrations _newControlRegistrationsToAdd = new ControlRegistrations();

        private PropertyInfo[] PropertyInfos = typeof(ControlRegistrations).GetProperties();

        private Message _message = new Message();

        private GenericMethod _genericMethod = new GenericMethod();
        private XamlBindings _xamlBindings = new XamlBindings();

        private int _selectedControlRegistrationId;
        private ControlRegistrations _selectedControlRegistration;

        private string _controlRegistrationIdTextBoxOutput;
        private string _timeTextBoxOutput;
        private string _productionDateTextBoxOutput;
        private string _commentsOnChangedDateTextBoxOutput;
        private string _controlAlcoholSpearDispenserTextBoxOutput;
        private string _capNoTextBoxOutput;
        private string _etiquetteNoTextBoxOutput;
        private string _kegSizeTextBoxOutput;
        private string _signatureTextBoxOutput;
        private string _firstPalletDepalletizingTextBoxOutput;
        private string _lastPalletDepalletizingTextBoxOutput;
        private string _processOrderNoTextBoxOutput;
        #endregion


        #region Filter
      
        public string ControlRegistrationIdTextBoxOutput
        {
            get { return _controlRegistrationIdTextBoxOutput; }
            set
            {
                _controlRegistrationIdTextBoxOutput = value;

                _genericMethod.Filter(new ControlRegistrations(), ControlRegistrationsList, CompleteControlRegistrationsList, PropertyInfos[0].Name, _controlRegistrationIdTextBoxOutput, Initialize);
            }
        }

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;

                _genericMethod.Filter(new ControlRegistrations(), ControlRegistrationsList, CompleteControlRegistrationsList, PropertyInfos[1].Name, _processOrderNoTextBoxOutput, Initialize);
            }
        }

        public string TimeTextBoxOutput
        {
            get { return _timeTextBoxOutput; }
            set
            {
                _timeTextBoxOutput = value;

                _genericMethod.Filter(new ControlRegistrations(), ControlRegistrationsList, CompleteControlRegistrationsList, PropertyInfos[2].Name, _timeTextBoxOutput, Initialize);
            }
        }

        public string ProductionDateTextBoxOutput
        {
            get { return _productionDateTextBoxOutput; }
            set
            {
                _productionDateTextBoxOutput = value;

                _genericMethod.Filter(new ControlRegistrations(), ControlRegistrationsList, CompleteControlRegistrationsList, PropertyInfos[3].Name, _productionDateTextBoxOutput, Initialize);
            }
        }

        public string CommentsOnChangedDateTextBoxOutput
        {
            get { return _commentsOnChangedDateTextBoxOutput; }
            set
            {
                _commentsOnChangedDateTextBoxOutput = value;

                _genericMethod.Filter(new ControlRegistrations(), ControlRegistrationsList, CompleteControlRegistrationsList, PropertyInfos[4].Name, _commentsOnChangedDateTextBoxOutput, Initialize);
            }
        }

        public string ControlAlcoholSpearDispenserTextBoxOutput
        {
            get { return _controlAlcoholSpearDispenserTextBoxOutput; }
            set
            {
                _controlAlcoholSpearDispenserTextBoxOutput = value;

                _genericMethod.Filter(new ControlRegistrations(), ControlRegistrationsList, CompleteControlRegistrationsList, PropertyInfos[5].Name, _controlAlcoholSpearDispenserTextBoxOutput, Initialize);
            }
        }

        public string CapNoTextBoxOutput
        {
            get { return _capNoTextBoxOutput; }
            set
            {
                _capNoTextBoxOutput = value;

                _genericMethod.Filter(new ControlRegistrations(), ControlRegistrationsList, CompleteControlRegistrationsList, PropertyInfos[6].Name, _capNoTextBoxOutput, Initialize);
            }
        }

        public string EtiquetteNoTextBoxOutput
        {
            get { return _etiquetteNoTextBoxOutput; }
            set
            {
                _etiquetteNoTextBoxOutput = value;

                _genericMethod.Filter(new ControlRegistrations(), ControlRegistrationsList, CompleteControlRegistrationsList, PropertyInfos[7].Name, _etiquetteNoTextBoxOutput, Initialize);
            }
        }

        public string KegSizeTextBoxOutput
        {
            get { return _kegSizeTextBoxOutput; }
            set
            {
                _kegSizeTextBoxOutput = value;

                _genericMethod.Filter(new ControlRegistrations(), ControlRegistrationsList, CompleteControlRegistrationsList, PropertyInfos[8].Name, _kegSizeTextBoxOutput, Initialize);
            }
        }

        public string SignatureTextBoxOutput
        {
            get { return _signatureTextBoxOutput; }
            set
            {
                _signatureTextBoxOutput = value;

                _genericMethod.Filter(new ControlRegistrations(), ControlRegistrationsList, CompleteControlRegistrationsList, PropertyInfos[9].Name, _signatureTextBoxOutput, Initialize);
            }
        }

        public string FirstPalletDepalletizingTextBoxOutput
        {
            get { return _firstPalletDepalletizingTextBoxOutput; }
            set
            {
                _firstPalletDepalletizingTextBoxOutput = value;

                _genericMethod.Filter(new ControlRegistrations(), ControlRegistrationsList, CompleteControlRegistrationsList, PropertyInfos[10].Name, _firstPalletDepalletizingTextBoxOutput, Initialize);
            }
        }

        public string LastPalletDepalletizingTextBoxOutput
        {
            get { return _lastPalletDepalletizingTextBoxOutput; }
            set
            {
                _lastPalletDepalletizingTextBoxOutput = value;

                _genericMethod.Filter(new ControlRegistrations(), ControlRegistrationsList, CompleteControlRegistrationsList, PropertyInfos[11].Name, _lastPalletDepalletizingTextBoxOutput, Initialize);
            }
        }
        #endregion

        #region Properties
        public int SelectedControlRegistrationId
        {
            get { return _selectedControlRegistrationId; }
            set
            {
                _selectedControlRegistrationId = value;
                OnPropertyChanged();
            }
        }

        public ControlRegistrations SelectedControlRegistration
        {
            get { return _selectedControlRegistration; }
            set
            {
                _selectedControlRegistration = value;
                OnPropertyChanged();
            }
        }

        public ComboBoxItem KegSize
        {
            get { return _kegSize; }
            set
           {
                _kegSize = value; 
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ControlRegistrations> ControlRegistrationsList
        {
            get { return _controlRegistrationsList; }
            set
            {
                _controlRegistrationsList = value;
                OnPropertyChanged();
            }
        }

        public ControlRegistrations NewControlRegistrationsToAdd
        {
            get => _newControlRegistrationsToAdd;
            set
            {
                _newControlRegistrationsToAdd = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region ButtonMethods
        public void Initialize()
        {
            ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
            Parallel.ForEach(ControlRegistrationsList, controlregistration =>
            {
                controlregistration.FirstPalletDepalletizingStringHelper = controlregistration.FirstPalletDepalletizing.ToString("yyyy/MM/dd");
                controlregistration.LastPalletDepalletizingStringHelper = controlregistration.LastPalletDepalletizing.ToString("yyyy/MM/dd");
                controlregistration.ProductionsDateStringHelper = controlregistration.Production_Date.ToString("yyyy/MM/dd");
                controlregistration.TimeStringHelper = controlregistration.Time.ToString(@"hh\:mm");  
            });

            NewControlRegistrationsToAdd = new ControlRegistrations
            {
                CapNo = ControlRegistrationsList.Last().CapNo,
                EtiquetteNo = ControlRegistrationsList.Last().EtiquetteNo,
                KegSize = ControlRegistrationsList.Last().KegSize,
                ProcessOrder_No = ControlRegistrationsList.Last().ProcessOrder_No,
                ControlAlcoholSpearDispenser = false
            };
        }
        public void RefreshAll()
        {
            ControlRegistrationsList = ModelGenerics.GetAll(new ControlRegistrations());
            Parallel.ForEach(ControlRegistrationsList, controlregistration =>
            {
                controlregistration.FirstPalletDepalletizingStringHelper = controlregistration.FirstPalletDepalletizing.ToString("yyyy/MM/dd");
                controlregistration.LastPalletDepalletizingStringHelper = controlregistration.LastPalletDepalletizing.ToString("yyyy/MM/dd");
                controlregistration.ProductionsDateStringHelper = controlregistration.Production_Date.ToString("yyyy/MM/dd");
                controlregistration.TimeStringHelper = controlregistration.Time.ToString(@"hh\:mm");
            });
            _message.ShowToastNotification("Opdateret", "Kontrol Registrerings-tabellen er opdateret");
        }

        public void RefreshLastTen()
        {
            ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
            Parallel.ForEach(ControlRegistrationsList, controlregistration =>
            {
                controlregistration.FirstPalletDepalletizingStringHelper = controlregistration.FirstPalletDepalletizing.ToString("yyyy/MM/dd");
                controlregistration.LastPalletDepalletizingStringHelper = controlregistration.LastPalletDepalletizing.ToString("yyyy/MM/dd");
                controlregistration.ProductionsDateStringHelper = controlregistration.Production_Date.ToString("yyyy/MM/dd");
                controlregistration.TimeStringHelper = controlregistration.Time.ToString(@"hh\:mm");
            });
            _message.ShowToastNotification("Opdateret", "Kontrol Registrerings-tabellen er opdateret");
        }

        public void SaveAll()
        {
            Parallel.ForEach(ControlRegistrationsList, controlRegistration =>
            {
                InputValidator.CheckIfInputsAreValid(ref controlRegistration);
            });

            Parallel.ForEach(ControlRegistrationsList, controlRegistration =>
            {
                ModelGenerics.UpdateByObjectAndId((int)controlRegistration.ControlRegistration_ID, controlRegistration);
            });
            _message.ShowToastNotification("Gemt", "Kontrol Registrerings-tabellen er gemt");
        }

        public void AddNewItem()
        {
            var instanceNewControlRegistrationsToAdd = NewControlRegistrationsToAdd;
            InputValidator.CheckIfInputsAreValid(ref instanceNewControlRegistrationsToAdd);

            //todo Find  fix for expiry date
            instanceNewControlRegistrationsToAdd.FinishedProductNo = ModelGenerics.GetById(new Frontpages(), instanceNewControlRegistrationsToAdd.ProcessOrder_No).FinishedProduct_No;
            instanceNewControlRegistrationsToAdd.Expiry_Date = instanceNewControlRegistrationsToAdd.Production_Date.AddDays(ModelGenerics.GetById(new Products(), instanceNewControlRegistrationsToAdd.FinishedProductNo).BestBeforeDateLength);
            

            if (ModelGenerics.CreateByObject(instanceNewControlRegistrationsToAdd))
            {
                Initialize();

                NewControlRegistrationsToAdd = new ControlRegistrations
                {
                    CapNo = ControlRegistrationsList.Last().CapNo,
                    EtiquetteNo = ControlRegistrationsList.Last().EtiquetteNo,
                    KegSize = ControlRegistrationsList.Last().KegSize,
                    ProcessOrder_No = ControlRegistrationsList.Last().ProcessOrder_No,
                    ControlAlcoholSpearDispenser = false,
                    Production_Date = ControlRegistrationsList.Last().Production_Date,
                };

            }
            else
            {
                //error
            }
        }


        public void DeleteItem()
        {
            if (SelectedControlRegistration != null)
            {
                _genericMethod.DeleteSelected(SelectedControlRegistration, new ControlRegistrations(), CompleteControlRegistrationsList, ControlRegistrationsList, "ControlRegistration_ID");
                _message.ShowToastNotification("Slettet", "Kontrol Registrering slettet");
            }
            else
            {
                _message.ShowToastNotification("Fejl", "Marker venligst ønskede Kontrol Registrering, for at slette");
            }
        }
        #endregion


        public void ControlledClick(object id)
        {
            Debug.WriteLine(id.ToString());

            foreach (var cr in ControlRegistrationsList)
            {
                if (cr.ControlRegistration_ID == (int)id)
                {
                    if (cr.ControlAlcoholSpearDispenser)
                    {
                        cr.ControlAlcoholSpearDispenser = false;
                        break;
                    }
                    else
                    {
                        cr.ControlAlcoholSpearDispenser = true;
                        break;
                    }
                }
            }
        }

        public void ControlledClickAdd()
        {
            if (NewControlRegistrationsToAdd.ControlAlcoholSpearDispenser)
            {
                NewControlRegistrationsToAdd.ControlAlcoholSpearDispenser = false;
            }
            else
            {
                NewControlRegistrationsToAdd.ControlAlcoholSpearDispenser = true;
            }
        }
        
        public void SelectParentItem(object obj)
        {
            int id = (int)obj;

            ControlRegistrations del = ControlRegistrationsList.First(d => d.ControlRegistration_ID == id);
            int index = ControlRegistrationsList.IndexOf(del);

            SelectedControlRegistrationId = index;
        }

        public void SortButtonClick(object id)
        {
            if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[0].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,
                    PropertyInfos[0].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[1].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,
                    PropertyInfos[1].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[2].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,
                    PropertyInfos[2].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[3].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,
                    PropertyInfos[3].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[4].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,
                    PropertyInfos[4].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[5].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,
                    PropertyInfos[5].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[6].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,
                    PropertyInfos[6].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[7].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,
                    PropertyInfos[7].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[8].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,
                    PropertyInfos[8].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[9].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,
                    PropertyInfos[9].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[10].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,
                    PropertyInfos[10].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[11].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,
                    PropertyInfos[11].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[12].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,
                    PropertyInfos[12].Name);
            else
                Debug.WriteLine("Error");
        }

        public ObservableCollection<ControlRegistrations> CompleteControlRegistrationsList
        {
            get { return _completeControlRegistrationsList; }
            set { _completeControlRegistrationsList = value; }
        }
        #region SingleTon
        private static ControlRegistrationMethod _instance;
        private static object syncLock = new object();

        public static ControlRegistrationMethod Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ControlRegistrationMethod();
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
