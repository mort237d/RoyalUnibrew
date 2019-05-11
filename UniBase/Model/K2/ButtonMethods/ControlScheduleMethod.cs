using System.Threading.Tasks;

namespace UniBase.Model.K2.ButtonMethods
{
    public class ControlScheduleMethod
    {
        private Message message = new Message();

        public void RefreshControlSchedules()
        {
            ManageTables.Instance.ControlSchedulesList = ModelGenerics.GetAll(new ControlSchedules());
            message.ShowToastNotification("Opdateret", "Kontrol Skema-tabellen er opdateret");
        }
        public void RefreshLastTenControlSchedules()
        {
            ManageTables.Instance.ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
            message.ShowToastNotification("Opdateret", "Kontrol Skema-tabellen er opdateret");
        }
        public void SaveControlSchedules()
        {
            Parallel.ForEach(ManageTables.Instance.ControlSchedulesList, controlSchedules =>
            {
                ModelGenerics.UpdateByObjectAndId(controlSchedules.ControlSchedule_ID, controlSchedules);
            });
            message.ShowToastNotification("Gemt", "Kontrol Skema-tabellen er gemt");
        }
    }
}
