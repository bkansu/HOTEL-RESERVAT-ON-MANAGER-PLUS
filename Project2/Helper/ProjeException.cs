using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class ProjeException : Exception
    {
        public string notification { get; set; }
        private string value;

        public ProjeException(string value)
        {
            
            this.value = value;
        }

        /// <summary>
        /// Information format for exception file
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Notification : " + notification + "   Value :  " + value; 
        }
    }
}
