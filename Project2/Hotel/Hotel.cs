using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Project2
{

    /// <summary>
    /// other hotels will consist of this hotel class
    /// </summary>
    [Serializable()]
    [XmlInclude(typeof(Hostel))]
    [XmlInclude(typeof(BoutiqueHotel))]
    [XmlInclude(typeof(AllInHotel))]
    [XmlInclude(typeof(UltraLuxuryHotel))]
    [XmlInclude(typeof(HolidayVillage))]
    public class Hotel : ISerializable
    {
        public List<Reservation> Reservations { get; set; }
        public string City { get; set; }
        public int Star { get; set; }
        public List<Room> Rooms { get; set; }
        public int RoomCapaCity { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// data insertion for serialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Reservations", Reservations);
            info.AddValue("City", City);
            info.AddValue("Star", Star);
            info.AddValue("Rooms", Rooms);
            info.AddValue("RoomCapacity", RoomCapaCity);
            info.AddValue("Name", Name);

        }
        /// <summary>
        /// constructor receiving data for serialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public Hotel(SerializationInfo info, StreamingContext context)
        {
            Reservations = (List<Reservation>)info.GetValue("Reservations", typeof(List<Reservation>));
            City = (string)info.GetValue("City", typeof(string));
            Star = (int)info.GetValue("Star", typeof(int));
            Rooms = (List<Room>)info.GetValue("Rooms", typeof(List<Room>));
            RoomCapaCity = (int)info.GetValue("RoomCapacity", typeof(int));
            Name = (string)info.GetValue("Name", typeof(string));


        }
        /// <summary>
        /// default hotel model
        /// </summary>
        /// <param name="City">the City where</param>
        /// <param name="star">the number of stars that you have</param>
        public Hotel(string city, int star,string name)
        {
            
            City = city;
           Star = star; 
           Name = name;
           Rooms = new List<Room>();
            Reservations = new List<Reservation>();
            Random random = new Random();
            switch(star)
            {
                case 1:
                    {
                        RoomCapaCity = random.Next(7, 11);
                        break;
                    }
                case 2:
                    {
                        RoomCapaCity = random.Next(10, 16);
                        break;
                    }
                case 3:
                    {
                        RoomCapaCity = random.Next(15, 21);
                        break;
                    }
                case 4:
                    {
                        RoomCapaCity = random.Next(20, 26);
                        break;
                    }
                case 5:
                    {
                        RoomCapaCity = random.Next(25, 31);
                        break;
                    }
                           
            }

        }

        public Hotel()
        {
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="user">person requesting reservation</param>
        /// <param name="startDate">start date</param>
        /// <param name="endDate">end date</param>
        /// <param name="price">total pay</param>
        /// <param name="roomNo">Requested room</param>
        /// <param name="hotel">Requested hotel</param>
        /// <returns>transaction status</returns>
        public bool makeRezervation(User user, DateTime startDate, DateTime endDate, double price, int roomNo)
        {
            List<Reservation> rez = new List<Reservation>();

            //I have reached the Reservations in the desired room in the hotel
            foreach (Reservation r in Reservations) if (r.roomNo == roomNo) rez.Add(r);

            if (rez.Count == 0)
            {
                Reservations.Add(new Reservation(user, startDate, endDate, price, roomNo, Name));
                return true;
            }

            //conformity check of desired date range
            TimeSpan timeSpan = endDate - startDate;
            if (timeSpan.TotalDays <= 0) return false;

            foreach (Reservation r in rez)
            {
                
                if(r.startDate.Date <= endDate.Date && r.startDate.Date >= startDate.Date ||
                 startDate.Date <= r.endDate.Date && startDate.Date >= r.startDate.Date)
                {
                    return false;
                }
            }

            Reservations.Add(new Reservation(user, startDate, endDate, price, roomNo, Name));
            return true;
        }

        /// <summary>
        /// cancellation of current reservation
        /// </summary>
        /// <param name="rez"></param>
        /// <returns></returns>
        public bool cancelReservation(Reservation rez)
        {
            return Reservations.Remove(rez);
        }
        /// <summary>
        /// for saving information when closing the application
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string space = "";
            if (City.Length < 8)
                for (int i = 0; i < 18 - City.Length; i++) space += " ";

            return Name  +"\t\t" + City + space  + "\t" + Star
                + "\t" + RoomCapaCity + "\t" + Rooms.Count;

        }

       
    }
}
