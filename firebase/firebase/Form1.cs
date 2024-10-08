//firebase
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firebase
{
    public partial class Form1 : Form
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "yXvtAaNTHnY00ptSmJ0aoxaR21GpgeHeS41kbZez",
            BasePath = "https://chanden-ff914-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public Form1()
        {
            InitializeComponent();
        }

        private void textFname_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FirebaseClient(config);
            if (client != null)
            {
                MessageBox.Show("Database is connected!!");
            }
        }

        async private void button1_Click(object sender, EventArgs e)
        {
            var todo = new connect
            {
                title = textFname.Text,
                Name = textLname.Text,
                priority = 2
            };

            SetResponse response = await client.SetTaskAsync("Todo/" + textFname.Text, todo);
        }

         private async void button2_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.GetTaskAsync("Todo/" + textFname.Text);
            connect todo = response.ResultAs<connect>();
            textLname.Text = todo.Name;
        }
    }
    
}
