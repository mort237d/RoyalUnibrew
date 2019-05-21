using System;
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
        }

        #region Fields

        private ComboBoxItem _kegSize = new ComboBoxItem();

        private ObservableCollection<ControlRegistrations> _completeControlRegistrationsList;

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
        private string _expiryTextBoxOutput;
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

                Filter(0,_controlRegistrationIdTextBoxOutput);
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

                Filter(2,_timeTextBoxOutput);
            }
        }

        public string ProductionDateTextBoxOutput
        {
            get { return _productionDateTextBoxOutput; }
            set
            {
                _productionDateTextBoxOutput = value;

                Filter(3,_productionDateTextBoxOutput);
            }
        }

        public string ExpiryTextBoxOutput
        {
            get { return _expiryTextBoxOutput; }
            set
            {
                _expiryTextBoxOutput = value;

                Filter(4,_expiryTextBoxOutput);
            }
        }

        public string CommentsOnChangedDateTextBoxOutput
        {
            get { return _commentsOnChangedDateTextBoxOutput; }
            set
            {
                _commentsOnChangedDateTextBoxOutput = value;

                Filter(5,_commentsOnChangedDateTextBoxOutput);
            }
        }

        public string ControlAlcoholSpearDispenserTextBoxOutput
        {
            get { return _controlAlcoholSpearDispenserTextBoxOutput; }
            set
            {
                _controlAlcoholSpearDispenserTextBoxOutput = value;

                Filter(6,_controlAlcoholSpearDispenserTextBoxOutput);
            }
        }

        public string CapNoTextBoxOutput
        {
            get { return _capNoTextBoxOutput; }
            set
            {
                _capNoTextBoxOutput = value;

                Filter(7,_capNoTextBoxOutput);
            }
        }

        public string EtiquetteNoTextBoxOutput
        {
            get { return _etiquetteNoTextBoxOutput; }
            set
            {
                _etiquetteNoTextBoxOutput = value;

                Filter(8, _etiquetteNoTextBoxOutput);
            }
        }

        public string KegSizeTextBoxOutput
        {
            get { return _kegSizeTextBoxOutput; }
            set
            {
                _kegSizeTextBoxOutput = value;

                Filter(9, _kegSizeTextBoxOutput);
            }
        }

        public string SignatureTextBoxOutput
        {
            get { return _signatureTextBoxOutput; }
            set
            {
                _signatureTextBoxOutput = value;

                Filter(10, _signatureTextBoxOutput);
            }
        }

        public string FirstPalletDepalletizingTextBoxOutput
        {
            get { return _firstPalletDepalletizingTextBoxOutput; }
            set
            {
                _firstPalletDepalletizingTextBoxOutput = value;

                Filter(11, _firstPalletDepalletizingTextBoxOutput);
            }
        }

        public string LastPalletDepalletizingTextBoxOutput
        {
            get { return _lastPalletDepalletizingTextBoxOutput; }
            set
            {
                _lastPalletDepalletizingTextBoxOutput = value;

                Filter(12, _lastPalletDepalletizingTextBoxOutput);
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
        private void Filter(int propIndex, string textBox)
        {
            _genericMethod.Filter(new ControlRegistrations(), ControlRegistrationsList, CompleteControlRegistrationsList, PropertyInfos[propIndex].Name, textBox, Initialize, FillStringHelpers);
        }

        public async void Initialize()
        {
            ControlRegistrationsList = await ModelGenerics.GetLastTenInDatabase(new ControlRegistrations());
            _completeControlRegistrationsList = await ModelGenerics.GetAll(new ControlRegistrations());

            FillStringHelpers();
            GenerateNewControlRegistrationToAdd();
        }
        
        public async void RefreshAll()
        {
            ControlRegistrationsList = await ModelGenerics.GetAll(new ControlRegistrations());
            
            FillStringHelpers();

            _message.ShowToastNotification("Opdateret", "Kontrol Registrerings-tabellen er opdateret");
        }

        public async void RefreshLastTen()
        {
            ControlRegistrationsList = await ModelGenerics.GetLastTenInDatabase(new ControlRegistrations());
            
            FillStringHelpers();

            _message.ShowToastNotification("Opdateret", "Kontrol Registrerings-tabellen er opdateret");
        }

        public void SaveAll()
        {
            foreach (var controlRegistration in ControlRegistrationsList)
            {
                ModelGenerics.UpdateByObjectAndId((int)controlRegistration.ControlRegistration_ID, controlRegistration);
            }

            _message.ShowToastNotification("Gemt", "Kontrol Registrerings-tabellen er gemt");
        }

        public void AddNewItem()
        {
            if (ModelGenerics.CreateByObject(NewControlRegistrationsToAdd))
            {
                Initialize();
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

            SelectParentItem(id);
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
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,PropertyInfos[0].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[1].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,PropertyInfos[1].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[2].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,PropertyInfos[2].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[3].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,PropertyInfos[3].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[4].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,PropertyInfos[4].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[5].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,PropertyInfos[5].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[6].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,PropertyInfos[6].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[7].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,PropertyInfos[7].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[8].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,PropertyInfos[8].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[9].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,PropertyInfos[9].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[10].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,PropertyInfos[10].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[11].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,PropertyInfos[11].Name);
            else if (id.ToString() == _xamlBindings.ControlRegistrationsHeaderList[12].Header)
                ControlRegistrationsList = _genericMethod.Sort<ControlRegistrations>(ControlRegistrationsList,PropertyInfos[12].Name);
            else
                Debug.WriteLine("Error");
        }

        public ObservableCollection<ControlRegistrations> CompleteControlRegistrationsList
        {
            get { return _completeControlRegistrationsList; }
            set { _completeControlRegistrationsList = value; }
        }

        
        private void FillStringHelpers()
        {
            foreach (var controlregistration in ControlRegistrationsList)
            {
                controlregistration.FirstPalletDepalletizingStringHelper = controlregistration.FirstPalletDepalletizing.ToString("yyyy/MM/dd");
                controlregistration.LastPalletDepalletizingStringHelper = controlregistration.LastPalletDepalletizing.ToString("yyyy/MM/dd");
                controlregistration.ProductionsDateStringHelper = controlregistration.Production_Date.ToString("yyyy/MM/dd");
                controlregistration.ExpiryDateStringHelper = controlregistration.Expiry_Date.ToString("yyyy/MM/dd");
                controlregistration.CapNoIntHelper = controlregistration.CapNo.ToString();
                controlregistration.EtiquetteNoIntHelper = controlregistration.EtiquetteNo.ToString();
                controlregistration.ControlRegistrationIdIntHelper = controlregistration.ControlRegistration_ID.ToString();
                controlregistration.ProcessOrderNoIntHelper = controlregistration.ProcessOrder_No.ToString();
                FillStringHelpersHelper(controlregistration);
                FillJegSize(controlregistration);
            }
        }

        private static void FillJegSize(ControlRegistrations controlregistration)
        {
            if (controlregistration.KegSize == "20L")
            {
                controlregistration.KegSizeIndex = 0;
            }
            else if (controlregistration.KegSize == "25L")
            {
                controlregistration.KegSizeIndex = 1;
            }
            else if (controlregistration.KegSize == "30L")
            {
                controlregistration.KegSizeIndex = 2;
            }
        }

        private void FillStringHelpersHelper(ControlRegistrations controlRegistrations)
        {
            string temp, temp2;
            if (controlRegistrations.Time.Hours < 10) temp = "0" + controlRegistrations.Time.Hours;
            else temp = controlRegistrations.Time.Hours.ToString();

            if (controlRegistrations.Time.Minutes == 0) temp2 = "00";
            else if (controlRegistrations.Time.Minutes < 10) temp2 = "0" + controlRegistrations.Time.Minutes;
            else temp2 = controlRegistrations.Time.Minutes.ToString();

            controlRegistrations.TimeStringHelper = string.Format("{0}:{1}", temp, temp2);
        }
        private void GenerateNewControlRegistrationToAdd()
        {
            NewControlRegistrationsToAdd = new ControlRegistrations
            {
                ControlRegistrationIdIntHelper = (ControlRegistrationsList.Last().ControlRegistration_ID + 1).ToString(),
                CapNoIntHelper = ControlRegistrationsList.Last().CapNo.ToString(),
                EtiquetteNoIntHelper = ControlRegistrationsList.Last().EtiquetteNo.ToString(),
                KegSize = ControlRegistrationsList.Last().KegSize,
                ProcessOrderNoIntHelper = ControlRegistrationsList.Last().ProcessOrder_No.ToString(),
                ControlAlcoholSpearDispenser = false
            };
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
