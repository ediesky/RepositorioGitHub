using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace predictor
{
    public class xmlParser
    {
        public static predictorData readXml() 
        {
            predictorData dataList = new predictorData();
            XmlDocument doc = new XmlDocument();
            doc.Load("data.xml");

            XmlNode restrictionListNode = doc.SelectSingleNode("/restriction");
            XmlNodeList detailNodeList = restrictionListNode.SelectNodes("detail");
            
            foreach (XmlNode node in detailNodeList)
            {
                string day = node.SelectSingleNode("day").InnerText;
                int dayNumber = int.Parse(node.SelectSingleNode("dayNumber").InnerText);

                picoItem pico = new picoItem();
                XmlNode picoListNode = node.SelectSingleNode("pico");
                XmlNodeList scheduleNodeList = picoListNode.SelectNodes("schedule");
                foreach (XmlNode nodeSchedule in scheduleNodeList) 
                {
                    string begin = nodeSchedule.SelectSingleNode("begin").InnerText;
                    string end = nodeSchedule.SelectSingleNode("end").InnerText;
                    pico.addSchedule(new scheduleItem(begin, end));
                }

                placaItem placa = new placaItem();
                XmlNode placaListNode = node.SelectSingleNode("placa");
                XmlNodeList typeNodeList = placaListNode.SelectNodes("type");
                foreach (XmlNode nodeType in typeNodeList)
                {
                    string type = nodeType.InnerText;
                    placa.addType(type);
                }

                placaItem exceptions = new placaItem();
                XmlNode exceptionsListNode = node.SelectSingleNode("exception");
                XmlNodeList exceptionsNodeList = exceptionsListNode.SelectNodes("type");
                foreach (XmlNode nodeType in exceptionsNodeList)
                {
                    string type = nodeType.InnerText;
                    exceptions.addType(type);
                }

                predictorItem item = new predictorItem(dayNumber,day,pico,placa,exceptions);
                dataList.addPredictorItem(item);
            }
            return dataList;
        }
    }
}
