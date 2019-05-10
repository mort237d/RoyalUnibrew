using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UniBase.Model.K2
{
    class InputValidator
    {
        /// <summary>
        /// Rækkefølge på properties i klasser er vigtige!
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        public void CheckIfInputsAreValid<T>(ref T type)
        {
            List<string> datesandtimespans = new List<string>();
            int listIndexCounter = 0;

            Type tModelType = type.GetType();

            PropertyInfo[] arrayPropertyInfos = tModelType.GetProperties();

            //ToDo Finish This.
            foreach (PropertyInfo property in arrayPropertyInfos)
            {
                var prop = type.GetType().GetProperty(property.Name, BindingFlags.Public | BindingFlags.Instance);
                var proppi = prop.GetValue(type);

                if (property.PropertyType == typeof(string))
                {
                    if (prop.Name.Contains("StringHelper"))
                    {
                        if (proppi.ToString().Length >= 8)
                        {
                            datesandtimespans.Add(proppi.ToString());
                        }
                        else
                        {
                            //error
                            Debug.WriteLine("Failed");
                        }
                    }
                    else if (proppi == null)
                    {
                        if (property.Name == "Note" || property.Name == "CommentsOnChangedDate")
                        {
                            prop.SetValue(type, " ", null);
                        }
                        else
                        {
                            //error
                            Debug.WriteLine("Failed");

                        }
                    }
                }
                else if (property.PropertyType == typeof(int))
                {
                    int.TryParse(proppi.ToString(), out int i);
                    if (i == 0)
                    {
                        //error
                        Debug.WriteLine("Failed");

                    }
                }
                else if (property.PropertyType == typeof(double))
                {
                    double.TryParse(proppi.ToString(), out double i);
                    if (i == 0)
                    {
                        //error
                        Debug.WriteLine("Failed");

                    }
                }
                else if (property.PropertyType == typeof(DateTime))
                {
                    if (!(datesandtimespans.Count <= listIndexCounter))
                    {

                        DateTime dt = DateTime.Now;
                        var split = datesandtimespans[listIndexCounter].Split('/');
                        var splitWithoutSpecialChars = split;
                        for (int i = 0; i < split.Length; i++)
                        {
                            splitWithoutSpecialChars[i] = split[i].Trim('/');
                        }

                        if (splitWithoutSpecialChars[2].Length > 4)
                        {
                            splitWithoutSpecialChars[2] = splitWithoutSpecialChars[2].Remove(4);
                        }

                        try
                        {
                            prop.SetValue(type, new DateTime(int.Parse(splitWithoutSpecialChars[0]), int.Parse(splitWithoutSpecialChars[1]), int.Parse(splitWithoutSpecialChars[2]), dt.Hour, dt.Minute, 0), null);
                        }
                        catch
                        {
                            //error
                        }
                        listIndexCounter++;
                    }
                }
                else if (property.PropertyType == typeof(TimeSpan))
                {
                    if (!(datesandtimespans.Count <= listIndexCounter))
                    {
                        var split = datesandtimespans[listIndexCounter].Split(':');
                        try
                        {
                            prop.SetValue(type, new TimeSpan(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2])), null);
                        }
                        catch
                        {
                            //error
                        }
                        listIndexCounter++;
                    }
                }
            }
        }
    }
}
