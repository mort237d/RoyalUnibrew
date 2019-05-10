using System.Threading.Tasks;

namespace UniBase.Model.K2.ButtonMethods
{
    public class ShiftRegistrationMethod
    {
        private Message message = new Message();

        public void RefreshShiftRegistrations()
        {
            ManageTables.Instance.ShiftRegistrationsList = ModelGenerics.GetAll(new ShiftRegistrations());
            message.ShowToastNotification("Opdateret", "Vagt Registrerings-tabellen er opdateret");
        }
        public void RefreshLastTenShiftRegistrations()
        {
            ManageTables.Instance.ShiftRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ShiftRegistrations());
            message.ShowToastNotification("Opdateret", "Vagt Registrerings-tabellen er opdateret");
        }
        public void SaveShiftRegistrations()
        {
            Parallel.ForEach(ManageTables.Instance.ShiftRegistrationsList, shiftRegistrations =>
            {
                ModelGenerics.UpdateByObjectAndId(shiftRegistrations.ShiftRegistration_ID, shiftRegistrations);
            });
            message.ShowToastNotification("Gemt", "Vagt Registrerings-tabellen er gemt");
        }
    }
}
