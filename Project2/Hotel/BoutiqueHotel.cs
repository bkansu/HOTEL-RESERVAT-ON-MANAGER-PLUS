using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project2
{
    [Serializable()]    /// <summary>
                        /// 2 stars hotel
                        /// </summary>
    public class BoutiqueHotel : Hotel
    {
       
        public BoutiqueHotel(string city,string name) : base(city,2,name)
        {
          

        }
        public BoutiqueHotel() : base()
        {


        }



    }
}
