using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project2
{
    class AdminModule 
    {

        private Administration admin;
        private App app;
        public AdminModule(ref Administration admin , ref App app)
        {
            this.admin = admin;
            this.app = app;
        }
        /// <summary>
        /// id changing process
        /// </summary>
        /// <param name="data">new ıd</param>
        /// <returns></returns>
        public bool updateId(string data)
        {

            try
            {
                admin.ID = data;
            }
            catch (ProjeException e)
            {
                e.notification = "AdminModule ->> updateId()";
                Logger.writeExceptionLog(e.ToString());
                return false;
            }

            return true;

        }
        /// <summary>
        /// password changing process
        /// </summary>
        /// <param name="data">new password</param>
        /// <returns></returns>

        public bool updatePassword(string data)
        {

            try
            {
                admin.Password = data;
            }
            catch (ProjeException e)
            {
                e.notification = "AdminModule ->> updatePassword()";
                Logger.writeExceptionLog(e.ToString());
                return false;
            }

            return true;
        }

        /// <summary>
        /// name changing process
        /// </summary>
        /// <param name="data">new name</param>
        /// <returns></returns>
        public bool updateName(string data)
        {
            try
            {
                admin.Name = data;
            }
            catch (ProjeException e)
            {
                e.notification = "AdminModule->> updateName()";
                Logger.writeExceptionLog(e.ToString());
                return false;
            }

            return true;
        }

        /// <summary>
        /// surname changing process
        /// </summary>
        /// <param name="data">new surname</param>
        /// <returns></returns>
        public bool updateSurname(string data)
        {
            try
            {
                admin.Surname = data;
            }
            catch (ProjeException e)
            {
                e.notification = "AdminModule ->> updateSurname()";
                Logger.writeExceptionLog(e.ToString());
                return false;
            }

            return true;
        }
        /// <summary>
        /// age changing process
        /// </summary>
        /// <param name="data">new age</param>
        /// <returns></returns>
        public bool updateAge(string data)
        {
            try
            {
                admin.Age = data;
            }
            catch (ProjeException e)
            {
                e.notification = "AdminModule ->> updateAge()";
                Logger.writeExceptionLog(e.ToString());
                return false;
            }

            return true;
        }
        /// <summary>
        /// hotel add process for administrator
        /// </summary>
        /// <param name="cityName"> the city where the hotel will be located</param>
        /// <param name="star">star of hotel</param>
        /// <param name="name">name of hotel</param>
        /// <returns>transaction status</returns>
        public bool addHotel(string cityName , int star,string name)
        {
         
            if (!name.All(c => Char.IsLetter(c) || c == ' ') || name.Equals("")) return false;

            foreach (Hotel item in app.hotels)
                if (item.Name.Equals(name) && item.Star == star && item.City.Equals(cityName.ToUpper())) return false;

            app.hotels.Add(HotelFactory.GetHotel(star,cityName.ToUpper(),name));
            return true;

        }

        /// <summary>
        /// hotel deletion for administrator
        /// </summary>
        /// <param name="hotel">hotel to be deleted</param>
        /// <returns>transaction status</returns>
        public bool deleteHotel(Hotel hotel)
        {
            if (hotel == null) return false;
           return app.hotels.Remove(hotel);
            
           
        }

        /// <summary>
        /// add room for administrator
        /// </summary>
        /// <param name="index">hotel index of the room to be added</param>
        /// <param name="roomType">type of room to add</param>
        /// <returns>transaction status</returns>
        public bool addRoom(int index , string roomType)
        {
            if (  index >= 0 && app.hotels[index].RoomCapaCity  >  app.hotels[index].Rooms.Count )
            {
                int no = (app.hotels[index].Rooms.Count == 0) ? 100 : app.hotels[index].Rooms.Last().no + 1;
                app.hotels[index].Rooms.Add(RoomFactory.GetRoom(roomType, no, app.hotels[index].Star));
                return true;
            }
            return false;
        }

        /// <summary>
        /// room deletion for administrator
        /// </summary>
        /// <param name="index">hotel index of the room to be deleted</param>
        /// <param name="roomNo">number of room</param>
        /// <returns>transaction status</returns>
        public bool deleteRoom(int index , int roomNo)
        {
  
            if (app.hotels[index].Rooms.Count == 0) return false;
            for (int i = 0; i < app.hotels[index].Rooms.Count; i++)
            {
                if(app.hotels[index].Rooms[i].no == roomNo)
                {
                    app.hotels[index].Rooms.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// writes summary information to file in specific date range
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public bool summaryInfo(DateTime start , DateTime end)
        {
            TimeSpan s = end - start;
            string data = "";
            int fullRoomCount = 0;
            if (s.TotalDays <= 0) return false;
            List<string> fullRoom = new List<string>();
            DateTime time = start.Date;
            for (int i = 0; i < s.TotalDays; i++)
            {
                data += Environment.NewLine + time.ToString("dd//MM/yyyy") + "--------------------------" + Environment.NewLine;
                foreach (Hotel hotel in app.hotels)
                {
                    data += hotel.Name;
                    foreach (Reservation r in hotel.Reservations)
                    {
                        if ( time.Date >= r.startDate.Date && time.Date <= r.endDate.Date)
                        {
                            fullRoomCount++;
                            fullRoom.Add(r.roomNo.ToString() + "  Total paid amount : " + r.price.ToString() + "   " + r.user.ToString());
                        }
                    }
                    data += "   Full Room Count : " + fullRoomCount + "  Full Rooms No : ";
                    foreach (string item in fullRoom) data += item + "   ||   " ;
                    data += Environment.NewLine;
 
                    fullRoomCount = 0;
                    fullRoom.Clear();

                }
                data += Environment.NewLine + "----------------------------------------------" + Environment.NewLine;
                time = time.AddDays(1);
            }
            Logger.writeSummaryLog(data);

            return true;         
        }
       
        
    }
}
