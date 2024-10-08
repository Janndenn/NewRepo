using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace mongodblasttime
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public async void showListBox()
        {
            string connectionString = "mongodb://127.0.0.1:27017",
            dbName = "mongodbtest",
            collName = "product_Type";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(dbName);
            var coll = database.GetCollection<connect>(collName);
            var results = await coll.FindAsync(_ => true);
            //MessageBox.Show("Inserting data is successful!!");
            BindingList<connect> doclist = new
            BindingList<connect>();
            foreach (var result in results.ToList())
            {
                //listBox.Items.Add($"{result.Id}: {result.product_Name}");
                doclist.Add(result);
                Application.DoEvents();
                //dataGridView1.Rows.Add($"{result.Id.ToString()}, {result.product_Name.ToString()}");
            }
            dataGridView1.DataSource = doclist;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            showListBox();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            const string connectionString = "mongodb://localhost:27017";
            // Create a MongoClient object by using the connection string
            var client = new MongoClient(connectionString);
            //Use the MongoClient to access the server
            var database = client.GetDatabase("mongodbtest");
            var coll = database.GetCollection<BsonDocument>("product_Type");
            var doc = new BsonDocument {
            {"p_name", txtName.Text}
            };
            txtID.Text = "";
            await coll.InsertOneAsync(doc);
            showListBox();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            const string connectionString = "mongodb://localhost:27017";
            // Create a MongoClient object by using the connection string
            var client = new MongoClient(connectionString);
            //Use the MongoClient to access the server
            var database = client.GetDatabase("mongodbtest");
            var coll = database.GetCollection<connect>("product_Type");
            var firstUserFilter = Builders<connect>.Filter.Eq("Id", txtID.Text);
            var multiUpdateDefinition = Builders<connect>.Update
            .Set(u => u.name, txtName.Text)
            .Set(u => u.id, txtID.Text);
            var multiUpdateResult = await coll
            .UpdateOneAsync(firstUserFilter, multiUpdateDefinition);
            showListBox();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            const string connectionString = "mongodb://localhost:27017";

            // Create a MongoClient object by using the connection string
            var client = new MongoClient(connectionString);

            //Use the MongoClient to access the server
            var database = client.GetDatabase("mongodbtest");
            var coll = database.GetCollection<BsonDocument>("product_Type");
            var deleteFilter = Builders<BsonDocument>.Filter.Eq("p_name", txtName.Text);
            coll.DeleteOne(deleteFilter);
            showListBox();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
