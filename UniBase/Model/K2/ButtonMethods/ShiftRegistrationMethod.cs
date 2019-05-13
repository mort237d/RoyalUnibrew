using System.Linq;
using System.Threading.Tasks;

namespace UniBase.Model.K2.ButtonMethods
{
    public class ShiftRegistrationMethod : IManageButtonMethods
    {
        private Message message = new Message();

        public void RefreshAll()
        {
            ManageTables.Instance.ShiftRegistrationsList = ModelGenerics.GetAll(new ShiftRegistrations());
            message.ShowToastNotification("Opdateret", "Vagt Registrerings-tabellen er opdateret");
        }

        public void RefreshLastTen()
        {
            ManageTables.Instance.ShiftRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ShiftRegistrations());
            message.ShowToastNotification("Opdateret", "Vagt Registrerings-tabellen er opdateret");
        }

        public void SaveAll()
        {
            Parallel.ForEach(ManageTables.Instance.ShiftRegistrationsList, shiftRegistrations =>
            {
                ModelGenerics.UpdateByObjectAndId(shiftRegistrations.ShiftRegistration_ID, shiftRegistrations);
            });
            message.ShowToastNotification("Gemt", "Vagt Registrerings-tabellen er gemt");
        }

        public void DeleteItem()
        {
            throw new System.NotImplementedException();
        }

        public void AddNewItem()
        {
            var ObjectToAdd = ManageTables.Instance.NewShiftRegistrations;
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
    }
}
