using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace UniBase.Model.K2.ButtonMethods
{
    public class FrontpageButtonMethod
    {
        private Message message = new Message();
        private InputValidator inputValidator = new InputValidator();

        public FrontpageButtonMethod()
        {
        }

        public void RefreshFrontpages()
        {
            ManageTables.Instance.FrontpagesList = ModelGenerics.GetAll(new Frontpages());
            Parallel.ForEach(ManageTables.Instance.FrontpagesList, frontpage =>
            {
                frontpage.DateTimeStringHelper = frontpage.Date.ToString();
            });
            message.ShowToastNotification("Opdateret", "Forside-tabellen er opdateret");
        }
        public void RefreshLastTenFrontpages()
        {
            ManageTables.Instance.FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
            foreach (var frontpage in ManageTables.Instance.FrontpagesList)
            {
                frontpage.DateTimeStringHelper = frontpage.Date.ToString().Remove(10);
            }
            message.ShowToastNotification("Opdateret", "Forside-tabellen er opdateret");
        }
        public void SaveFrontpages()
        {

            Parallel.ForEach(ManageTables.Instance.FrontpagesList, frontpage =>
            {
                ModelGenerics.UpdateByObjectAndId(frontpage.ProcessOrder_No, frontpage);
            });
            message.ShowToastNotification("Gemt", "Forside-tabellen er gemt");
        }

        public void DeleteFrontpage(object id)
        {
            if (ManageTables.Instance.SelectedFrontpage != null)
            {
                //TODO Make deletion method
                Debug.WriteLine(ManageTables.Instance.SelectedFrontpage.ProcessOrder_No);
            }
        }

        public void AddNewFrontpages()
        {
            var instanceNewFrontpagesToAdd = ManageTables.Instance.NewFrontpagesToAdd;
            inputValidator.CheckIfInputsAreValid(ref instanceNewFrontpagesToAdd);
            instanceNewFrontpagesToAdd.Week_No = FindWeekNumber(instanceNewFrontpagesToAdd);

            //Checks whether any of the properties are null if any are returns true
            bool isNull = instanceNewFrontpagesToAdd.GetType().GetProperties().All(p => p.GetValue(instanceNewFrontpagesToAdd) == null);

            if (!isNull)
            {
                ManageTables.Instance.FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
                instanceNewFrontpagesToAdd.ProcessOrder_No = ManageTables.Instance.FrontpagesList.Last().ProcessOrder_No + 1;
                if (ModelGenerics.CreateByObject(instanceNewFrontpagesToAdd))
                {
                    //ManageTables.Instance.FrontpagesList.Add(NewFrontpagesToAdd);
                    ManageTables.Instance.FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
                    instanceNewFrontpagesToAdd = new Frontpages();
                    instanceNewFrontpagesToAdd.ProcessOrder_No = ManageTables.Instance.FrontpagesList[ManageTables.Instance.FrontpagesList.Count - 1].ProcessOrder_No + 1;
                    instanceNewFrontpagesToAdd.Date = DateTime.Now;
                    instanceNewFrontpagesToAdd.Week_No = FindWeekNumber(instanceNewFrontpagesToAdd);
                }
                else
                {
                    //error
                }
            }
        }

        public int FindWeekNumber(Frontpages frontpage)
        {
            int dayOfYear = frontpage.Date.DayOfYear;
            int weekNumber = 1;
            if (dayOfYear > 7)
            {
                if (dayOfYear % 1 != 0)
                {
                    weekNumber = (dayOfYear / 7) + 1;
                }
                else
                {
                    weekNumber = (dayOfYear / 7) + 1;
                }
            }

            return weekNumber;
        }
    }
}
