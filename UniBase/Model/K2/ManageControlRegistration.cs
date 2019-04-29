using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
