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
    public class ControlRegistrationMethod : INotifyPropertyChanged
    {
        private ObservableCollection<ControlRegistrations> _completeControlRegistrationsList = ModelGenerics.GetAll(new ControlRegistrations());

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

        public string ControlRegistrationIdTextBoxOutput
        {
            get { return _controlRegistrationIdTextBoxOutput; }
            set
            {
                _controlRegistrationIdTextBoxOutput = value;

                ManageTables.Instance.ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.ControlRegistration_ID.ToString().ToLower();
                    if (v.Contains(_controlRegistrationIdTextBoxOutput))
                    {
                        ManageTables.Instance.ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_controlRegistrationIdTextBoxOutput))
                {
                    ManageTables.Instance.ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
            }
        }

        public string TimeTextBoxOutput
        {
            get { return _timeTextBoxOutput; }
            set
            {
                _timeTextBoxOutput = value;


                ManageTables.Instance.ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.Time.ToString().ToLower();
                    if (v.Contains(_timeTextBoxOutput))
                    {
                        ManageTables.Instance.ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_timeTextBoxOutput))
                {
                    ManageTables.Instance.ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
            }
        }

        public string ProductionDateTextBoxOutput
        {
            get { return _productionDateTextBoxOutput; }
            set
            {
                _productionDateTextBoxOutput = value;


                ManageTables.Instance.ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.Production_Date.ToString().ToLower();
                    if (v.Contains(_productionDateTextBoxOutput))
                    {
                        ManageTables.Instance.ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_productionDateTextBoxOutput))
                {
                    ManageTables.Instance.ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
            }
        }

        public string CommentsOnChangedDateTextBoxOutput
        {
            get { return _commentsOnChangedDateTextBoxOutput; }
            set
            {
                _commentsOnChangedDateTextBoxOutput = value;


                ManageTables.Instance.ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.CommentsOnChangedDate.ToString().ToLower();
                    if (v.Contains(_commentsOnChangedDateTextBoxOutput))
                    {
                        ManageTables.Instance.ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_commentsOnChangedDateTextBoxOutput))
                {
                    ManageTables.Instance.ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
            }
        }

        public string ControlAlcoholSpearDispenserTextBoxOutput
        {
            get { return _controlAlcoholSpearDispenserTextBoxOutput; }
            set
            {
                _controlAlcoholSpearDispenserTextBoxOutput = value;


                ManageTables.Instance.ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.ControlAlcoholSpearDispenser.ToString().ToLower();
                    if (v.Contains(_controlAlcoholSpearDispenserTextBoxOutput))
                    {
                        ManageTables.Instance.ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_controlAlcoholSpearDispenserTextBoxOutput))
                {
                    ManageTables.Instance.ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
            }
        }

        public string CapNoTextBoxOutput
        {
            get { return _capNoTextBoxOutput; }
            set
            {
                _capNoTextBoxOutput = value;


                ManageTables.Instance.ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.CapNo.ToString().ToLower();
                    if (v.Contains(_capNoTextBoxOutput))
                    {
                        ManageTables.Instance.ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_capNoTextBoxOutput))
                {
                    ManageTables.Instance.ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
            }
        }

        public string EtiquetteNoTextBoxOutput
        {
            get { return _etiquetteNoTextBoxOutput; }
            set
            {
                _etiquetteNoTextBoxOutput = value;


                ManageTables.Instance.ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.EtiquetteNo.ToString().ToLower();
                    if (v.Contains(_etiquetteNoTextBoxOutput))
                    {
                        ManageTables.Instance.ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_etiquetteNoTextBoxOutput))
                {
                    ManageTables.Instance.ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
            }
        }

        public string KegSizeTextBoxOutput
        {
            get { return _kegSizeTextBoxOutput; }
            set
            {
                _kegSizeTextBoxOutput = value;


                ManageTables.Instance.ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.KegSize.ToString().ToLower();
                    if (v.Contains(_kegSizeTextBoxOutput))
                    {
                        ManageTables.Instance.ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_kegSizeTextBoxOutput))
                {
                    ManageTables.Instance.ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
            }
        }

        public string SignatureTextBoxOutput
        {
            get { return _signatureTextBoxOutput; }
            set
            {
                _signatureTextBoxOutput = value;


                ManageTables.Instance.ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.Signature.ToString().ToLower();
                    if (v.Contains(_signatureTextBoxOutput))
                    {
                        ManageTables.Instance.ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_signatureTextBoxOutput))
                {
                    ManageTables.Instance.ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
            }
        }

        public string FirstPalletDepalletizingTextBoxOutput
        {
            get { return _firstPalletDepalletizingTextBoxOutput; }
            set
            {
                _firstPalletDepalletizingTextBoxOutput = value;


                ManageTables.Instance.ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.FirstPalletDepalletizing.ToString().ToLower();
                    if (v.Contains(_firstPalletDepalletizingTextBoxOutput))
                    {
                        ManageTables.Instance.ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_firstPalletDepalletizingTextBoxOutput))
                {
                    ManageTables.Instance.ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
            }
        }

        public string LastPalletDepalletizingTextBoxOutput
        {
            get { return _lastPalletDepalletizingTextBoxOutput; }
            set
            {
                _lastPalletDepalletizingTextBoxOutput = value;
                
                ManageTables.Instance.ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.LastPalletDepalletizing.ToString().ToLower();
                    if (v.Contains(_lastPalletDepalletizingTextBoxOutput))
                    {
                        ManageTables.Instance.ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_lastPalletDepalletizingTextBoxOutput))
                {
                    ManageTables.Instance.ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
            }
        }

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;

                ManageTables.Instance.ControlRegistrationsList.Clear();

                foreach (var f in _completeControlRegistrationsList)
                {
                    var v = f.ProcessOrder_No.ToString().ToLower();
                    if (v.Contains(_processOrderNoTextBoxOutput))
                    {
                        ManageTables.Instance.ControlRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_processOrderNoTextBoxOutput))
                {
                    ManageTables.Instance.ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                }
            }
        }

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

        public void RefreshControlRegistrations()
        {
            ManageTables.Instance.ControlRegistrationsList = ModelGenerics.GetAll(new ControlRegistrations());
            _message.ShowToastNotification("Opdateret", "Kontrol Registrerings-tabellen er opdateret");
        }
        public void RefreshLastTenControlRegistrations()
        {
            ManageTables.Instance.ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
            _message.ShowToastNotification("Opdateret", "Kontrol Registrerings-tabellen er opdateret");
        }
        public void SaveControlRegistrations()
        {
            Parallel.ForEach(ManageTables.Instance.ControlRegistrationsList, controlRegistration =>
            {
                ModelGenerics.UpdateByObjectAndId(controlRegistration.ControlRegistration_ID, controlRegistration);
            });
            _message.ShowToastNotification("Gemt", "Kontrol Registrerings-tabellen er gemt");
        }
        public void DeleteControlRegistration()
        {
            if (SelectedControlRegistration != null)
            {
                //TODO Make deletion method
                Debug.WriteLine(SelectedControlRegistration.ControlRegistration_ID);
            }
        }

        public void ControlledClick(object id)
        {
            Debug.WriteLine(id.ToString());

            foreach (var cr in ManageTables.Instance.ControlRegistrationsList)
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
            if (ManageTables.Instance.NewControlRegistrationsToAdd.ControlAlcoholSpearDispenser)
            {
                ManageTables.Instance.NewControlRegistrationsToAdd.ControlAlcoholSpearDispenser = false;
            }
            else
            {
                ManageTables.Instance.NewControlRegistrationsToAdd.ControlAlcoholSpearDispenser = true;
            }
        }

        public void AddNewControlRegistrations()
        {
            var instanceNewControlRegistrationsToAdd = ManageTables.Instance.NewControlRegistrationsToAdd;
            InputValidator.CheckIfInputsAreValid(ref instanceNewControlRegistrationsToAdd);

            //Checks whether any of the properties are null if any are returns true
            bool isNull = instanceNewControlRegistrationsToAdd.GetType().GetProperties().All(p => p.GetValue(instanceNewControlRegistrationsToAdd) == null);

            if (!isNull)
            {
                ManageTables.Instance.ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                instanceNewControlRegistrationsToAdd.ControlRegistration_ID = ManageTables.Instance.ControlRegistrationsList.Last().ControlRegistration_ID + 1;
                var temp = ModelGenerics.GetById(new ControlRegistrations(), instanceNewControlRegistrationsToAdd.ProcessOrder_No);
                //TODO Hvad er det her Lucas?ArrowDown
                //var temp2 = ModelGenerics.GetById(new Products(), temp.FinishedProduct_No);
                //instanceNewControlRegistrationsToAdd.Expiry_Date = new DateTime(temp2.BestBeforeDateLength);

                if (ModelGenerics.CreateByObject(instanceNewControlRegistrationsToAdd))
                {
                    ManageTables.Instance.ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                    instanceNewControlRegistrationsToAdd = new ControlRegistrations();
                    instanceNewControlRegistrationsToAdd.CapNo = ManageTables.Instance.ControlRegistrationsList.Last().CapNo;
                    instanceNewControlRegistrationsToAdd.EtiquetteNo = ManageTables.Instance.ControlRegistrationsList.Last().EtiquetteNo;
                    instanceNewControlRegistrationsToAdd.ControlRegistration_ID = ManageTables.Instance.ControlRegistrationsList.Last().ControlRegistration_ID + 1;
                    instanceNewControlRegistrationsToAdd.KegSize = ManageTables.Instance.ControlRegistrationsList.Last().KegSize;
                    instanceNewControlRegistrationsToAdd.ProcessOrder_No = ManageTables.Instance.ControlRegistrationsList.Last().ProcessOrder_No;
                    instanceNewControlRegistrationsToAdd.ControlAlcoholSpearDispenser = false;

                }
                else
                {
                    //error
                }
            }
        }

        public void SelectParentItem(object obj)
        {
            int id = (int)obj;

            ControlRegistrations del = ManageTables.Instance.ControlRegistrationsList.First(d => d.ControlRegistration_ID == id);
            int index = ManageTables.Instance.ControlRegistrationsList.IndexOf(del);

            SelectedControlRegistrationId = index;
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
