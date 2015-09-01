using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace predictor
{
    public class predictorLibrary
    {
        /* Input example
         plateNumber -- GHB-7891 
         date -- 08/31/2015
         time -- 10:00
         * */
        public static List<string> predictProcedure(string plateNumber, string date, string time) 
        {
            try
            {
                    List<string> result = new List<string>();
                    predictorData dataList = xmlParser.readXml();
                    string lastNumber = plateNumber.Substring(plateNumber.Length - 1, 1);
                    DateTime predictDate = DateTime.Parse(date, new CultureInfo("en-US"));
                    int dayNumber = (int)predictDate.DayOfWeek;
                    predictorTime predictTime = new predictorTime(time);
                    List<predictorItem> items = dataList.getPredictorItem;
                    for (int i = 0; i < items.Count; i++)
                    {
                        predictorItem item = items[i];
                        if (item.getDayNumber == dayNumber)
                        {
                            if (item.getPlacas.getTypes.Contains(lastNumber))
                            {
                                if (item.getExceptions.getTypes.Contains(lastNumber) || item.getExceptions.getTypes.Contains(plateNumber))
                                {
                                    return result;
                                }
                                else
                                {
                                    List<scheduleItem> listSchedules = item.getPicos.getSchedules;
                                    for (int j = 0; j < listSchedules.Count; j++)
                                    {
                                        predictorTime begin = listSchedules[j].getBegin;
                                        predictorTime end = listSchedules[j].getEnd;

                                        if (predictTime.isAfter(begin) && predictTime.isBefore(end))
                                        {
                                            //List all street that the car can't circulate.
                                            return item.getStreets.getStreets;
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    }
                return result;
            }
            catch (Exception exc)
            {
                throw new Exception("Unexpected error , try again");
            }
        }
        public static string availableStreet(string plateNumber, string date, string time) 
        {
            try
            {
                if (!validatePlaca(plateNumber)) return "Incorrect plate number format";
                if (!validateDate(date)) return "Incorrect date format";
                if (!validateTime(time)) return "Incorrect time format";
                List<string> result = predictProcedure(plateNumber, date, time);
                if (result.Count == 0)
                {
                    return "It can circulate on all streets";
                }
                else
                {
                    string response = "It can't circulate on this street(s):";
                    foreach (string item in result)
                    {
                        response += " " + item + " ,";
                    }
                    return response.Substring(0, response.Length - 1);
                }
            }
            catch (Exception exc)
            {
                throw new Exception("Unexpected error , try again");
            }
        }
        public static bool validateDate(string date)
        {
            try
            {
                DateTime dt;
                return DateTime.TryParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
            }
            catch (Exception exc)
            {
                return false;
            }
        }
        public static bool validateTime(string time)
        {
            try
            {
                Regex r = new Regex(@"\A([0-9]{2}):([0-9]{2})\Z");
                if (r.IsMatch(time)) 
                {
                    Match m = r.Match(time);
                    int hour = int.Parse(m.Groups[1].Value);
                    int minute = int.Parse(m.Groups[2].Value);
                    if (hour < 0 || hour > 23 || minute < 0 || minute > 59) 
                    {
                        return false;
                    }
                    return true;
                }
                return false;
            }
            catch (Exception exc)
            {
                return false;
            }
        }
        public static bool validatePlaca(string placa)
        {
            try
            {
                Regex r = new Regex(@"\A([A-Z]{3})-([0-9]{3,4})\Z");
                return r.IsMatch(placa);
            }
            catch (Exception exc)
            {
                return false;
            }
        }
    }
}
