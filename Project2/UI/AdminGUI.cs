using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    public partial class AdminGUI : Form
    {
        private App app;
        private Administration admin;
        private AdminModule aModule;
        
        
        public AdminGUI()
        {
            app = App.getInstance();
            admin = Administration.getAdmin();
            InitializeComponent();
        }

        /// <summary>
        /// neccary for admin module argument and data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ElTuristiko_Load(object sender, EventArgs e)
        {
            double TotalPrice = 0;
            foreach(Hotel hotel in app.hotels)
            {
                foreach(Reservation r in hotel.Reservations)
                {
                    TotalPrice += r.price;
                }
            }
            label15.Text = TotalPrice.ToString();

            foreach (User user in app.users) listBox2.Items.Add(user.ToString());
            CitiesLoad();
            label12.Text = app.admin.ID;
            label11.Text = app.admin.Password;
            label10.Text = app.admin.Name;
            label9.Text = app.admin.Surname;
            label8.Text = app.admin.Age;
            for (int i = 0; i < app.hotels.Count; i++)
            {
                listBox1.Items.Add(app.hotels[i].ToString());
            }
            label32.Text = app.hotels.Count.ToString();
            label26.Visible = true;
            label27.Visible = true;
            label28.Visible = true;
            label29.Visible = true;
            label30.Visible = true;
            listBox1.Visible = true;

            //datetime picker range
            dateTimePicker1.MinDate = app.StartAppTime.Date;
            dateTimePicker2.MinDate = app.StartAppTime.Date;
            DateTime last = app.StartAppTime.AddYears(1);
            dateTimePicker1.MaxDate = last;
            dateTimePicker2.MaxDate = last;
                   
            
            
            aModule = new AdminModule(ref admin, ref app);


        }

        // available City name in TURKEY
        private  void CitiesLoad()
        {
            string[] cities = {"Adana", "Adıyaman", "Afyon", "Ağrı", "Amasya", "Ankara", "Antalya", "Artvin",
"Aydın", "Balıkesir", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale",
"Çankırı", "Çorum", "Denizli", "Diyarbakır", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir",
"Gaziantep", "Giresun", "Gümüşhane", "Hakkari", "Hatay", "Isparta", "Mersin", "İstanbul", "İzmir",
"Kars", "Kastamonu", "Kayseri", "Kırklareli", "Kırşehir", "Kocaeli", "Konya", "Kütahya", "Malatya",
"Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Rize", "Sakarya",
"Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Şanlıurfa", "Uşak",
"Van", "Yozgat", "Zonguldak", "Aksaray", "Bayburt", "Karaman", "Kırıkkale", "Batman", "Şırnak",
"Bartın", "Ardahan", "Iğdır", "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce"};

            for (int i = 0; i < 81; i++)
            {
                comboBox2.Items.Add(cities[i]);
            }
        }

        /// <summary>
        /// shows arguments for id update 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label12_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            textBox1.Visible = true;
        }

        /// <summary>
        /// shows arguments for password update 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label11_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            textBox2.Visible = true;
        }
        /// <summary>
        /// shows arguments for name update 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label10_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            textBox3.Visible = true;
        }

        /// <summary>
        /// shows arguments for surname update 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label9_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
            textBox4.Visible = true;
        }

        /// <summary>
        /// shows arguments for age update 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label8_Click(object sender, EventArgs e)
        {
            button5.Visible = true;
            textBox5.Visible = true;
        }

        /// <summary>
        /// admin id update process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (aModule.updateId(textBox1.Text))
            {
                AutoClosingMessageBox.Show("Transaction successful", "Notification", 1000);
                label12.Text = app.admin.ID;
            }
            else AutoClosingMessageBox.Show("Invalid UserName", "Notification", 1000);
            textBox1.Text = "";
            textBox1.Visible = false;
            button1.Visible = false;
        }

        /// <summary>
        /// admin password update process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (aModule.updatePassword(textBox2.Text))
            {
                AutoClosingMessageBox.Show("Transaction successful", "Notification", 1000);
                label11.Text = app.admin.Password;
            }
            else AutoClosingMessageBox.Show("Invalid Password", "Notification", 1000);
            textBox2.Text = "";
            textBox2.Visible = false;
            button2.Visible = false;
        }

        /// <summary>
        /// admin name update process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (aModule.updateName(textBox3.Text))
            {
                AutoClosingMessageBox.Show("Transaction successful", "Notification", 1000);
                label10.Text = app.admin.Name;
            }
            else AutoClosingMessageBox.Show("Invalid Name", "Notification", 1000);
            textBox3.Text = "";
            textBox3.Visible = false;
            button3.Visible = false;
        }


        /// <summary>
        /// admin surname update process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (aModule.updateSurname(textBox4.Text))
            {
                AutoClosingMessageBox.Show("Transaction successful", "Notification", 1000);
                label9.Text = app.admin.Surname;
            }
            else AutoClosingMessageBox.Show("Invalid Surname", "Notification", 1000);
            textBox4.Text = "";
            textBox4.Visible = false;
            button4.Visible = false;
        }

        /// <summary>
        /// admin age update process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            if (aModule.updateAge(textBox5.Text))
            {
                AutoClosingMessageBox.Show("Transaction successful", "Notification", 1000);
                label8.Text = app.admin.Age;
            }
            else AutoClosingMessageBox.Show("Invalid Age", "Notification", 1000);
            textBox5.Text = "";
            textBox5.Visible = false;
            button5.Visible = false;
        }

        /// <summary>
        /// hotel insertion process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {

            
            if (aModule.addHotel(comboBox2.Text, Convert.ToInt32(comboBox1.Text), textBox8.Text))
            {
                AutoClosingMessageBox.Show("Transaction successful", "Notification", 1000);
            }
            else AutoClosingMessageBox.Show("Operation failed", "Notification", 1000);

            button6.Visible = false;
            comboBox2.Visible = false;
            comboBox1.Visible = false;
            textBox8.Visible = false;
            textBox8.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;

            listBox1.Items.Clear();
            for (int i = 0; i < app.hotels.Count; i++)
            {
                listBox1.Items.Add(app.hotels[i].ToString());
            }
            label32.Text = app.hotels.Count.ToString();

        }

        /// <summary>
        ///  shows arguments for insertion 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label17_Click(object sender, EventArgs e)
        {

            button6.Visible = true;
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            textBox8.Visible = true;
            label22.Visible = true;
            label23.Visible = true;
            label24.Visible = true;
            comboBox1.Text = comboBox1.Items[0].ToString();
            comboBox2.Text = comboBox2.Items[0].ToString();
        }

        /// <summary>
        /// shows arguments for delete 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label18_Click(object sender, EventArgs e)
        {
            label31.Visible = true;
            button7.Visible = true;
             
        }

        /// <summary>
        /// delete process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex > -1)
            {
                aModule.deleteHotel(app.hotels[listBox1.SelectedIndex]);
                AutoClosingMessageBox.Show("Transaction successful", "Notification", 1000);
            }
            else AutoClosingMessageBox.Show("Operation failed", "Notification", 1000);
            label31.Visible = false;
            button7.Visible = false;
            label31.Text = "To be deleted,\ndouble-click(from the list at the top right) on one and press the Delete button";
            label33.Text = "To add a room,\nfirst select the hotel from the list, then select room type, click the last add button";
            label36.Text = "To delete a room,\nfirst select the hotel from the list, then select room number, click the last delete button";

            listBox1.Items.Clear();
            for (int i = 0; i < app.hotels.Count; i++)
            {
                listBox1.Items.Add(app.hotels[i].ToString());
            }
            label32.Text = app.hotels.Count.ToString();
        }
        /// <summary>
        /// adds arguments to be used for list related operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           if(label31.Visible) label31.Text = app.hotels[listBox1.SelectedIndex].Name + "  " + app.hotels[listBox1.SelectedIndex].City +"  " + app.hotels[listBox1.SelectedIndex].Star;
           if(label33.Visible) label33.Text = app.hotels[listBox1.SelectedIndex].Name + "  " + app.hotels[listBox1.SelectedIndex].City + "  " + app.hotels[listBox1.SelectedIndex].Star;
            if (label36.Visible)
            {
                label36.Text = app.hotels[listBox1.SelectedIndex].Name + "  " + app.hotels[listBox1.SelectedIndex].City + "  " + app.hotels[listBox1.SelectedIndex].Star;
                if (listBox1.SelectedIndex >= 0)
                {
                    comboBox4.Items.Clear();

                    for (int i = 0; i < app.hotels[listBox1.SelectedIndex].Rooms.Count; i++)
                    {
                        comboBox4.Items.Add(app.hotels[listBox1.SelectedIndex].Rooms[i].no);
                    }
                }
                comboBox4.Text = (comboBox4.Items.Count !=0) ? comboBox4.Items[0].ToString() : "";
            }

            comboBox3.Items.Clear();
            foreach(Hotel hotel in app.hotels)
            {
                if(hotel.ToString().Equals(listBox1.SelectedItem.ToString()))
                {
                    
                        switch(hotel.Star)
                        {
                            case 1:
                                {
                                comboBox3.Items.Add("SingleBedRoom");
                                comboBox3.Items.Add("TwoBedRoom");
                                break;
                                }
                            case 2:
                                {
                                comboBox3.Items.Add("SingleBedRoom");
                                comboBox3.Items.Add("TwoBedRoom");
                                comboBox3.Items.Add("TwinRoom");
                                    break;
                                }
                            case 3:
                                {
                                comboBox3.Items.Add("SingleBedRoom");
                                comboBox3.Items.Add("TwoBedRoom");
                                comboBox3.Items.Add("TwinRoom");
                                comboBox3.Items.Add("ThreeBedRoom");
                                    break;
                                }
                            case 4:
                                {
                                comboBox3.Items.Add("SingleBedRoom");
                                comboBox3.Items.Add("TwoBedRoom");
                                comboBox3.Items.Add("TwinRoom");
                                comboBox3.Items.Add("ThreeBedRoom");
                                comboBox3.Items.Add("FamilyRoom");

                                break;
                                }
                            case 5:
                               {
                                comboBox3.Items.Add("SingleBedRoom");
                                comboBox3.Items.Add("TwoBedRoom");
                                comboBox3.Items.Add("TwinRoom");
                                comboBox3.Items.Add("ThreeBedRoom");
                                comboBox3.Items.Add("KingRoom");
                                break;
                               }
                    }
                    break;
                }
            }
            comboBox3.Text = comboBox3.Items[0].ToString();

        }

        /// <summary>
        /// hows arguments for add room 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label19_Click(object sender, EventArgs e)
        {
            label33.Visible = true;
            comboBox3.Visible = true;
            label34.Visible = true;
            button8.Visible = true;
            comboBox3.Text = comboBox3.Items[0].ToString();
        }

        /// <summary>
        /// add room process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
           if( aModule.addRoom(listBox1.SelectedIndex,comboBox3.Text))
            {
                AutoClosingMessageBox.Show("Transaction successful", "Notification", 1000);
            }
            else AutoClosingMessageBox.Show("Operation failed", "Notification", 1000);


            listBox1.Items.Clear();
            for (int i = 0; i < app.hotels.Count; i++)
            {
                listBox1.Items.Add(app.hotels[i].ToString());
            }
            label31.Text = "To be deleted,\ndouble-click(from the list at the top right) on one and press the Delete button";
            label33.Text = "To add a room,\nfirst select the hotel from the list, then select room type, click the last add button";
            label36.Text = "To delete a room,\nfirst select the hotel from the list, then select room number, click the last delete button";

            label33.Visible = false;
            comboBox3.Visible = false;
            label34.Visible = false;
            button8.Visible = false;
        }

        /// <summary>
        /// show argument for delete room process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label20_Click(object sender, EventArgs e)
        {

            label36.Visible = true;         
            label35.Visible = true;
            button9.Visible = true;
            comboBox4.Visible = true;
           

        }

        /// <summary>
        /// delete room process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text == "") AutoClosingMessageBox.Show("Operation failed", "Notification", 1000);

            else {
                aModule.deleteRoom(listBox1.SelectedIndex,Convert.ToInt32(comboBox4.Text));
                AutoClosingMessageBox.Show("Transaction successful", "Notification", 1000);
            }


            listBox1.Items.Clear();
            for (int i = 0; i < app.hotels.Count; i++)
            {
                listBox1.Items.Add(app.hotels[i].ToString());
            }
            label31.Text = "To be deleted,\ndouble-click(from the list at the top right) on one and press the Delete button";
            label33.Text = "To add a room,\nfirst select the hotel from the list, then select room type, click the last add button";
            label36.Text = "To delete a room,\nfirst select the hotel from the list, then select room number, click the last delete button";

            label36.Visible = false;
            label35.Visible = false;
            button9.Visible = false;
            comboBox4.Items.Clear();
            comboBox4.Visible = false;
        }

        /// <summary>
        /// shows arguments for summary information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label21_Click(object sender, EventArgs e)
        {
            label37.Visible = true;
            label38.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            button10.Visible = true;
          


        }

        /// <summary>
        /// summary ınfo event and open summary ınfo file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
           if( aModule.summaryInfo(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date))
            {
                AutoClosingMessageBox.Show("Transaction successful", "Notification", 1000);

                System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\LogsFile\\SummaryLogs.txt");

            }
            else AutoClosingMessageBox.Show("Operation failed", "Notification", 1000);
        }

        /// <summary>
        /// Event opening execeptionlog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
           
            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\LogsFile\\ExceptionLogs.txt");
        }

        /// <summary>
        /// event saves all recent changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdminGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            app.Save();
           
        }

        
    }
}
