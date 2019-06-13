using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Project2
{
    [Serializable()]
   public class Reservation : ISerializable
    {
        public string hotelName { get; set; }
        public int roomNo { get; set; }
        public DateTime startDate {get; set; }
        public DateTime endDate { get; set; }
        public string user { get; set; }
        public double price { get; set; }


        /// <summary>
        /// data insertion for serialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("HotelName", hotelName);
            info.AddValue("roomNo", roomNo);
            info.AddValue("startDate", startDate);
            info.AddValue("endDate ", endDate);
            info.AddValue("userInfo", user);
            info.AddValue("totalPrice", price);
        }

        /// <summary>
        /// constructor receiving data for serialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public Reservation(SerializationInfo info, StreamingContext context)
        {
            hotelName = (string)info.GetValue("HotelName", typeof(string));
            roomNo = (int)info.GetValue("roomNo", typeof(int));
            startDate = (DateTime)info.GetValue("startDate", typeof(DateTime));
            endDate = (DateTime)info.GetValue("endDate", typeof(DateTime));
            user = (string)info.GetValue("userInfo", typeof(string));
            price = (double)info.GetValue("totalPrice", typeof(double));

        }
        public Reservation(User user ,DateTime startDate, DateTime endDate,double price,int roomNo, string hotelName)
        {
            this.hotelName = hotelName;
            this.roomNo = roomNo;
            this.startDate = startDate;
            this.endDate = endDate;
            this.user = user.ToString();
            this.price = price;

        }

        public Reservation()
        {
        }

        public override string ToString()
        {
            return hotelName + "    " + roomNo + "    " + startDate.ToString("dd/MM/yyyy") + "    " + endDate.ToString("dd/MM/yyyy")
                + "     " + price + "    " + user.ToString();
        }

        
    }
}
