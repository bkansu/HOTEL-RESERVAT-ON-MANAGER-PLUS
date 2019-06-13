using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Project2
{
    [Serializable()]
    [XmlInclude(typeof(SingleBedRoom))]
    [XmlInclude(typeof(TwoBedRoom))]
    [XmlInclude(typeof(TwinRoom))]
    [XmlInclude(typeof(ThreeBedRoom))]
    [XmlInclude(typeof(FamilyRoom))]
    [XmlInclude(typeof(KingRoom))]
    public class Room :ISerializable
    {
       
        public int no { get; set; }
        public List<string> roomContents { get; set; }
        public int  minprices { get; set; }
        public int maxprices { get; set; }



        /// <summary>
        /// data insertion for serialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("no", no);
            info.AddValue("roomContents", roomContents);
            info.AddValue("minprices", minprices);
            info.AddValue("maxprices", maxprices);
        }
        /// <summary>
        /// constructor receiving data for serialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public Room(SerializationInfo info, StreamingContext context)
        {
            no = (int)info.GetValue("no", typeof(int));
            roomContents = (List<string>)info.GetValue("roomContents", typeof(string));
            minprices = (int)info.GetValue("minprices", typeof(int));
            maxprices = (int)info.GetValue("maxprices", typeof(int));
        }

        public Room(int no, List<string> roomContents, int minprices, int maxprices)
        {
            this.no = no;
            this.roomContents = roomContents;
            this.minprices = minprices;
            this.maxprices = maxprices;
        }

        public Room()
        {
        }

        public  bool getPay(DateTime s , DateTime e , ref int price,DateTime firstBootTime)
        {
               Random random = new Random(DateTime.Now.Millisecond);
             TimeSpan span = e - s;
            if (span.TotalDays <= 0) return false;

          
            for (int i =0; i < (int)(span.TotalDays); i++)
            {
                price += random.Next(minprices, maxprices + 1);
            }
            return true;

        }

       
    }
}
