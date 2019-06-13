using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
/// <summary>
/// quality 6
/// </summary>
namespace Project2
{
    [Serializable()]
    public class KingRoom : Room
    {
        public KingRoom(int no, List<string> roomContents, int minPrice, int maxPrice)
            : base(no, roomContents  , minPrice,maxPrice) { }
        public KingRoom()
             : base() { }



    }
}
