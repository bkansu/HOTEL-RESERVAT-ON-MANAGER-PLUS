using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Project2
{
    [Serializable()]
   public class User : ISerializable
    {
        private string id = "";
        private string password = "";
        private string name = "";
        private string surname = "";
        private string age = "";


        /// <summary>
        /// it takes all the information necessary for a user and creates the required information
        /// </summary>
        /// <param name="id">usre name</param>
        /// <param name="password"> password login to the system</param>
        /// <param name="name">name of user</param>
        /// <param name="surname">surname of user</param>
        /// <param name="age"> age of user</param>
        public User(string id, string password, string name, string surname, string age)
        {
            ID = id;
            Password = password;
            Name = name;
            Surname = surname;
            Age = age;
          
        }

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
        public User(SerializationInfo info, StreamingContext context)
        {
            ID = (string)info.GetValue("ID", typeof(string));
            Password = (string)info.GetValue("Password", typeof(string));
            Name = (string)info.GetValue("Name", typeof(string));
            Surname = (string)info.GetValue("Surname", typeof(string));
            Age = (string)info.GetValue("Age", typeof(string));
        }



        public User()
        {
        }
       
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                if (!Regex.IsMatch(value, @"^[a-zA-Z0-9_\-\.]+$") ||  id.Equals(value) || value == null || value.Length < 6)
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


        public override string ToString()
        {
            return ID + "    " + Name + "    " + Surname + "    " + Age;
        }

       
    }
}




