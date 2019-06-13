using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project2
{
    [Serializable()]    /// <summary>
                        /// 5 stars hotel
                        /// </summary>
    public class UltraLuxuryHotel : Hotel
    {

        public UltraLuxuryHotel(string city,string name) : base(city, 5,name)
        {

        }
        public UltraLuxuryHotel() : base()
        {

        }

    }
}
