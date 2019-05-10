using System.Threading.Tasks;

namespace UniBase.Model.K2.ButtonMethods
{
    class ProductionMethod
    {
        private Message message = new Message();
        
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
