using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace UniBase.Model.K2.ButtonMethods
{
    public class ProductionMethod : IManageButtonMethods
    {
        #region Fields
        private ObservableCollection<Productions> _completeProductionsList = ModelGenerics.GetAll(new Productions());

        private Message message = new Message();

        private int _selectedProductionId;
        private Productions _selectedProduction;

        private string _productionIdTextBoxOutput;
        private string _palletPutInStock0001TextBoxOutput;
        private string _tapmachineTextBoxOutput;
        private string _totalKegsPrPalletTextBoxOutput;
        private string _counterTextBoxOutput;
        private string _palletCounterTextBoxOutput;
        private string _batchDateTextBoxOutput;
        private string _processOrderNoTextBoxOutput;
        #endregion

        #region Filter
        public string ProductionIdTextBoxOutput
        {
            get { return _productionIdTextBoxOutput; }
            set { _productionIdTextBoxOutput = value; }
        }

        public string PalletPutInStock0001TextBoxOutput
        {
            get { return _palletPutInStock0001TextBoxOutput; }
            set { _palletPutInStock0001TextBoxOutput = value; }
        }

        public string TapmachineTextBoxOutput
        {
            get { return _tapmachineTextBoxOutput; }
            set { _tapmachineTextBoxOutput = value; }
        }

        public string TotalKegsPrPalletTextBoxOutput
        {
            get { return _totalKegsPrPalletTextBoxOutput; }
            set { _totalKegsPrPalletTextBoxOutput = value; }
        }

        public string CounterTextBoxOutput
        {
            get { return _counterTextBoxOutput; }
            set { _counterTextBoxOutput = value; }
        }

        public string PalletCounterTextBoxOutput
        {
            get { return _palletCounterTextBoxOutput; }
            set { _palletCounterTextBoxOutput = value; }
        }

        public string BatchDateTextBoxOutput
        {
            get { return _batchDateTextBoxOutput; }
            set { _batchDateTextBoxOutput = value; }
        }

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set { _processOrderNoTextBoxOutput = value; }
        }

        public int SelectedProductionId
        {
            get { return _selectedProductionId; }
            set { _selectedProductionId = value; }
        }

        public Productions SelectedProduction
        {
            get { return _selectedProduction; }
            set { _selectedProduction = value; }
        }
        #endregion


        #region ButtonMethods

        public void RefreshAll()
        {
            ManageTables.Instance.ProductionsList = ModelGenerics.GetAll(new Productions());

            Parallel.ForEach(ManageTables.Instance.ProductionsList, production =>
            {
                production.BatchDateStringHelper = production.BatchDate.ToString("yyyy/MM/dd");
            });
            message.ShowToastNotification("Opdateret", "Produktions-tabellen er opdateret");
        }

        public void RefreshLastTen()
        {
            ManageTables.Instance.ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());

            Parallel.ForEach(ManageTables.Instance.ProductionsList, production =>
            {
                production.BatchDateStringHelper = production.BatchDate.ToString("yyyy/MM/dd");
            });
            message.ShowToastNotification("Opdateret", "Produktions-tabellen er opdateret");
        }

        public void SaveAll()
        {
            ManageTables.Instance.ProductionsList = ModelGenerics.GetAll(new Productions());

            Parallel.ForEach(ManageTables.Instance.ProductionsList, production =>
            {
                InputValidator.CheckIfInputsAreValid(ref production);
            });

            Parallel.ForEach(ManageTables.Instance.ProductionsList, production =>
                {
                    ModelGenerics.UpdateByObjectAndId(production.Production_ID, production);
                });
            message.ShowToastNotification("Opdateret", "Produktions-tabellen er opdateret");
        }

        public void DeleteItem()
        {
            //if (SelectedFrontpage != null)
            //{
            //    //TODO Make deletion method
            //    Debug.WriteLine(SelectedFrontpage.ProcessOrder_No);
            //}
        }

        public void AddNewItem()
        {
            var ObjectToAdd = ManageTables.Instance.NewProductions;
            InputValidator.CheckIfInputsAreValid(ref ObjectToAdd);

            //Autofills

            if (ModelGenerics.CreateByObject(ObjectToAdd))
            {
                ManageTables.Instance.ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());

                ManageTables.Instance.NewProductions = new Productions
                {
                    ProcessOrder_No = ManageTables.Instance.ProductionsList.Last().ProcessOrder_No
                };
            }
            else
            {
                //error
            }
        }
        #endregion
    }
}
