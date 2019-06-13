using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project2
{
    [Serializable()]    /// <summary>
                        /// 1 star hotel
                        /// </summary>
    public class Hostel : Hotel
    {
        public Hostel(string city,string name) : base(city,1,name)
        {
           
          
        }
        public Hostel() : base()
        {


        }



    }
}
