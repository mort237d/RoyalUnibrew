using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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

        private Message message = new Message();

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
            GenerateHeaderLists();
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

        private List<bool> sorted = new List<bool> { true, false, false, false, false, false };

        //TODO FIX DRYYYYYYYY
        private ObservableCollection<Frontpages> SortWay(int index, Frontpages frontpages) 
        {
            var tempList = new ObservableCollection<Frontpages>();

            if (!sorted[index])
            {
                tempList = new ObservableCollection<Frontpages>(FrontpagesList.OrderBy(i => i.ProcessOrder_No));
                sorted[index] = true;
            }
            else
            {
                tempList = new ObservableCollection<Frontpages>(FrontpagesList.OrderByDescending(i => i.ProcessOrder_No));
                sorted[index] = false;
            }

            return tempList;
        }
        public void SortButtonClick(object id)
        {
            Debug.WriteLine("\n \t" + id.ToString(),"Click");

            switch (id.ToString())
            {
                case "ProcessOrdre Nr":
                    if (!sorted[0])
                    {
                        FrontpagesList = new ObservableCollection<Frontpages>(FrontpagesList.OrderBy(i => i.ProcessOrder_No));

                        for (int i = 0; i < sorted.Count-1; i++)
                        {
                            sorted[i] = false;
                        }
                        sorted[0] = true;
                    }
                    else
                    {
                        FrontpagesList = new ObservableCollection<Frontpages>(FrontpagesList.OrderByDescending(i => i.ProcessOrder_No));
                        sorted[0] = false;
                    }
                    break;
                case "Dato":
                    if (!sorted[0])
                    {
                        FrontpagesList = new ObservableCollection<Frontpages>(FrontpagesList.OrderBy(i => i.Date));

                        for (int i = 0; i < sorted.Count - 1; i++)
                        {
                            sorted[i] = false;
                        }
                        sorted[0] = true;
                    }
                    else
                    {
                        FrontpagesList = new ObservableCollection<Frontpages>(FrontpagesList.OrderByDescending(i => i.Date));
                        sorted[0] = false;
                    }
                    break;
                case "Færdigt Produkt Nr":
                    if (!sorted[0])
                    {
                        FrontpagesList = new ObservableCollection<Frontpages>(FrontpagesList.OrderBy(i => i.FinishedProduct_No));

                        for (int i = 0; i < sorted.Count - 1; i++)
                        {
                            sorted[i] = false;
                        }
                        sorted[0] = true;
                    }
                    else
                    {
                        FrontpagesList = new ObservableCollection<Frontpages>(FrontpagesList.OrderByDescending(i => i.FinishedProduct_No));
                        sorted[0] = false;
                    }
                    break;
                case "Kolonne":
                    if (!sorted[0])
                    {
                        FrontpagesList = new ObservableCollection<Frontpages>(FrontpagesList.OrderBy(i => i.Colunm));

                        for (int i = 0; i < sorted.Count - 1; i++)
                        {
                            sorted[i] = false;
                        }
                        sorted[0] = true;
                    }
                    else
                    {
                        FrontpagesList = new ObservableCollection<Frontpages>(FrontpagesList.OrderByDescending(i => i.Colunm));
                        sorted[0] = false;
                    }
                    break;
                case "Note":
                    if (!sorted[0])
                    {
                        FrontpagesList = new ObservableCollection<Frontpages>(FrontpagesList.OrderBy(i => i.Note));

                        for (int i = 0; i < sorted.Count - 1; i++)
                        {
                            sorted[i] = false;
                        }
                        sorted[0] = true;
                    }
                    else
                    {
                        FrontpagesList = new ObservableCollection<Frontpages>(FrontpagesList.OrderByDescending(i => i.Note));
                        sorted[0] = false;
                    }
                    break;
                case "Uge Nr":
                    if (!sorted[0])
                    {
                        FrontpagesList = new ObservableCollection<Frontpages>(FrontpagesList.OrderBy(i => i.Week_No));

                        for (int i = 0; i < sorted.Count - 1; i++)
                        {
                            sorted[i] = false;
                        }
                        sorted[0] = true;
                    }
                    else
                    {
                        FrontpagesList = new ObservableCollection<Frontpages>(FrontpagesList.OrderByDescending(i => i.Week_No));
                        sorted[0] = false;
                    }
                    break;
                default:
                    Debug.WriteLine("Nothing");
                    break;
            }
        }
        

        #region ButtonMethods

        #region FrontPageMethods

        public void RefreshFrontpages()
        {
            var tempList = ModelGenerics.GetAll(new Frontpages());
            FrontpagesList = new ObservableCollection<Frontpages>();
            if (tempList.Count > 10)
            {
                for (int i = tempList.Count-10; i < tempList.Count; i++)
                {
                    FrontpagesList.Add(tempList[i]);
                }

                message.ShowToastNotification("Opdateret", "Forside-tabellen er opdateret");
            }
        }
        public void SaveFrontpages()
        {
            Parallel.ForEach(_frontpagesList, frontpage =>
            {
                ModelGenerics.UpdateByObjectAndId(frontpage.ProcessOrder_No, frontpage);
            });
            message.ShowToastNotification("Gemt", "Forside-tabellen er gemt");
        }

        #endregion

        #region ControlRegistrationMethods

        public void RefreshControlRegistrations()
        {
            ControlRegistrationsList = ModelGenerics.GetAll(new ControlRegistrations());
            message.ShowToastNotification("Opdateret", "Kontrol Registrerings-tabellen er opdateret");
        }
        public void SaveControlRegistrations()
        {
            Parallel.ForEach(_controlRegistrationsList, controlRegistration =>
            {
                ModelGenerics.UpdateByObjectAndId(controlRegistration.ControlRegistration_ID, controlRegistration);
            });
            message.ShowToastNotification("Gemt", "Kontrol Registrerings-tabellen er gemt");
        }

        #endregion

        #region ControlScheduleMethods

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

                message.ShowToastNotification("Opdateret", "Kontrol Skema-tabellen er opdateret");
            }
        }
        public void SaveControlSchedules()
        {
            Parallel.ForEach(_controlSchedulesList, controlSchedules =>
            {
                ModelGenerics.UpdateByObjectAndId(controlSchedules.ControlSchedule_ID, controlSchedules);
            });
            message.ShowToastNotification("Gemt", "Kontrol Skema-tabellen er gemt");
        }

        #endregion

        #region ProductionMethods

        public void RefreshProductions()
        {
            ProductionsList = ModelGenerics.GetAll(new Productions());
            message.ShowToastNotification("Opdateret", "Produktions-tabellen er opdateret");
        }
        public void SaveProductions()
        {
            Parallel.ForEach(_productionsList, productions =>
            {
                ModelGenerics.UpdateByObjectAndId(productions.Production_ID, productions);
            });
            message.ShowToastNotification("Gemt", "Produktions-tabellen er gemt");
        }

        #endregion

        #region ShiftRegistrationMethods

        public void RefreshShiftRegistrations()
        {
            ShiftRegistrationsList = ModelGenerics.GetAll(new ShiftRegistrations());
            message.ShowToastNotification("Opdateret", "Vagt Registrerings-tabellen er opdateret");
        }
        public void SaveShiftRegistrations()
        {
            Parallel.ForEach(_shiftRegistrationsList, shiftRegistrations =>
            {
                ModelGenerics.UpdateByObjectAndId(shiftRegistrations.ShiftRegistration_ID, shiftRegistrations);
            });
            message.ShowToastNotification("Gemt", "Vagt Registrerings-tabellen er gemt");
        }

        #endregion

        #region TUMethods

        public void RefreshTUs()
        {
            TuList = ModelGenerics.GetAll(new TUs());
            message.ShowToastNotification("Opdateret", "TU-tabellen er opdateret");
        }
        public void SaveTUs()
        {
            Parallel.ForEach(_tuList, tus =>
            {
                ModelGenerics.UpdateByObjectAndId(tus.TU_ID, tus);
            });
            message.ShowToastNotification("Gemt", "TU-tabellen er gemt");
        }

        #endregion

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

        private void GenerateHeaderLists()
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
