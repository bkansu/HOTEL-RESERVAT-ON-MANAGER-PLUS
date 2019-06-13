using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
/// <summary>
/// quality 3
/// </summary>
namespace Project2
{
    [Serializable()]
    public class TwinRoom : Room
    {
        public TwinRoom(int no, List<string> roomContents, int minPrice,int maxPrice)
            : base(no, roomContents, minPrice,maxPrice) { }
        public TwinRoom()
             : base() { }



    }
}
