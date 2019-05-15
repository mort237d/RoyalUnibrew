using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace UniBase.Model
{
    public class GenericMethod
    {
        private bool _sorted = true;

        public void Filter<T>(T type, ObservableCollection<T> list, ObservableCollection<T> completeList, string property, string textBoxOutPut)
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
                list = ModelGenerics.GetLastTenInDatabasae(type);
            }
        }
        
        public ObservableCollection<T> Sort<T>(ObservableCollection<T> input, string property)
        {
            var tempList = new ObservableCollection<T>();
            PropertyInfo prop = typeof(T).GetProperty(property);
            
            if (!_sorted)
            {
                tempList = new ObservableCollection<T>(input.OrderBy(item => prop.GetValue(item, null)));
                _sorted = true;
            }
            else
            {
                tempList = new ObservableCollection<T>(input.OrderByDescending(item => prop.GetValue(item, null)));
                _sorted = false;
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
