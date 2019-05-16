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
            List<string> datesAndTimeSpanStrings = new List<string>();
            List<double> intsAndDoubleStrings = new List<double>();
            int datesAndTimeSpanListCounter = 0;
            int intsAndDoubleListCounter = 0;

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
                            datesAndTimeSpanStrings.Add(propertyValue.ToString());
                        }
                        else
                        {
                            //error
                            Debug.WriteLine("Failed");
                        }
                    }
                    else if (prop.Name.Contains("IntHelper") || prop.Name.Contains("DoubleHelper"))
                    {
                        try
                        {
                            if (propertyValue.ToString().Contains(","))
                            {
                                prop.SetValue(type, propertyValue.ToString().Replace(",",".") , null);
                            }
                            if (double.TryParse(propertyValue.ToString(), out double i))
                            {
                                intsAndDoubleStrings.Add(i);
                            }
                            else
                            {
                                //error
                                Debug.WriteLine("Failed");
                            }
                        }
                        catch
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
                else if (property.PropertyType == typeof(int))
                {
                    try
                    {
                        if (!(intsAndDoubleStrings.Count <= intsAndDoubleListCounter))
                        {
                            prop.SetValue(type, (int)intsAndDoubleStrings[intsAndDoubleListCounter], null);
                        }
                    }
                    catch
                    {
                        //error
                    }
                    intsAndDoubleListCounter++;

                }
                else if (property.PropertyType == typeof(double) || property.PropertyType == typeof(int))
                {
                    try
                    {
                        if (!(intsAndDoubleStrings.Count <= intsAndDoubleListCounter))
                        {
                            prop.SetValue(type, (double)intsAndDoubleStrings[intsAndDoubleListCounter], null);
                        }
                    }
                    catch
                    {
                        //error
                    }

                    intsAndDoubleListCounter++;
                }
                else if (property.PropertyType == typeof(DateTime))
                {
                    if (!(datesAndTimeSpanStrings.Count <= datesAndTimeSpanListCounter))
                    {
                        string dateTimeChar = "/";
                        string timeSpanChar = ":";

                        if (datesAndTimeSpanStrings[datesAndTimeSpanListCounter].Contains(dateTimeChar) && datesAndTimeSpanStrings[datesAndTimeSpanListCounter].Contains(timeSpanChar))
                        {
                            var split = datesAndTimeSpanStrings[datesAndTimeSpanListCounter].Split(dateTimeChar[0]);
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
                        else if (datesAndTimeSpanStrings[datesAndTimeSpanListCounter].Contains(dateTimeChar)) 
                        {
                            var split = datesAndTimeSpanStrings[datesAndTimeSpanListCounter].Split(dateTimeChar[0]);

                            try
                            {
                                prop.SetValue(type, new DateTime(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2])), null);
                            }
                            catch 
                            {
                                //error
                            }
                        }
                        else if (datesAndTimeSpanStrings[datesAndTimeSpanListCounter].Contains(timeSpanChar))
                        {
                            var split = datesAndTimeSpanStrings[datesAndTimeSpanListCounter].Split(timeSpanChar[0]);

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
                        datesAndTimeSpanListCounter++;
                    }
                }
                else if (property.PropertyType == typeof(TimeSpan))
                {
                    if (!(datesAndTimeSpanStrings.Count <= datesAndTimeSpanListCounter))
                    {
                        var split = datesAndTimeSpanStrings[datesAndTimeSpanListCounter].Split(':');
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
                        datesAndTimeSpanListCounter++;
                    }
                }
            }
        }
    }
}
