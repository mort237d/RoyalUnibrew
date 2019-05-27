using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace UniBase.Model
{
    public class GenericMethod
    {
        private Message _message = Message.Instance;
        private bool sorted = true;

        /// <summary>
        /// Filter er en generisk metode til at filtrere i en bestemt kolonne af tabellen, så man hurtigt og effektivt kan få fat i de rigtige oplysninger
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">Typen af den ønskede liste</param>
        /// <param name="list">Listen som vises i lisviewet</param>
        /// <param name="completeList">Liste af alle elementer i databasen</param>
        /// <param name="property">Propertien, som der skal søges i</param>
        /// <param name="textBoxOutPut">Textboxen, som der skal søges igennem</param>
        /// <param name="initializeAction">Initialize metode, som skal eksekveres for at opdatere tabellen</param>
        /// <param name="helperAction">Hjælper metode, som skal eksekveres for at få alle properties til at aggere rigtigt</param>
        public void Filter<T>(T type, ObservableCollection<T> list, ObservableCollection<T> completeList, string property, string textBoxOutPut, Action initializeAction, Action helperAction)
        {
            list.Clear();

            PropertyInfo prop = typeof(T).GetProperty(property);
            foreach (var f in completeList)
            {
                if (prop.GetValue(f,null) != null)
                {
                    var v = prop.GetValue(f, null).ToString().ToLower();
                    if (v.Contains(textBoxOutPut.ToLower()))
                    {
                        list.Add(f);
                    }
                }
            }

            helperAction();

            if (string.IsNullOrEmpty(textBoxOutPut))
            {
                initializeAction();
            }
        }
        
        /// <summary>
        /// Sort er en generisk metode til at sortere en bestemt kolonne af tabellen ud fra en property
        /// </summary>
        /// <typeparam name="T">Typen af listen</typeparam>
        /// <param name="input">Liste, som skal sorteres</param>
        /// <param name="property">Property som der skal søges efter</param>
        /// <returns></returns>
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

        /// <summary>
        /// DeleteSelected er en generisk metode til at slette det valgte element
        /// </summary>
        /// <typeparam name="T">Typen, som skal slettes</typeparam>
        /// <param name="selectedItem">Det valgte element fra listen</param>
        /// <param name="type">Typen</param>
        /// <param name="completeList">Liste af alle elementer i databasen</param>
        /// <param name="list">Listen som vises i lisviewet</param>
        /// <param name="property">Propertien, som der skal angive id</param>
        public void DeleteSelected<T>(T selectedItem, T type, ObservableCollection<T> completeList, ObservableCollection<T> list, string property, string tableName)
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
                _message.ShowToastNotification("Slettet", tableName + " slettet");
            }
            else
            {
                _message.ShowToastNotification("Fejl", "Marker venligst ønskede " + tableName.ToLower() + ", for at slette");
            }
        }

        /// <summary>
        /// SaveAll er en generisk metode til at gemme alle elementer
        /// </summary>
        /// <typeparam name="T">Typen, der skal gemmes</typeparam>
        /// <param name="list">Listen, som der skal gemmes fra</param>
        /// <param name="property">Propertien som skal gemmes</param>
        /// <param name="tableName">Navn på tabellen til toast notification</param>
        public void SaveAll<T>(ObservableCollection<T> list, string property, string tableName)
        {
            PropertyInfo prop = typeof(T).GetProperty(property);

            foreach (var item in list)
            {
                ModelGenerics.UpdateByObjectAndId((int)prop.GetValue(item, null), item);
            }
            _message.ShowToastNotification("Gemt", tableName + "-tabellen er gemt");
        }

        /// <summary>
        /// SelectParentItem er en generisk metode til at udpege listviewets item
        /// </summary>
        /// <typeparam name="T">Typen af listen</typeparam>
        /// <param name="obj">Det medfølgende object fra command parameter</param>
        /// <param name="list">Listen der skal søges igennem</param>
        /// <param name="property">Propertien</param>
        /// <returns></returns>
        public int SelectParentItem<T>(int obj, ObservableCollection<T> list, string property)
        {
            PropertyInfo prop = typeof(T).GetProperty(property);
            
            int index = list.IndexOf(list.First(d => (int) prop.GetValue(d, null) == obj));

            return index;    
        }
    }
}
