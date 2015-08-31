using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace predictor
{
    public class predictorData
    {
        List<predictorItem> items;
        public predictorData()
        {
            this.items = new List<predictorItem>();
        }
        public predictorData(List<predictorItem> items) 
        {
            this.items = items;
        }
        public void addPredictorItem( predictorItem item)
        {
            this.items.Add(item);
        }
        public List<predictorItem> getPredictorItem
        {
            get 
            {
                return this.items;
            }
        }
    }
    public class predictorItem
    {
        int dayNumber;
        string day;
        picoItem picos;
        placaItem placas;
        placaItem exceptions;
        public predictorItem(int dayNumber, string day, picoItem picos, placaItem placas, placaItem exceptions)
        {
            this.dayNumber = dayNumber;
            this.day = day;
            this.picos = picos;
            this.placas = placas;
            this.exceptions = exceptions;
        }
        public int getDayNumber 
        {
            get 
            {
                return this.dayNumber;
            }
            set
            {
                this.dayNumber = value;
            }
        }
        public string getDay
        {
            get
            {
                return this.day;
            }
            set
            {
                this.day = value;
            }
        }
        public picoItem getPicos
        {
            get
            {
                return this.picos;
            }
            set
            {
                this.picos = value;
            }
        }
        public placaItem getPlacas
        {
            get
            {
                return this.placas;
            }
            set
            {
                this.placas = value;
            }
        }
        public placaItem getExceptions
        {
            get
            {
                return this.exceptions;
            }
            set
            {
                this.exceptions = value;
            }
        }

    }
    public class picoItem
    {
        List<scheduleItem> schedules;
        public picoItem()
        {
            this.schedules = new List<scheduleItem>();
        }
        public picoItem(List<scheduleItem> schedules)
        {
            this.schedules = schedules;
        }
        public List<scheduleItem> getSchedules 
        {
            get 
            {
                return this.schedules;
            }
        }
        public void addSchedule( scheduleItem item) 
        {
            this.schedules.Add(item);
        }
        

    }
    public class placaItem
    {
        List<string> types;
        public placaItem()
        {
            this.types = new List<string>();
        }
        public placaItem(List<string> types)
        {
            this.types = types;
        }
        public List<string> getTypes 
        {
            get 
            {
                return this.types;
            }
        }
        public void addType( string type) 
        {
            this.types.Add(type);
        }
    }

    public class scheduleItem
    {
        predictorTime begin;
        predictorTime end;
        public scheduleItem(string begin, string end)
        {
            this.begin = new predictorTime(begin);
            this.end = new predictorTime(end);
        }
        public predictorTime getBegin 
        {
            get 
            {
                return this.begin;
            }
            set
            {
                this.begin = value;
            }
        }
        public predictorTime getEnd
        {
            get
            {
                return this.end;
            }
            set
            {
                this.end = value;
            }
        }
        
    }
    public class predictorTime
    {
        int hour;
        int minute;
        public predictorTime(int hour, int minute) 
        {
            this.hour = hour;
            this.minute = minute;
        }
        public predictorTime(string time)
        {
            string[] arr = time.Split(':');
            this.hour = int.Parse(arr[0]);
            this.minute = int.Parse(arr[1]); ;
        }
        public int getHour
        {
            get
            {
                return this.hour;
            }
            set
            {
                this.hour = value;
            }
        }
        public int getMinute
        {
            get
            {
                return this.minute;
            }
            set
            {
                this.minute = value;
            }
        }
        public bool isAfter(predictorTime timeCompare) 
        {
            if (this.getHour > timeCompare.getHour) return true;
            else if (this.getHour == timeCompare.getHour)
            {
                if (this.minute >= timeCompare.getMinute) return true;
                else return false;
            }
            else return false;
        }

        public bool isBefore(predictorTime timeCompare)
        {
            if (this.getHour < timeCompare.getHour) return true;
            else if (this.getHour == timeCompare.getHour)
            {
                if (this.minute <= timeCompare.getMinute) return true;
                else return false;
            }
            else return false;
        }


    }
    
    
}
