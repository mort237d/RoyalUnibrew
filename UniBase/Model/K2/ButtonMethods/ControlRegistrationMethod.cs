using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace UniBase.Model.K2.ButtonMethods
{
    public class ControlRegistrationMethod
    {
        private Message message = new Message();
        private InputValidator inputValidator = new InputValidator();

        public void RefreshControlRegistrations()
        {
            ManageTables.Instance.ControlRegistrationsList = ModelGenerics.GetAll(new ControlRegistrations());
            message.ShowToastNotification("Opdateret", "Kontrol Registrerings-tabellen er opdateret");
        }
        public void RefreshLastTenControlRegistrations()
        {
            ManageTables.Instance.ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
            message.ShowToastNotification("Opdateret", "Kontrol Registrerings-tabellen er opdateret");
        }
        public void SaveControlRegistrations()
        {
            Parallel.ForEach(ManageTables.Instance.ControlRegistrationsList, controlRegistration =>
            {
                ModelGenerics.UpdateByObjectAndId(controlRegistration.ControlRegistration_ID, controlRegistration);
            });
            message.ShowToastNotification("Gemt", "Kontrol Registrerings-tabellen er gemt");
        }

        public void ControlledClick(object id)
        {
            Debug.WriteLine(id.ToString());

            foreach (var CR in ManageTables.Instance.ControlRegistrationsList)
            {
                if (CR.ProcessOrder_No == (int)id)
                {
                    if (CR.ControlAlcoholSpearDispenser)
                    {
                        CR.ControlAlcoholSpearDispenser = false;
                        break;
                    }
                    else
                    {
                        CR.ControlAlcoholSpearDispenser = true;
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
            inputValidator.CheckIfInputsAreValid(ref instanceNewControlRegistrationsToAdd);

            //Checks whether any of the properties are null if any are returns true
            bool isNull = instanceNewControlRegistrationsToAdd.GetType().GetProperties().All(p => p.GetValue(instanceNewControlRegistrationsToAdd) == null);

            if (!isNull)
            {
                ManageTables.Instance.ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
                instanceNewControlRegistrationsToAdd.ControlRegistration_ID = ManageTables.Instance.ControlRegistrationsList.Last().ControlRegistration_ID + 1;
                var temp = ModelGenerics.GetById(new Frontpages(), instanceNewControlRegistrationsToAdd.ProcessOrder_No);
                var temp2 = ModelGenerics.GetById(new Products(), temp.FinishedProduct_No);
                instanceNewControlRegistrationsToAdd.Expiry_Date = new DateTime(temp2.BestBeforeDateLength);

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

    }
}
