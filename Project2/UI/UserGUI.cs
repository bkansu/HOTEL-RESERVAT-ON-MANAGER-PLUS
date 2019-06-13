using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    public partial class UserGUI : Form
    {
        private App app;
       
        private UserModule uModule;
        
        private string city;
        private string star;
        private string name;
        private string type;
        private string cancelRezData;
        List<int> prices;
        public UserGUI()
        {
            app = App.getInstance();

            InitializeComponent();
        }

        /// <summary>
        /// default uı
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserGUI_Load(object sender, EventArgs e)
        {
            //user ınfo
            label12.Text = app.users[app.activeUserLocation].ID;
            label11.Text = app.users[app.activeUserLocation].Password;
            label10.Text = app.users[app.activeUserLocation].Name;
            label9.Text = app.users[app.activeUserLocation].Surname;
            label8.Text = app.users[app.activeUserLocation].Age;


            // available rez for active user
            uModule = new UserModule(ref app);
            foreach (string s in uModule.getActualReservation()) listBox1.Items.Add(s);
        }

        /// <summary>
        /// shows arguments for id update 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label12_Click_1(object sender, EventArgs e)
        {
            button1.Visible = true;
            textBox1.Visible = true;

        }

        /// <summary>
        /// shows arguments for Password update 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label11_Click_1(object sender, EventArgs e)
        {
            button2.Visible = true;
            textBox2.Visible = true;
        }
        /// <summary>
        /// shows arguments for name update 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label10_Click_1(object sender, EventArgs e)
        {

                button3.Visible = true;
                textBox3.Visible = true;   
        }
        /// <summary>
        /// shows arguments for surname update 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label9_Click_1(object sender, EventArgs e)
        {
            button4.Visible = true;
            textBox4.Visible = true;
        }

        /// <summary>
        /// shows arguments for age update 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label8_Click_1(object sender, EventArgs e)
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

           
            if (uModule.updateId(textBox1.Text))
            {
                AutoClosingMessageBox.Show("Transaction successful", "Notification", 1000);
                label12.Text = app.users[app.activeUserLocation].ID;
            }
            else AutoClosingMessageBox.Show("Invalid UserName", "Notification", 1000);
            textBox1.Text = "";
            textBox1.Visible = false;
            button1.Visible = false;
        }

        /// <summary>
        /// admin Password update process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (uModule.updatePassword(textBox2.Text))
            {
                AutoClosingMessageBox.Show("Transaction successful", "Notification", 1000);
                label11.Text = app.users[app.activeUserLocation].Password;
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
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (uModule.updateName(textBox3.Text))
            {
                AutoClosingMessageBox.Show("Transaction successful", "Notification", 1000);
                label10.Text = app.users[app.activeUserLocation].Name;
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
            if (uModule.updateSurname(textBox4.Text))
            {
                AutoClosingMessageBox.Show("Transaction successful", "Notification", 1000);
                label9.Text = app.users[app.activeUserLocation].Surname;
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
            if (uModule.updateAge(textBox5.Text))
            {
                AutoClosingMessageBox.Show("Transaction successful", "Notification", 1000);
                label8.Text = app.users[app.activeUserLocation].Age;
            }
            else AutoClosingMessageBox.Show("Invalid Age", "Notification", 1000);
            textBox5.Text = "";
            textBox5.Visible = false;
            button5.Visible = false;
        }

        /// <summary>
        /// Brings existing hotels and necessary arguments
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label15_Click(object sender, EventArgs e)
        {
            //neccessary argument
            dateTimePicker1.MinDate = app.StartAppTime.Date;
            dateTimePicker2.MinDate = app.StartAppTime.AddDays(1).Date;
            DateTime last = app.StartAppTime.AddYears(1).Date;
            dateTimePicker1.MaxDate = last;
            dateTimePicker2.MaxDate = last;

            comboBox2.Visible = true;
            comboBox1.Visible = true;
            comboBox3.Visible = true;
            comboBox5.Visible = true;

            label17.Visible = true;
            label22.Visible = true;
            label21.Visible = true;
            textBox8.Visible = true;
            textBox6.Visible = true;
            label24.Visible = true;
            button7.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
            label18.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;

           
            //getting existing unique hotel City
            foreach (string s in uModule.getUniqueHotelCity()) comboBox2.Items.Add(s);
           
            if (comboBox2.Items.Count != 0) comboBox2.Text = comboBox2.Items[0].ToString();



        }

        /// <summary>
        /// hotel stars  in selected city
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            city = comboBox2.SelectedItem.ToString();
            
            foreach(string s in uModule.getUniqueHotelStar(city)) comboBox1.Items.Add(s);
           
            if (comboBox1.Items.Count != 0) comboBox1.Text = comboBox1.Items[0].ToString();
            
            //Process for reuse 
            label23.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            comboBox4.Visible = false;
            button6.Visible = false;
            label30.Visible = false;
            label31.Visible = false;

        }

        /// <summary>
        /// hotels in seleceted city and selected star
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            star = comboBox1.Text;
            city = comboBox2.Text;
            foreach (string s in uModule.getUniqueHotelName(city, star)) comboBox3.Items.Add(s);

            if (comboBox3.Items.Count != 0) comboBox3.Text = comboBox3.Items[0].ToString();

            //Process for reuse 
            label23.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            comboBox4.Visible = false;
            button6.Visible = false;
            label30.Visible = false;
            label31.Visible = false;

        }

        /// <summary>
        /// finds all unique room types event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox5.Items.Clear();
            star = comboBox1.SelectedItem.ToString();
            city = comboBox2.SelectedItem.ToString();
            name = comboBox3.SelectedItem.ToString();

            foreach(string s in   uModule.getUniqueRoomTypes(city,star,name)) comboBox5.Items.Add(s);
                     
            if (comboBox5.Items.Count != 0) comboBox5.Text = comboBox5.Items[0].ToString();

            //Process for reuse 
            label23.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            comboBox4.Visible = false;
            button6.Visible = false;
            label30.Visible = false;
            label31.Visible = false;

        }

        /// <summary>
        /// event that started the booking process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {

            if (uModule.makeReservation(comboBox3.Text, Convert.ToInt32(comboBox1.Text), prices[comboBox4.SelectedIndex], dateTimePicker1.Value, dateTimePicker2.Value, Convert.ToInt32(comboBox4.Text)))
                AutoClosingMessageBox.Show("Transaction successfuly", "NotifiCaiton", 900);

            else  AutoClosingMessageBox.Show("Change room or date range", "NotifiCaiton", 900);


            //I updated the user's reservations after the transaction
            listBox1.Items.Clear();
            foreach(string s in uModule.getActualReservation()) listBox1.Items.Add(s);
           

            //Process for reuse 
            label23.Visible = false;
            comboBox4.Visible = false;
            label27.Visible = false;
            label26.Visible = false;
            button6.Visible = false;
            label28.Visible = false;
            button8.Visible = false;
            label30.Visible = false;
            label31.Visible = false;
            label31.Text = "";
        }

        /// <summary>
        /// pulls the current prices of the room (maybe fix it)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            prices = new List<int>();
            comboBox4.Items.Clear();
          
           
            star = comboBox1.Text;
            city = comboBox2.Text;
            name = comboBox3.Text;
            type = comboBox5.Text;

            int min = Convert.ToInt32(textBox8.Text);
            int max = Convert.ToInt32(textBox6.Text);
            int price = 0;
            foreach (Hotel hotel in app.hotels)
            {
                if (hotel.City.Equals(city) && hotel.Star.ToString().Equals(star) && hotel.Name.ToString().Equals(name))
                {
                    foreach (Room room in hotel.Rooms)
                    {
                        if (!comboBox4.Items.Contains(room.no) && room.GetType().Name.Equals(type))     
                        {
                          
                            if (room.getPay(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, ref price, app.StartAppTime))
                            {
                                if (price >= min && price <= max)
                                {
                                    comboBox4.Items.Add(room.no);
                                    prices.Add(price);
                                }
                            }
                            price = 0;
                            
                            
                        }
                    }
                    break;
                }
            }
            if (comboBox4.Items.Count != 0)
            {
                comboBox4.Text = comboBox4.Items[0].ToString();
                //Process for use 
                button6.Visible = true;
                comboBox4.Visible = true;
                label23.Visible = true;
                label26.Visible = true;
                label27.Visible = true;
                label30.Visible = true;
                label31.Visible = true;
            }
            else
            {
                AutoClosingMessageBox.Show("No room available", "Notification", 1000);
                //Process for reuse 
                comboBox4.Visible = false;
                label23.Visible = false;
                button6.Visible = false;
                label26.Visible = false;
                label27.Visible = false;
                label30.Visible = false;
                label31.Visible = false;
                label31.Text = "";
            }


            
                
        }

        /// <summary>
        /// correct login event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        /// <summary>
        /// correct login event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        /// <summary>
        /// fetch selected room property event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            label31.Text = "";
            label27.Text = prices[comboBox4.SelectedIndex].ToString();

            foreach (string i in uModule.getRoomContents(name, comboBox4.Text))
            {
                label31.Text += i + "\n";
            }          
        }

        /// <summary>
        /// reuse of arguments for booking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            label30.Visible = false;
            label31.Visible = false;

            label23.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            comboBox4.Visible = false;
            button6.Visible = false;
        }

        /// <summary>
        /// reuse of arguments for booking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            label23.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            comboBox4.Visible = false;
            button6.Visible = false;
            label30.Visible = false;
            label31.Visible = false;

        }

        /// <summary>
        /// reuse of arguments for booking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

            label23.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            comboBox4.Visible = false;
            button6.Visible = false;
            label30.Visible = false;
            label31.Visible = false;

        }

        /// <summary>
        /// reuse of arguments for booking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            label23.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            comboBox4.Visible = false;
            button6.Visible = false;
            label30.Visible = false;
            label31.Visible = false;

        }

        /// <summary>
        /// reuse of arguments for booking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

            label23.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            comboBox4.Visible = false;
            button6.Visible = false;
            label30.Visible = false;
            label31.Visible = false;

        }

        /// <summary>
        /// event with arguments for booking cancellation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label16_Click(object sender, EventArgs e)
        {
            label28.Visible = true;
            button8.Visible = true;
            if (listBox1.Items.Count != 0)
            {
                cancelRezData = listBox1.Items[listBox1.Items.Count - 1].ToString();

                label28.Text = cancelRezData;

            }
           else  label28.Text = "no bookings to cancel";
        }

        /// <summary>
        /// Cancel reservation button event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0) AutoClosingMessageBox.Show("No bookings to cancel", "NotifiCaiton", 900);
          
            if(uModule.cancelReservation(cancelRezData))
            {
                listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
                AutoClosingMessageBox.Show("Transaction successfuly", "NotifiCaiton", 900);
            }
            else AutoClosingMessageBox.Show("No bookings to cancel", "NotifiCaiton", 900);
            button8.Visible = false;
            label28.Visible = false;

        }

        /// <summary>
        /// event saves all recent changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            app.Save();


        }
    }

   
}
