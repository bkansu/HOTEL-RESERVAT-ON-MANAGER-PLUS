using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project2


{
    class Logger
    {
        /// <summary>
        /// serialize process for data
        /// </summary>
        /// <param name="app"></param>
        public static void serialize(App app)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(App));

            StreamWriter tt = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Data\\appData2.xml");
            serializer.Serialize(tt,app);

        }

        /// <summary>
        /// backup process
        /// </summary>
        /// <returns> last saved App instance</returns>
        public static object Deserializer()
        {
           
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Data\\appData2.xml";
            XmlSerializer deserializer = new XmlSerializer(typeof(App));

            TextReader reader = new StreamReader(path);
            object obj = deserializer.Deserialize(reader);
               
            reader.Close();
          
            return obj;
        }


        /// <summary>
        /// writes exceptions to the user when the application closes
        /// </summary>
        public static void writeExceptionLog(string data)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\LogsFile\\ExceptionLogs.txt";
                                                    //append
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine(data);
            sw.Close();
            
          
        }

        /// <summary>
        /// writes summary information to file
        /// </summary>
        /// <param name="data"></param>
        public static void writeSummaryLog(string data)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\LogsFile\\SummaryLogs.txt";
            
            File.WriteAllText(path, string.Empty);

            try
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write);

                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(data);

                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                e.ToString();
            }

        }


    }
}