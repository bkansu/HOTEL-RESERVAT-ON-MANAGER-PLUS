using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
/// <summary>
/// quality 2
/// </summary>
namespace Project2
{
    [Serializable()]
    public class TwoBedRoom : Room
    {
         public TwoBedRoom(int no, List<string> roomContents, int minPrice,int maxPrice) 
            : base(no, roomContents, minPrice,maxPrice ) { }

        public TwoBedRoom()
             : base() { }

    }
}
