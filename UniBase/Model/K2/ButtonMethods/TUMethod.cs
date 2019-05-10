using System.Threading.Tasks;

namespace UniBase.Model.K2.ButtonMethods
{
    class TUMethod
    {
        private Message message = new Message();

        public void RefreshTUs()
        {
            ManageTables.Instance.TuList = ModelGenerics.GetAll(new TUs());
            message.ShowToastNotification("Opdateret", "TU-tabellen er opdateret");
        }
        public void RefreshLastTenTUs()
        {
            ManageTables.Instance.TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
            message.ShowToastNotification("Opdateret", "TU-tabellen er opdateret");
        }
        public void SaveTUs()
        {
            Parallel.ForEach(ManageTables.Instance.TuList, tus =>
            {
                ModelGenerics.UpdateByObjectAndId(tus.TU_ID, tus);
            });
            message.ShowToastNotification("Gemt", "TU-tabellen er gemt");
        }
    }
}
