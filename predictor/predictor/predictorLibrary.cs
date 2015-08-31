using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace predictor
{
    public class predictorLibrary
    {
        // plateNumber -- GHB-7891 
        // date -- 08/31/2015
        // time -- 10:00
        public static bool predictProcedure(string plateNumber, string date, string time) 
        {
            try
            {
                if (validateInput(plateNumber, date, time))
                {
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
                                    return true;
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
                                            return false;
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    }
                    return true;
                }
                return false;
            }
            catch (Exception exc)
            {
                throw new Exception("Unexpected error , try again");
            }
        }
        public static bool validateInput(string plateNumber, string date, string time)
        {
            try
            {
                return true;
            }
            catch (Exception exc)
            {
                throw new Exception("Unexpected error , try again");
            }
        }
    }
}
