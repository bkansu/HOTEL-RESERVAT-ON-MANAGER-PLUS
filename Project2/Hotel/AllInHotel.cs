using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project2
{
    /// <summary>
    /// 3 stars hotel
    /// </summary>
     [Serializable()]
    public class AllInHotel : Hotel
    {
      
        public AllInHotel(string city,string name) : base(city,3,name)
        {
            
        }
        public AllInHotel() : base()
        {

        }

    }
}
