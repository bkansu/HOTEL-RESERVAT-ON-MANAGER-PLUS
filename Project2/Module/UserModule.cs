using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project2
{
    class UserModule 
    {
       
        private App app;
        private User user;
        /// <summary>
        /// for the logged-in user to take action
        /// </summary>
        /// <param name="app">system used</param>
        public UserModule( ref App app)
        {
            this.app = app;
            user = app.users[app.activeUserLocation];
           
        }

        /// <summary>
        /// user makes reservations
        /// </summary>
        /// <param name="hotelName">name of hotel</param>
        /// <param name="star">star of hotel</param>
        /// <param name="totalPrice">total Price</param>
        /// <param name="startDate">check in</param>
        /// <param name="endDate">check out</param>
        /// <param name="roomNo">room no for stay </param>
        /// <returns></returns>
        public bool makeReservation(string hotelName , int star , double totalPrice , DateTime startDate , DateTime endDate , int roomNo)
        {
            foreach(Hotel item in app.hotels)
            {
                if(item.Name.Equals(hotelName))
                {

                    return item.makeRezervation(user, startDate, endDate, totalPrice, roomNo);
                   
                }
            }
            return false;
        }

        /// <summary>
        /// deletes his last reservation
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        public bool cancelReservation(string cancelRezData)
        {

            foreach (Hotel hotel in app.hotels)
            {
                foreach (Reservation r in hotel.Reservations)
                {

                    if (r.ToString().Equals(cancelRezData))
                    {
                        return hotel.cancelReservation(r);
                        

                    }

                }

            }
            return false;
            

        }

        /// <summary>
        /// brings the desired room feature list
        /// </summary>
        /// <param name="hotelName"> name of hotel</param>
        /// <param name="roomNo">room no for getting contents</param>
        /// <returns>roomContents</returns>
        public List<string> getRoomContents(string hotelName , string roomNo)
        {
            
            foreach (Hotel h in app.hotels)
            {
                if (h.Name.Equals(hotelName))
                {
                    foreach (Room room in h.Rooms)
                    {
                        if (room.no.ToString().Equals(roomNo))
                        {
                            return room.roomContents;
                        }
                    }
                }

            }
            return null;
        }

        /// <summary>
        /// retrieves current bookings of the user using the system
        /// </summary>
        /// <returns>rez data</returns>
        public List<string> getActualReservation()
        {
            List<string> data = new List<string>();
            foreach (Hotel hotel in app.hotels)
            {
                foreach (Reservation r in hotel.Reservations)
                {

                    if (r.user.Equals(app.users[app.activeUserLocation].ToString()))
                    {
                        data.Add(r.ToString());
                    }

                }
            }
            return data;
        }
        /// <summary>
        /// finds all unique room types of the desired hotel 
        /// </summary>
        public List<string> getUniqueRoomTypes(string city , string star , string name)
        {
            List<string> data = new List<string>();
            foreach (Hotel hotel in app.hotels)
            {
                if (hotel.City.Equals(city) && hotel.Star.ToString().Equals(star) && hotel.Name.ToString().Equals(name))
                {
                    foreach (Room room in hotel.Rooms)
                    {
                        if (!data.Contains(room.GetType().Name)) data.Add(room.GetType().Name);
                    }
                }
            }
            return data;
        }

        /// <summary>
        /// finds all unique hotel name of system
        /// </summary>
        public List<string> getUniqueHotelName(string city , string star)
        {
            List<string> data = new List<string>();


            foreach (Hotel hotel in app.hotels)
            {
                if (hotel.Star.ToString().Equals(star) && hotel.City.ToString().Equals(city))
                {
                    data.Add(hotel.Name);
                }
            }
            return data;
        }

        /// <summary>
        /// finds all unique hotel star of system
        /// </summary>
        public List<string> getUniqueHotelStar(string city)
        {
            List<string> data = new List<string>();

            foreach (Hotel hotel in app.hotels)
            {
                if (hotel.City.Equals(city) && !data.Contains(hotel.Star.ToString()))
                {
                    data.Add(hotel.Star.ToString());
                }
            }

            return data;
        }

        /// <summary>
        /// finds all unique hotel city of system
        /// </summary>
        public List<string> getUniqueHotelCity()
        {
            List<string> data = new List<string>();
            foreach (Hotel hotel in app.hotels)
            {
                if (!data.Contains(hotel.City)) data.Add(hotel.City);
            }

            return data;
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
                user.ID = data;
            }
            catch(ProjeException e)
            {
                e.notification = "UserModule ->> updateId()";
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
                user.Password = data;
            }
            catch (ProjeException e)
            {
                e.notification = "UserModule ->> updatePassword()";
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
                user.Name = data;
            }
            catch (ProjeException e)
            {
                e.notification = "UserModule ->> updateName()";
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
                user.Surname = data;
            }
            catch (ProjeException e)
            {
                e.notification = "UserModule ->> updateSurname()";
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
                user.Age = data;
            }
            catch (ProjeException e)
            {
                e.notification = "UserModule ->> updateAge()";
                Logger.writeExceptionLog(e.ToString());
                return false;
            }

            return true;
        }

    }
}
