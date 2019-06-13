using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;

namespace Project2
{
    [Serializable()]
   public class App : ISerializable
    {
        public List<Hotel> hotels { get; set; }
        public List<User> users { get; set; }
        public DateTime StartAppTime { get; set; }
        public Administration admin { get; set; }
 
        public  int  activeUserLocation{ get; set; }
        
        [NonSerialized]
        private static App obj;

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Hotels", hotels);
            info.AddValue("Users", users);
            info.AddValue("StartAppTime", StartAppTime);
            info.AddValue("Admin", admin);
            
        }
        public App(SerializationInfo info, StreamingContext context)
        {
            hotels = (List<Hotel>)info.GetValue("Hotels", typeof(List<Hotel>));
            users = (List<User>)info.GetValue("Users", typeof(List<User>));
            StartAppTime = (DateTime)info.GetValue("StartAppTime", typeof(DateTime));
            admin = (Administration)info.GetValue("Admin", typeof(Administration));
        }



        public App()
        {   
        }

       

        public static App getInstance()
        {
            if (obj == null)
            {
                obj = new App();
                obj.Load();
                return obj;
            }
            return obj;
        }
        public  void Load()
        {
            if (continueApp() == null)
            {
                StartAppTime = DateTime.Today.Date;
                //the first time the program opens
                //that is, if there is no recorded history         
                firstBoot();
            }
            else
            {
                obj = (App)continueApp();
                obj.admin = Administration.getInstance(obj);
            }
        }
        /// <summary>
        /// deserialization process
        /// </summary>
        /// <returns>app object</returns>
        private object continueApp()
        {
            object obj;
            try
            {
                Logger.Deserializer();
            }
            catch (InvalidOperationException e)
            {
                obj = null;
                Logger.writeExceptionLog(e.ToString());
                return obj;
            }
            obj = Logger.Deserializer();
           
             
            return obj;

        }
        /// <summary>
        /// serialization process
        /// </summary>
        public  void Save()
        {

            Logger.serialize(this);
        }

        public bool addUser(User user)
        {
            if (user.ID.ToLower().Contains("admin")) return false;
            if (users.Count == 0)
            {
                users.Add(user);
                return true;
            }
            foreach(User item in users) if (item.ID.ToLower().Equals(user.ID.ToLower())) return false;
            users.Add(user);
           
            return true;
        }

        public bool login(string id , string password )
        {
            if (users.Count == 0)
            {
                activeUserLocation = -1;
                return false;
                
            }

            for (int i = 0; i < users.Count; i++)
            {
                if(users[i].ID.Equals(id) && users[i].Password.Equals(password))
                {
                    activeUserLocation = i;
                    return true;
                }
            }
            activeUserLocation = -1;
            return false;
        }

        

