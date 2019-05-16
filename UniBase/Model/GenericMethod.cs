using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace UniBase.Model
{
    public class GenericMethod
    {
        private bool sorted = true;

        public void Filter<T>(T type, ObservableCollection<T> list, ObservableCollection<T> completeList, string property, string textBoxOutPut, Action method)
        {
            list.Clear();

            PropertyInfo prop = typeof(T).GetProperty(property);
            foreach (var f in completeList)
            {
                var v = prop.GetValue(f, null).ToString().ToLower();
                if (v.Contains(textBoxOutPut.ToLower()))
                {
                    list.Add(f);
                }
            }

            if (string.IsNullOrEmpty(textBoxOutPut))
            {
                method();
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

        public void DeleteSelected<T>(T selectedItem, T type, ObservableCollection<T> completeList, ObservableCollection<T> list, string property)
        {
            if (selectedItem != null)
            {
                PropertyInfo prop = typeof(T).GetProperty(property);
                var id = prop.GetValue(selectedItem, null);

                ModelGenerics.DeleteById(type, (int)id);

                foreach (var item in completeList)
                {
                    var itemId = prop.GetValue(item, null);
                    if (itemId.Equals(id))
                    {
                        completeList.Remove(item);
                        break;
                    }
                }

                list.Remove(selectedItem);
            }
        }
    }
}
