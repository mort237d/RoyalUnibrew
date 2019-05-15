using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace UniBase.Model.K2
{
    public static class InputValidator
    {
        /// <summary>
        /// Rækkefølge på properties i klasser er vigtige!
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        public static void CheckIfInputsAreValid<T>(ref T type)
        {
            List<string> datesandtimespans = new List<string>();
            int listIndexCounter = 0;

            Type tModelType = type.GetType();
            PropertyInfo[] arrayPropertyInfos = tModelType.GetProperties();

            //ToDo Finish This.
            foreach (PropertyInfo property in arrayPropertyInfos)
            {
                var prop = type.GetType().GetProperty(property.Name, BindingFlags.Public | BindingFlags.Instance);
                var propertyValue = prop.GetValue(type);
                
                if (property.PropertyType == typeof(string))
                {
                    if (prop.Name.Contains("StringHelper"))
                    {
                        if (propertyValue.ToString().Length >= 5)
                        {
                            datesandtimespans.Add(propertyValue.ToString());
                        }
                        else
                        {
                            //error
                            Debug.WriteLine("Failed");
                        }
                    }
                    else if (propertyValue == null)
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
                else if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
                {
                    try
                    {
                        int.TryParse(propertyValue.ToString(), out int i);
                        if (i == 0)
                        {
                            //error
                        }
                    }
                    catch
                    {
                        //error
                    }
                }
                else if (property.PropertyType == typeof(double) || property.PropertyType == typeof(double?))
                {
                    if (!double.TryParse(propertyValue.ToString(), out double i))
                    {
                        //error
                    }
                    else if (Math.Abs(i) < 0.001)
                    {
                        //error
                        Debug.WriteLine("Failed");
                    }
                }
                else if (property.PropertyType == typeof(DateTime))
                {
                    if (!(datesandtimespans.Count <= listIndexCounter))
                    {
                        string dateTimeChar = "/";
                        string timeSpanChar = ":";

                        DateTime dt = DateTime.Now;
                        if (datesandtimespans[listIndexCounter].Contains(dateTimeChar) && datesandtimespans[listIndexCounter].Contains(timeSpanChar))
                        {
                            var split = datesandtimespans[listIndexCounter].Split(dateTimeChar[0]);
                            var secoundSplit = split[split.Length - 1].Split(timeSpanChar[0]);
                            secoundSplit[0] = secoundSplit[0].Substring(3);
                            //secoundSplit[0] = secoundSplit[0].Trim();
                            split[2] = split[2].Remove(2);


                            try
                            {
                                if (secoundSplit.Length == 2)
                                {
                                    prop.SetValue(type, new DateTime(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]), int.Parse(secoundSplit[0]), int.Parse(secoundSplit[1]), 0), null);
                                }
                                else if (secoundSplit.Length == 3)
                                {
                                    prop.SetValue(type, new DateTime(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]), int.Parse(secoundSplit[0]), int.Parse(secoundSplit[1]), int.Parse(secoundSplit[2])), null);
                                }
                            }
                            catch
                            {
                                //error
                            }
                        }
                        else if (datesandtimespans[listIndexCounter].Contains(dateTimeChar)) 
                        {
                            var split = datesandtimespans[listIndexCounter].Split(dateTimeChar[0]);

                            try
                            {
                                prop.SetValue(type, new DateTime(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2])), null);
                            }
                            catch 
                            {
                                //error
                            }
                        }
                        else if (datesandtimespans[listIndexCounter].Contains(timeSpanChar))
                        {
                            var split = datesandtimespans[listIndexCounter].Split(timeSpanChar[0]);

                            try
                            {
                                DateTime dateNow = DateTime.Now;
                                if (split.Length == 3)
                                {
                                    prop.SetValue(type, new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2])), null);
                                }
                                else
                                {
                                    prop.SetValue(type, new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, int.Parse(split[0]), int.Parse(split[1]), 0), null);

                                }
                            }
                            catch
                            {
                                //error
                            }
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
                            if (split.Length == 2)
                            {
                                prop.SetValue(type, new TimeSpan(int.Parse(split[0]),int.Parse(split[1]), 0), null);
                            }
                            else
                            {
                                prop.SetValue(type, new TimeSpan(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2])), null);
                            }
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
