using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Notifications;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using ModelLibrary;
using UniBase.Annotations;

namespace UniBase.Model.K2
{
    public class ManageTables :INotifyPropertyChanged
    {
        #region Field

        private ObservableCollection<Frontpages> _frontpagesList;
        private ObservableCollection<ControlRegistrations> _controlRegistrationsList;
        private ObservableCollection<ControlSchedules> _controlSchedulesList;
        private ObservableCollection<Productions> _productionsList;
        private ObservableCollection<Products> _productsList;
        private ObservableCollection<ShiftRegistrations> _shiftRegistrationsList;
        private ObservableCollection<TUs> _tuList;



        #endregion

        #region Properties

        public Frontpages NewFrontpagesToAdd { get; set; } = new Frontpages();

        #region ObservableLists

        public ObservableCollection<Frontpages> FrontpagesList
        {
            get { return _frontpagesList; }
            set
            {
                _frontpagesList = value;
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
        public ObservableCollection<ControlSchedules> ControlSchedulesList
        {
            get { return _controlSchedulesList; }
            set
            {
                _controlSchedulesList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Productions> ProductionsList
        {
            get { return _productionsList; }
            set
            {
                _productionsList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Products> ProductsList
        {
            get { return _productsList; }
            set
            {
                _productsList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ShiftRegistrations> ShiftRegistrationsList
        {
            get { return _shiftRegistrationsList; }
            set
            {
                _shiftRegistrationsList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TUs> TuList
        {
            get { return _tuList; }
            set
            {
                _tuList = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #endregion

        #region PropLists

        public List<string> FrontPageProps { get; set; }
        public List<string> ProductProps { get; set; }
        public List<string> ProductionProps { get; set; }
        public List<string> ShiftRegistrationProps { get; set; }
        public List<string> TuProps { get; set; }
        public List<string> ControlRegistrationProps { get; set; }
        public List<string> ControlScheduleProps { get; set; }

        #endregion

        public ManageTables()
        {
            InitializeObservableCollections();
            CompleteLists();
        }

        public void InitializeObservableCollections()
        {
            FrontpagesList = GetLastTen(new Frontpages());
            ControlRegistrationsList = GetLastTen(new ControlRegistrations());
            ControlSchedulesList = GetLastTen(new ControlSchedules());
            ProductionsList = GetLastTen(new Productions());
            ProductsList = GetLastTen(new Products());
            ShiftRegistrationsList = GetLastTen(new ShiftRegistrations());
            TuList = GetLastTen(new TUs());
        }

        

        #region ButtonMethods
        
        

        public void RefreshFrontpages()
        {
            var TempList = ModelGenerics.GetAll(new Frontpages());
            FrontpagesList = new ObservableCollection<Frontpages>();
            if (TempList.Count > 10)
            {
                for (int i = TempList.Count-10; i < TempList.Count; i++)
                {
                    FrontpagesList.Add(TempList[i]);
                }

                ShowToastNotification("Opdateret", "Forside-tabellen er opdateret");
            }
        }
        public void SaveFrontpages()
        {
            Parallel.ForEach(_frontpagesList, frontpage =>
            {
                ModelGenerics.UpdateByObjectAndId(frontpage.ProcessOrder_No, frontpage);
            });
            ShowToastNotification("Gemt", "Forside-tabellen er gemt");
        }

        public void RefreshControlRegistrations()
        {
            ControlRegistrationsList = ModelGenerics.GetAll(new ControlRegistrations());
            ShowToastNotification("Opdateret", "Kontrol Registrerings-tabellen er opdateret");
        }
        public void SaveControlRegistrations()
        {
            Parallel.ForEach(_controlRegistrationsList, controlRegistration =>
            {
                ModelGenerics.UpdateByObjectAndId(controlRegistration.ControlRegistration_ID, controlRegistration);
            });
            ShowToastNotification("Gemt", "Kontrol Registrerings-tabellen er gemt");
        }

        public void RefreshControlSchedules()
        {
            var tempList = ModelGenerics.GetAll(new ControlSchedules());
            ControlSchedulesList = new ObservableCollection<ControlSchedules>();
            if (tempList.Count > 10)
            {
                for (int i = tempList.Count - 10; i < tempList.Count; i++)
                {
                    ControlSchedulesList.Add(tempList[i]);
                }

                ShowToastNotification("Opdateret", "Kontrol Skema-tabellen er opdateret");
            }
        }
        public void SaveControlSchedules()
        {
            Parallel.ForEach(_controlSchedulesList, controlSchedules =>
            {
                ModelGenerics.UpdateByObjectAndId(controlSchedules.ControlSchedule_ID, controlSchedules);
            });
            ShowToastNotification("Gemt", "Kontrol Skema-tabellen er gemt");
        }

        public void RefreshProductions()
        {
            ProductionsList = ModelGenerics.GetAll(new Productions());
            ShowToastNotification("Opdateret", "Produktions-tabellen er opdateret");
        }
        public void SaveProductions()
        {
            Parallel.ForEach(_productionsList, productions =>
            {
                ModelGenerics.UpdateByObjectAndId(productions.Production_ID, productions);
            });
            ShowToastNotification("Gemt", "Produktions-tabellen er gemt");
        }

        public void RefreshShiftRegistrations()
        {
            ShiftRegistrationsList = ModelGenerics.GetAll(new ShiftRegistrations());
            ShowToastNotification("Opdateret", "Vagt Registrerings-tabellen er opdateret");
        }
        public void SaveShiftRegistrations()
        {
            Parallel.ForEach(_shiftRegistrationsList, shiftRegistrations =>
            {
                ModelGenerics.UpdateByObjectAndId(shiftRegistrations.ShiftRegistration_ID, shiftRegistrations);
            });
            ShowToastNotification("Gemt", "Vagt Registrerings-tabellen er gemt");
        }

        public void RefreshTUs()
        {
            TuList = ModelGenerics.GetAll(new TUs());
            ShowToastNotification("Opdateret", "TU-tabellen er opdateret");
        }
        public void SaveTUs()
        {
            Parallel.ForEach(_tuList, tus =>
            {
                ModelGenerics.UpdateByObjectAndId(tus.TU_ID, tus);
            });
            ShowToastNotification("Gemt", "TU-tabellen er gemt");
        }

        public void AddNewFrontpages()
        {
            //todo finish this
            NewFrontpagesToAdd.Product = new Products();
            NewFrontpagesToAdd.Production = new Productions();
            NewFrontpagesToAdd.ControlSchedule = new ControlSchedules();
            NewFrontpagesToAdd.ControlRegistration = new ControlRegistrations();
            NewFrontpagesToAdd.ShiftRegistration = new ShiftRegistrations();
            NewFrontpagesToAdd.TU = new TUs();

            //Checks whether any of the properties are null if any are returns true
            bool isNull = NewFrontpagesToAdd.GetType().GetProperties().All(p => p.GetValue(NewFrontpagesToAdd) != null);

            if (!isNull)
            {
                if (ModelGenerics.CreateByObject(NewFrontpagesToAdd))
                {
                    _frontpagesList.Add(NewFrontpagesToAdd);
                    NewFrontpagesToAdd = new Frontpages();
                }
                else
                {

                }
            }
        }
        #endregion

        private void ShowToastNotification(string title, string stringContent)
        {
            ToastNotifier toastNotifier = ToastNotificationManager.CreateToastNotifier();
            Windows.Data.Xml.Dom.XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            Windows.Data.Xml.Dom.XmlNodeList toastNodeList = toastXml.GetElementsByTagName("text");
            toastNodeList.Item(0).AppendChild(toastXml.CreateTextNode(title));
            toastNodeList.Item(1).AppendChild(toastXml.CreateTextNode(stringContent));
            Windows.Data.Xml.Dom.IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            Windows.Data.Xml.Dom.XmlElement audio = toastXml.CreateElement("audio");
            audio.SetAttribute("src", "ms-winsoundevent:Notification.SMS");

            ToastNotification toast = new ToastNotification(toastXml);
            toast.ExpirationTime = DateTime.Now.AddSeconds(4);
            toastNotifier.Show(toast);
        }

        private ObservableCollection<T> GetLastTen<T>(T type)
        {
            var tempList = ModelGenerics.GetAll(type);
            ObservableCollection<T> result = new ObservableCollection<T>();

            if (tempList.Count > 10)
            {
                for (int i = tempList.Count - 10; i < tempList.Count; i++)
                {
                    result.Add(tempList[i]);
                }
            }
            else
            {
                result = tempList;
            }

            return result;
        }

        private void CompleteLists()
        {
            ControlRegistrationProps = new List<string>{"Kontrol Registrering ID", "Tid", "Produktionsdato", "Kommentar vedr. ændret dato", "Kontrol af sprit på anstikker", "Hætte Nr", "Etikette Nr", "Fustage", "Signatur", "Første palle depalleteret" , "Sidste palle depalleteret" };
            ControlScheduleProps = new List<string>{"Kontrol skema ID","Klokkeslæt", "Vægt kontrol", "Kontrol af fustage", "LudKoncentration", "Mip MA", "Signatur operatør", "Note"};
            FrontPageProps = new List<string> {"ProcessOrdre Nr", "Dato", "Færdigt Produkt Nr", "Kolonne", "Note", "Uge Nr"};
            ProductionProps = new List<string>{"Produktions ID","Paller lagt på lager 0001", "Tappemaskine", "Antal fustager pr. palle", "Tæller", "Palle tæller", "Batchdato"};
            ProductProps = new List<string>{"Færdigvarer Nr", "Produkt Navn", "Antal dage før udløbsdato"};
            ShiftRegistrationProps = new List<string>{"Vagt registrerings ID","Start tidspunkt", "Slut tidspunkt", "Pauser", "Total timer", "Bemanding", "Initialer"};
            TuProps = new List<string>{"TU ID", "Første dag start TU", "Første dag slut TU", "Første dag TU i alt", "Anden dag start TU", "Anden dag slut TU", "Anden dag TU i alt", "Tredje dag start TU", "Tredje dag slut TU", "Tredje dag TU i alt" };
        }


        #region SingleTon
        private static ManageTables _instance;
        private static object syncLock = new object();

        public static ManageTables Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ManageTables();
                        }
                    }
                }

                return _instance;
            }
        }
        
        #endregion

        #region INotifyPropertiesChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
