using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
/// <summary>
/// quality 1
/// </summary>
namespace Project2
{
    [Serializable()]
    public class SingleBedRoom : Room
    {
        public SingleBedRoom(int no, List<string> roomContents,int minPrice,int maxPrice)
            : base(no, roomContents , minPrice,maxPrice) { }
        public SingleBedRoom()
             : base() { }




    }
}
