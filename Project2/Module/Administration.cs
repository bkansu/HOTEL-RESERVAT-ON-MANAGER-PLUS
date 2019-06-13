using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Project2
{
    #region Singleton
    // we used lazy initialization
    //Ref Link : https://www.geeksforgeeks.org/singleton-design-pattern/
    [Serializable()]
   public class Administration :ISerializable
    {
        private string id = string.Empty;
        private string password = string.Empty;
        private string name = string.Empty;
        private string surname = string.Empty;
        private string age = string.Empty;

        [NonSerialized]
        private static Administration obj;
        /// <summary>
        /// data insertion for serialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ID", ID);
            info.AddValue("Password", Password);
            info.AddValue("Name", Name);
            info.AddValue("Surname", Surname);
            info.AddValue("Age", Age);
        }
        /// <summary>
        /// constructor receiving data for serialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public Administration(SerializationInfo info, StreamingContext context)
        {
            ID = (string)info.GetValue("ID", typeof(string));
            Password = (string)info.GetValue("Password", typeof(string));
            Name = (string)info.GetValue("Name", typeof(string));
            Surname = (string)info.GetValue("Surname", typeof(string));
            Age = (string)info.GetValue("Age", typeof(string));
        }

        private Administration(string id, string password, string name, string surname, string age)
        {
            ID = id;
            Password = password;
            Name = name;
            Surname = surname;
            Age = age;
        }


        public Administration()
        {
        }

        public static Administration getInstance(string id, string password, string name, string surname, string age)
        {
            if (obj == null)
            {
                obj = new Administration(id, password, name, surname, age);
                return obj;
            }
            return null;
        }

        public static Administration getInstance(App app)
        {
            if (obj == null)
            {
                obj = app.admin;
                return obj;
            }
            return null;
        }
        public static Administration getAdmin()
        {
           
            return obj;       
        }

       

        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                if (!Regex.IsMatch(value, @"^[a-zA-Z0-9_\-\.]+$") || id.Equals(value) || value == null || value.Length < 6)
                {
                    throw new ProjeException(value == null || value == "" ? "null" : value.ToString());
                }
                else id = value;

            }

        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password.Equals(value) || value == null || value.Length < 6)
                {
                    throw new ProjeException(value == null || value == "" ? "null" : value.ToString());
                }
                else password = value;

            }

        }


        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!Regex.IsMatch(value, @"^[a-zA-Z\s]+$") || name.Equals(value) || value[0] == ' ' || value == null || value.Length < 3)
                {
                    throw new ProjeException(value == null || value == "" ? "null" : value.ToString());
                }
                else name = value;

            }

        }

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if (!Regex.IsMatch(value, @"^[a-zA-Z]+$") || surname.Equals(value) || value == null || value.Length < 3)
                {
                    throw new ProjeException(value == null || value == "" ? "null" : value.ToString());
                }
                else surname = value;

            }

        }

        public string Age
        {
            get
            {
                return age;
            }
            set
            {
                if (!Regex.IsMatch(value, @"^[0-9]+$") || value == null || value.Length != 2 || Convert.ToInt32(value) < 18 || age.Equals(value))
                {
                    throw new ProjeException(value == null || value == "" ? "null" : value.ToString());
                }
                else age = value;

            }

        }
    }
}
#endregion