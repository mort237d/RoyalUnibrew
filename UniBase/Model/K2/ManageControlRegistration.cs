using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ModelLibrary;

namespace UniBase.Model.K2
{
    class ManageControlRegistration
    {
        public static ObservableCollection<ControlSchedules> Initialize()
        {
            ObservableCollection<ControlSchedules> controlScheduleses = new ObservableCollection<ControlSchedules>();

            try
            {
                controlScheduleses = ModelGenerics.GetAll(new ControlSchedules());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return controlScheduleses;
        }
    }
}
