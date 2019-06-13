using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    
    public partial class LoginScreen : Form
    {
        private App app;
        public LoginScreen()
        {

            app = App.getInstance();
            new Logger();
            
            InitializeComponent();
            
        }

        /// <summary>
        /// getting necassary argument for sıng up process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richPassword1.Text = "";
            richTextBox3.Text = "";
            richTextBox4.Text = "";
            richTextBox5.Text = "";
            richTextBox2.Visible = false;
            richPassword1.Visible = true;
            label13.Text = "Show";
            label13.ForeColor = Color.Red;
            label9.Text = "SIGN UP";
            button1.Text = "SIGN UP";
            label13.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            richTextBox1.Visible = true;
            richPassword1.Visible = true;
            richTextBox3.Visible = true;
            richTextBox4.Visible = true;
            richTextBox5.Visible = true;
            button1.Visible = true;

        }

        /// <summary>
        /// getting necassary argument for sıng ın process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label2_Click(object sender, EventArgs e)
        {
            

            richTextBox3.Text = "";
            richTextBox4.Text = "";
            richTextBox5.Text = "";

            richTextBox2.Visible = false;
            richPassword1.Visible = true;
            label13.Text = "Show";
            label13.ForeColor = Color.Red;
            label9.Text = "SIGN IN";
            button1.Text = "SIGN IN";
            label13.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = false;
            label12.Visible = false;
            richTextBox1.Visible = true;
            richPassword1.Visible = true;
            richTextBox3.Visible = false;
            richTextBox4.Visible = false;
            richTextBox5.Visible = false;
            button1.Visible = true;
        }





        /// <summary>
        /// correct register event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != '.'
                && e.KeyChar != '_' && e.KeyChar != '-';
        }
        /// <summary>
        /// correct register event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';

        }

        /// <summary>
        /// correct register event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                  && e.KeyChar != ' ';
        }

        /// <summary>
        /// correct register event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        /// <summary>
        ///  to contain only numbers correct register event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) e.Handled = true;
        }


        /// <summary>
        /// login and open the required panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            string password;
            if (richPassword1.Visible) password = richPassword1.Text;
            else password = richTextBox2.Text;
            if (button1.Text.Equals("SIGN UP"))
            {
                
                User temp;
                try
                {
                    temp = new User();

                    temp.ID = richTextBox1.Text;
                    temp.Password = password;
                    temp.Name = richTextBox3.Text;
                    temp.Surname = richTextBox4.Text;
                    temp.Age = richTextBox5.Text;
                   


                }
                catch (ProjeException E)
                {
                   
                    E.notification = "LoginScreen ->> button1_Click(sıgn up event) Invalid user information";
                    Logger.writeExceptionLog(E.ToString());
                    

                    AutoClosingMessageBox.Show("Invalid Argument!!!\nPlease Try Again", "Notification",2000);
                    richTextBox1.Text = "";
                    richPassword1.Text = "";
                     
                    richTextBox3.Text = "";
                    richTextBox4.Text = "";
                    richTextBox5.Text = "";
                    temp = null;
                }

                if (temp != null)
                {
                    if (!app.addUser(temp))
                    {
                        AutoClosingMessageBox.Show("This username has already been taken", "Notification",2300);
                        richTextBox1.Text = "";
                        richPassword1.Text = "";
                        richTextBox3.Text = "";
                        richTextBox4.Text = "";
                        richTextBox5.Text = "";
                    }
                    else
                    {
                        AutoClosingMessageBox.Show("You have successfully registered", "Notification", 1000);
                        app.activeUserLocation = app.users.Count - 1;
                        this.Hide();
                        new UserGUI().Show();
                    }
                }               
                
            }
            else
            {
               
                //user login
                if (app.login(richTextBox1.Text, password))
                {
                    AutoClosingMessageBox.Show("The login process is successful", "Notification", 1500);
                     
                    this.Hide();
                    new UserGUI().Show();

                }
                else if(app.admin.ID.Equals(richTextBox1.Text) && app.admin.Password.Equals(password)) //admin login
                {
                    
                    AutoClosingMessageBox.Show("The login process is successful", "Notification", 1500);
                    this.Hide();
                    new AdminGUI().Show();
                    
                }
                else AutoClosingMessageBox.Show("The login process fail", "Notification", 2000);
                


            }



        }

       
      /// <summary>
      /// password show or hide process
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        private void label13_Click(object sender, EventArgs e)
        {
            if ( richTextBox2.Visible)
            {
                richTextBox2.Visible = false;
                richPassword1.Visible = true;
                label13.Text = "Show";
                label13.ForeColor = Color.Red;
            }
            else
            {
                richTextBox2.Text = richPassword1.Text;
                richTextBox2.Visible = true;
                richPassword1.Visible = false;
                label13.Text = "Hide";
                label13.ForeColor = Color.Blue;
               
            }
        }

        /// <summary>
        /// event saves all recent changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            app.Save();
        }
    }

    //ref link : https://stackoverflow.com/questions/14522540/close-a-messagebox-after-several-seconds
    public class AutoClosingMessageBox
    {
        System.Threading.Timer _timeoutTimer;
        string _caption;
        AutoClosingMessageBox(string text, string caption, int timeout)
        {
            _caption = caption;
            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, timeout, System.Threading.Timeout.Infinite);
            using (_timeoutTimer)
                MessageBox.Show(text, caption);
        }
        public static void Show(string text, string caption, int timeout)
        {
            new AutoClosingMessageBox(text, caption, timeout);
        }
        void OnTimerElapsed(object state)
        {
            IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
            if (mbWnd != IntPtr.Zero)
                SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            _timeoutTimer.Dispose();
        }
        const int WM_CLOSE = 0x0010;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
    }

    //Ref link : https://stackoverflow.com/questions/4451592/password-char-for-richtextbox
    class RichPassword : RichTextBox
    {
        protected override CreateParams CreateParams
        {
            get
            {
                // Turn on ES_PASSWORD
                var cp = base.CreateParams;
                cp.Style |= 0x20;
                return cp;
            }
        }
    }
}
