using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    #region Abstract_Factory 
    //Ref Link : https://dzone.com/articles/factory-method-design-pattern
    public class HotelFactory
    {

        /// <summary>
        /// the desired hotel-type object produces
        /// </summary>
        /// <param name="hotelType"> name of hotel</param>
        /// <param name="city"> number of room</param>
        /// <returns>gives the desired hotel</returns>

        public static Hotel GetHotel(string hotelType, string city,string name)
        {

            switch (hotelType)
            {

                case "Hostel":
                    {
                        return new Hostel(city,name);

                    }

                case "BoutiqueHotel":
                    {
                        return new BoutiqueHotel(city, name);

                    }
                case "AllInHotel":
                    {
                        return new AllInHotel(city, name);

                    }
                case "HolidayVillage":
                    {
                        return new HolidayVillage(city, name);

                    }
                case "UltraLuxuryHotel":
                    {
                        return new UltraLuxuryHotel(city, name);

                    }
            
                default:
                    {
                        throw new ProjeException(hotelType == ""  || hotelType == null? "null" : hotelType);

                    }

            }

        }

        /// <summary>
        /// the desired star object produces
        /// </summary>
        /// <param name="star"></param>
        /// <param name="city"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Hotel GetHotel(int star, string city , string name)
        {

            switch (star)
            {

                case 1:
                    {
                        return new Hostel(city, name);

                    }

                case 2:
                    {
                        return new BoutiqueHotel(city, name);

                    }
                case 3:
                    {
                        return new AllInHotel(city, name);

                    }
                case 4:
                    {
                        return new HolidayVillage(city, name);

                    }
                case 5:
                    {
                        return new UltraLuxuryHotel(city, name);

                    }

                default:
                    {
                        throw new ProjeException("Invalid numeric value");

                    }

            }
        }
    }
}
#endregion