        /// <summary>
        /// auto adds hotels
        /// default 30 otel and random Rooms
        /// </summary>
        private void firstBoot()
        {
            //added default instance
            hotels = new List<Hotel>();
            users = new List<User>();
            admin = Administration.getInstance("admin1", "password1", "Mustafa Firat", "YILMAZ", "21");
            users.Add(new User("user001", "password001", "name", "surname", "99"));
            users.Add(new User("user002", "password002", "name", "surname", "99"));
            users.Add(new User("user003", "password003", "name", "surname", "99"));
            users.Add(new User("user004", "password004", "name", "surname", "99"));
            users.Add(new User("user005", "password005", "name", "surname", "99"));

            int n = 1;
            string defaultHotelName = "Hotel" + n;

            //added hotel
            Random random = new Random();
            int k;
            string type = null;
            string[] data = { "ISTANBUL", "CANAKKALE", "IZMIR", "KOCAELI", "ANKARA", "ANTALYA", "MUGLA", "VAN", "KARS", "ESKISEHIR" };
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    
                    k = random.Next(1, 6);
                    type = null;
                
                    switch (k)
                    {
                        case 1:
                            {
                                type = "Hostel";
                                break;

                            }
                        case 2:
                            {
                                type = "BoutiqueHotel";
                                break;

                            }
                        case 3:
                            {
                                type = "AllInHotel";
                                break;

                            }
                        case 4:
                            {
                                type = "HolidayVillage";
                                break;

                            }
                        case 5:
                            {
                                type = "UltraLuxuryHotel";
                                break;

                            }
                    }
                    hotels.Add(HotelFactory.GetHotel(type, data[i],defaultHotelName));

                    n++;
                    defaultHotelName = "Hotel" + n;

                }
              

            }
            //added Rooms
            for (int i = 0; i < hotels.Count; i++) addRoom(hotels[i]);
     
        }

        /// <summary>
        /// Creating and adding Rooms by hotel Star
        /// </summary>
        /// <param name="hotel">hotel instance</param>
        private void addRoom(Hotel hotel)
        {
            switch(hotel.Star)
            {
                case 1:
                    {                       
                        int num = 100;
                        for (int i = 0; i < hotel.RoomCapaCity / 2; i++)
                        {
                            num++;
                           hotel.Rooms.Add(RoomFactory.GetRoom("SingleBedRoom", num,hotel.Star));
                        }
                        num = 200;
                        for (int i = 0; i < hotel.RoomCapaCity - hotel.RoomCapaCity / 2; i++)
                        {
                            num++;
                           hotel.Rooms.Add(RoomFactory.GetRoom("TwoBedRoom", num, hotel.Star));
                        }
                        //wrong room name
                        try
                        {
                            hotel.Rooms.Add(RoomFactory.GetRoom("Tsadasm", 518, hotel.Star));
                        }
                        catch (ProjeException e)
                        {
                            e.notification = "App ->> AddRoom()";
                            Logger.writeExceptionLog(e.ToString());
                        }

                        break;

                    }
                case 2:
                    {
                      
                        int num = 100;
                        for (int i = 0; i < hotel.RoomCapaCity / 3; i++)
                        {
                            num++;
                           hotel.Rooms.Add(RoomFactory.GetRoom("SingleBedRoom", num, hotel.Star));
                        }
                        num = 200;
                        for (int i = 0; i < hotel.RoomCapaCity / 3; i++)
                        {
                            num++;
                            hotel.Rooms.Add(RoomFactory.GetRoom("TwoBedRoom", num, hotel.Star));
                        }

                        num = 300;
                        for (int i = 0; i < hotel.RoomCapaCity - ((hotel.RoomCapaCity / 3) * 2); i++)
                        {
                            num++;
                            hotel.Rooms.Add(RoomFactory.GetRoom("TwinRoom", num, hotel.Star));
                        }

                        //null room name
                        try
                        {
                            hotel.Rooms.Add(RoomFactory.GetRoom(null, 312, hotel.Star));
                        }
                        catch (ProjeException e)
                        {
                            e.notification = "App ->> AddRoom()";
                            Logger.writeExceptionLog(e.ToString());
                        }
                        break;

                    }
                case 3:
                    {
                        int num = 100;
                        for (int i = 0; i < hotel.RoomCapaCity / 4; i++)
                        {
                            num++;
                           hotel.Rooms.Add(RoomFactory.GetRoom("SingleBedRoom", num, hotel.Star));
                        }
                        num = 200;
                        for (int i = 0; i < hotel.RoomCapaCity / 4; i++)
                        {
                            num++;
                            hotel.Rooms.Add(RoomFactory.GetRoom("TwoBedRoom", num, hotel.Star));
                        }

                        num = 300;
                        for (int i = 0; i < hotel.RoomCapaCity / 4; i++)
                        {
                            num++;
                            hotel.Rooms.Add(RoomFactory.GetRoom("TwinRoom", num, hotel.Star));
                        }


                        num = 400;
                        for (int i = 0; i < hotel.RoomCapaCity - ((hotel.RoomCapaCity / 4) * 3); i++)
                        {
                            num++;
                            hotel.Rooms.Add(RoomFactory.GetRoom("ThreeBedRoom", num, hotel.Star));
                        }

                        //wrong room name
                        try
                        {
                            hotel.Rooms.Add(RoomFactory.GetRoom("adsadasda", 426, hotel.Star));
                        }
                        catch (ProjeException e)
                        {
                            e.notification = "App ->> AddRoom()";
                            Logger.writeExceptionLog(e.ToString());
                        }
                        break;

                    }
                case 4:
                    {
                        int num = 100;
                        for (int i = 0; i < hotel.RoomCapaCity / 5; i++)
                        {
                            num++;
                            hotel.Rooms.Add(RoomFactory.GetRoom("SingleBedRoom", num, hotel.Star));
                        }
                        num = 200;
                        for (int i = 0; i < hotel.RoomCapaCity / 5; i++)
                        {
                            num++;
                            hotel.Rooms.Add(RoomFactory.GetRoom("TwoBedRoom", num, hotel.Star));
                        }

                        num = 300;
                        for (int i = 0; i < hotel.RoomCapaCity / 5; i++)
                        {
                            num++;
                            hotel.Rooms.Add(RoomFactory.GetRoom("TwinRoom", num, hotel.Star));
                        }


                        num = 400;
                        for (int i = 0; i < hotel.RoomCapaCity / 5; i++)
                        {
                            num++;
                            hotel.Rooms.Add(RoomFactory.GetRoom("ThreeBedRoom", num, hotel.Star));
                        }

                        num = 500;
                        for (int i = 0; i < hotel.RoomCapaCity - ((hotel.RoomCapaCity / 5) * 4); i++)
                        {
                            num++;
                            hotel.Rooms.Add(RoomFactory.GetRoom("FamilyRoom", num, hotel.Star));
                        }

                        //null room name
                        try
                        {
                            hotel.Rooms.Add(RoomFactory.GetRoom(null, 718, hotel.Star));
                        }
                        catch (ProjeException e)
                        {
                            e.notification = "App ->> AddRoom()";
                            Logger.writeExceptionLog(e.ToString());
                        }
                        break;

                    }
                case 5:
                    {
                        int num = 100;
                        for (int i = 0; i < hotel.RoomCapaCity / 6; i++)
                        {
                            num++;
                            hotel.Rooms.Add(RoomFactory.GetRoom("SingleBedRoom", num, hotel.Star));
                        }
                        num = 200;
                        for (int i = 0; i < hotel.RoomCapaCity / 6; i++)
                        {
                            num++;
                            hotel.Rooms.Add(RoomFactory.GetRoom("TwoBedRoom", num, hotel.Star));
                        }

                        num = 300;
                        for (int i = 0; i < hotel.RoomCapaCity / 6; i++)
                        {
                            num++;
                            hotel.Rooms.Add(RoomFactory.GetRoom("TwinRoom", num, hotel.Star));
                        }


                        num = 400;
                        for (int i = 0; i < hotel.RoomCapaCity / 6; i++)
                        {
                            num++;
                            hotel.Rooms.Add(RoomFactory.GetRoom("ThreeBedRoom", num, hotel.Star));
                        }

                        num = 500;
                        for (int i = 0; i < hotel.RoomCapaCity / 6; i++)
                        {
                            num++;
                            hotel.Rooms.Add(RoomFactory.GetRoom("FamilyRoom", num, hotel.Star));
                        }

                        num = 600;
                        for (int i = 0; i < hotel.RoomCapaCity - ((hotel.RoomCapaCity / 6) * 5); i++)
                        {
                            num++;
                            hotel.Rooms.Add(RoomFactory.GetRoom("KingRoom", num, hotel.Star));
                        }


                        //wrong room name
                        try
                        {
                            hotel.Rooms.Add(RoomFactory.GetRoom("mustafa", 333, hotel.Star));
                        }
                        catch (ProjeException e)
                        {
                            e.notification = "App ->> AddRoom()";
                            Logger.writeExceptionLog(e.ToString());
                        }

                        break;

                    }
            }

        }

       
    }
}
