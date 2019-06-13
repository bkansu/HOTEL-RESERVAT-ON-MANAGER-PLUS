using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    #region Abstract_Factory 
    //Ref Link : https://dzone.com/articles/factory-method-design-pattern
    public class RoomFactory
    {
     private static   Random random = new Random(DateTime.Now.Millisecond);
        /// <summary>
        /// the desired room-type object produces
        /// </summary>
        /// <param name="roomType"> name of room</param>
        /// <param name="roomNo"> number of room</param>
        /// <returns> gives the desired room</returns>

        public static Room GetRoom(string roomType, int roomNo,int star)
        {

            int minPrice = 0, maxPrice = 0;
            List<string> roomContents = new List<string>();

            addDefaultContent(ref roomContents,  ref minPrice , ref maxPrice, star, roomType);
            


            switch (roomType)
            {
                

                case "KingRoom":
                    {
                        return new KingRoom(roomNo,roomContents,minPrice,maxPrice);

                    }

                case "FamilyRoom":
                    {
                        return new FamilyRoom(roomNo, roomContents, minPrice, maxPrice);

                    }
                case "SingleBedRoom":
                    {
                        return new SingleBedRoom(roomNo, roomContents, minPrice, maxPrice);

                    }
                case "ThreeBedRoom":
                    {
                        return new ThreeBedRoom(roomNo, roomContents, minPrice, maxPrice);
                    }
                case "TwinRoom":
                    {
                        return new TwinRoom(roomNo, roomContents, minPrice, maxPrice);

                    }
                case "TwoBedRoom":
                    {
                        return new TwoBedRoom(roomNo, roomContents, minPrice, maxPrice);

                    }
                default:
                    {
                        throw new ProjeException(roomType == null || roomType == "" ? "null" : roomType);

                    }
            }

          
        }
        /// <summary>
        /// inserts the required values ​​into the room
        /// </summary>
        /// <param name="roomContents"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="star"></param>
        /// <param name="roomType"></param>
        private static void addDefaultContent(ref List<string> roomContents, ref int min , ref int max,int star , string roomType)
        {
           
            
            switch (roomType)
            {


                case "KingRoom":
                    {
                        min = 600 * star;
                        max = 700 * star;
                        roomContents.Add("Free Wifi");
                        roomContents.Add("mini bar");
                        roomContents.Add("jacuzzi");
                        roomContents.Add("TV");
                        roomContents.Add("Balcony");
                        roomContents.Add("Tea, coffee, water, espresso-machine");
                        roomContents.Add("Gold plated toilet");
                        break;

                    }

                case "FamilyRoom":
                    {
                        min = 470 * star;
                        max = 570 * star;
                        roomContents.Add("Free Wifi");
                        roomContents.Add("Crib");
                        roomContents.Add("TV");
                        roomContents.Add("Balcony");
                        roomContents.Add("Climate");
                      
                        break;
                    }
                case "SingleBedRoom":
                    {

                        min = 60 * star;
                        max = 110 * star;
                        roomContents.Add("Free Wifi");
                        roomContents.Add("TV");
                        break;

                    }
                case "ThreeBedRoom":
                    {
                        roomContents.Add("TV");
                        roomContents.Add("Free Wifi");
                        roomContents.Add("Tea, coffee, water, espresso-machine");
                        roomContents.Add("Climate");
                        min = 350 * star;
                        max = 450 * star;
                        break;

                    }
                case "TwinRoom":
                    {
                        roomContents.Add("TV");
                        roomContents.Add("Free Wifi");
                        roomContents.Add("Climate");
                        min = 220 * star;
                        max = 320 * star;
                        break;

                    }
                case "TwoBedRoom":
                    {
                        roomContents.Add("TV");
                        roomContents.Add("Free Wifi");
                        roomContents.Add("Climate");
                        min = 140 * star;
                        max = 210 * star;
                        break;

                    }

            }

           int pr = random.Next(1, 5);
            if (pr == 1) roomContents.Add("Pool view");
            else if (pr == 2) roomContents.Add("Forest view");
            else if (pr == 3) roomContents.Add("Sea view");
            else roomContents.Add("Lake view");


        }
    }
}
#endregion