using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace UniBase.Model.K2.ButtonMethods
{
    public class ProductionMethod
    {
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

        public void RefreshProductions()
        {
            ManageTables.Instance.ProductionsList = ModelGenerics.GetAll(new Productions());
            message.ShowToastNotification("Opdateret", "Produktions-tabellen er opdateret");
        }
        public void RefreshLastTenProductions()
        {
            ManageTables.Instance.ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());
            message.ShowToastNotification("Opdateret", "Produktions-tabellen er opdateret");
        }
        public void SaveProductions()
        {
            Parallel.ForEach(ManageTables.Instance.ProductionsList, productions =>
            {
                ModelGenerics.UpdateByObjectAndId(productions.Production_ID, productions);
            });
            message.ShowToastNotification("Gemt", "Produktions-tabellen er gemt");
        }
    }
}
