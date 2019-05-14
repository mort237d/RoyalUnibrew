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

        private ObservableCollection<ControlRegistrations> _completeControlRegistrationsList = ModelGenerics.GetAll(new ControlRegistrations());

        private ObservableCollection<ControlRegistrations> _controlRegistrationsList;

        private ControlRegistrations _newControlRegistrationsToAdd = new ControlRegistrations();


        private Message _message = new Message();

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

                ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.ControlRegistration_ID.ToString().ToLower();
                    if (v.Contains(_controlRegistrationIdTextBoxOutput))
                    {
                        ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_controlRegistrationIdTextBoxOutput))
                {
                    ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
            }
        }

        public string TimeTextBoxOutput
        {
            get { return _timeTextBoxOutput; }
            set
            {
                _timeTextBoxOutput = value;


                ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.Time.ToString().ToLower();
                    if (v.Contains(_timeTextBoxOutput))
                    {
                        ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_timeTextBoxOutput))
                {
                    ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
            }
        }

        public string ProductionDateTextBoxOutput
        {
            get { return _productionDateTextBoxOutput; }
            set
            {
                _productionDateTextBoxOutput = value;


                ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.Production_Date.ToString().ToLower();
                    if (v.Contains(_productionDateTextBoxOutput))
                    {
                        ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_productionDateTextBoxOutput))
                {
                    ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
            }
        }

        public string CommentsOnChangedDateTextBoxOutput
        {
            get { return _commentsOnChangedDateTextBoxOutput; }
            set
            {
                _commentsOnChangedDateTextBoxOutput = value;


                ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.CommentsOnChangedDate.ToString().ToLower();
                    if (v.Contains(_commentsOnChangedDateTextBoxOutput))
                    {
                        ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_commentsOnChangedDateTextBoxOutput))
                {
                    ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
            }
        }

        public string ControlAlcoholSpearDispenserTextBoxOutput
        {
            get { return _controlAlcoholSpearDispenserTextBoxOutput; }
            set
            {
                _controlAlcoholSpearDispenserTextBoxOutput = value;


                ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.ControlAlcoholSpearDispenser.ToString().ToLower();
                    if (v.Contains(_controlAlcoholSpearDispenserTextBoxOutput))
                    {
                        ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_controlAlcoholSpearDispenserTextBoxOutput))
                {
                    ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
            }
        }

        public string CapNoTextBoxOutput
        {
            get { return _capNoTextBoxOutput; }
            set
            {
                _capNoTextBoxOutput = value;


                ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.CapNo.ToString().ToLower();
                    if (v.Contains(_capNoTextBoxOutput))
                    {
                        ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_capNoTextBoxOutput))
                {
                    ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
            }
        }

        public string EtiquetteNoTextBoxOutput
        {
            get { return _etiquetteNoTextBoxOutput; }
            set
            {
                _etiquetteNoTextBoxOutput = value;


                ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.EtiquetteNo.ToString().ToLower();
                    if (v.Contains(_etiquetteNoTextBoxOutput))
                    {
                        ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_etiquetteNoTextBoxOutput))
                {
                    ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
            }
        }

        public string KegSizeTextBoxOutput
        {
            get { return _kegSizeTextBoxOutput; }
            set
            {
                _kegSizeTextBoxOutput = value;


                ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.KegSize.ToString().ToLower();
                    if (v.Contains(_kegSizeTextBoxOutput))
                    {
                        ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_kegSizeTextBoxOutput))
                {
                    ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
            }
        }

        public string SignatureTextBoxOutput
        {
            get { return _signatureTextBoxOutput; }
            set
            {
                _signatureTextBoxOutput = value;


                ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.Signature.ToString().ToLower();
                    if (v.Contains(_signatureTextBoxOutput))
                    {
                        ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_signatureTextBoxOutput))
                {
                    ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
            }
        }

        public string FirstPalletDepalletizingTextBoxOutput
        {
            get { return _firstPalletDepalletizingTextBoxOutput; }
            set
            {
                _firstPalletDepalletizingTextBoxOutput = value;


                ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.FirstPalletDepalletizing.ToString().ToLower();
                    if (v.Contains(_firstPalletDepalletizingTextBoxOutput))
                    {
                        ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_firstPalletDepalletizingTextBoxOutput))
                {
                    ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
            }
        }

        public string LastPalletDepalletizingTextBoxOutput
        {
            get { return _lastPalletDepalletizingTextBoxOutput; }
            set
            {
                _lastPalletDepalletizingTextBoxOutput = value;
                
                ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.LastPalletDepalletizing.ToString().ToLower();
                    if (v.Contains(_lastPalletDepalletizingTextBoxOutput))
                    {
                        ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_lastPalletDepalletizingTextBoxOutput))
                {
                    ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
            }
        }

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;

                ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.ProcessOrder_No.ToString().ToLower();
                    if (v.Contains(_processOrderNoTextBoxOutput))
                    {
                        ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_processOrderNoTextBoxOutput))
                {
                    ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
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
                controlregistration.TimeStringHelper = controlregistration.Time.ToString(@"hh\:mm");  
            });
        }
        public void RefreshAll()
        {
            ControlRegistrationsList = ModelGenerics.GetAll(new ControlRegistrations());
            Parallel.ForEach(ControlRegistrationsList, controlregistration =>
            {
                controlregistration.FirstPalletDepalletizingStringHelper = controlregistration.FirstPalletDepalletizing.ToString("yyyy/MM/dd");
                controlregistration.LastPalletDepalletizingStringHelper = controlregistration.LastPalletDepalletizing.ToString("yyyy/MM/dd");
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
            instanceNewControlRegistrationsToAdd.Expiry_Date = DateTime.Now.AddDays(30);

            string kegSize = KegSize.Content.ToString().Remove(_kegSize.Content.ToString().Length-1);
            double.TryParse(kegSize, out double kegSizeDouble);
            instanceNewControlRegistrationsToAdd.KegSize = kegSizeDouble;

            if (ModelGenerics.CreateByObject(instanceNewControlRegistrationsToAdd))
            {
                Initialize();

                NewControlRegistrationsToAdd = new ControlRegistrations
                {
                    CapNo = ControlRegistrationsList.Last().CapNo,
                    EtiquetteNo = ControlRegistrationsList.Last().EtiquetteNo,
                    KegSize = ControlRegistrationsList.Last().KegSize,
                    ProcessOrder_No = ControlRegistrationsList.Last().ProcessOrder_No,
                    ControlAlcoholSpearDispenser = false
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
                //TODO Make deletion method
                Debug.WriteLine(SelectedControlRegistration.ControlRegistration_ID);
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
