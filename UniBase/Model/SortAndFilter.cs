using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UniBase.Model.K2;
using UniBase.Model.K2.ButtonMethods;

namespace UniBase.Model
{
    public class SortAndFilter
    {
        private bool sorted = true;

        public void Filter<T>(T type, ObservableCollection<T> list, ObservableCollection<T> completeList, string property, string textBoxOutPut)
        {
            list.Clear();

            foreach (var f in completeList)
            {
                PropertyInfo prop = typeof(T).GetProperty(property);
                var v = prop.GetValue(f, null).ToString().ToLower();
                if (v.Contains(textBoxOutPut.ToLower()))
                {
                    list.Add(f);
                }
            }

            if (string.IsNullOrEmpty(textBoxOutPut))
            {
                list = ModelGenerics.GetLastTenInDatabasae(type);
            }
        }
        
        public ObservableCollection<T> Sort<T>(ObservableCollection<T> input, string property)
        {
            var tempList = new ObservableCollection<T>();
            PropertyInfo prop = typeof(T).GetProperty(property);
            
            if (!sorted)
            {
                tempList = new ObservableCollection<T>(input.OrderBy(item => prop.GetValue(item, null)));
                sorted = true;
            }
            else
            {
                tempList = new ObservableCollection<T>(input.OrderByDescending(item => prop.GetValue(item, null)));
                sorted = false;
            }

            return tempList;
        }
    }
}
