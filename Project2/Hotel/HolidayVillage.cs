using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project2
{
    [Serializable()]    /// <summary>
                        /// 4 stars hotel
                        /// </summary>
    public class HolidayVillage : Hotel
    {
       
        public HolidayVillage(string city,string name) : base(city, 4,name)
        {
           
        }
        public HolidayVillage() : base()
        {

        }
    }
}
