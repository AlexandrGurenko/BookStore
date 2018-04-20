using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using ClassLibrary1;
using BookStoreClient.ServiceReference1;

namespace BookStoreClient
{
    public partial class Form1 : Form
    {
        Service1Client proxy = new Service1Client();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayGenres();
        }

        private void DisplayGenres()
        {
            var genres = proxy.GetGenres().ToList();
            foreach (var g in genres)
            {
                comboBox1.Items.Add(g.Name);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void DisplayAuthors()
        {
            var authors = proxy.GetAuthors();
            foreach (var a in authors)
            {
                comboBox2.Items.Add(a.Name);
            }
            comboBox2.SelectedIndex = 0;
        }

        private void DisplayPublishers()
        {
            var publishers = proxy.GetPublishers();
            foreach (var p in publishers)
                comboBox3.Items.Add(p.Name);
            comboBox3.SelectedIndex = 0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                ClearAll();
                DisplayGenres();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                ClearAll();
                DisplayAuthors();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                ClearAll();
                DisplayPublishers();
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
                ClearAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.Clear();
                var books = proxy.GetBooks();
                if (radioButton1.Checked)
                {
                    var genres = proxy.GetGenres();
                    foreach (var b in books)
                    {
                        foreach (var g in genres)
                        {
                            if (g.Id == b.Genre_Id && g.Name == comboBox1.SelectedItem.ToString())
                                listView1.Items.Add(b.Title);
                        }
                    }
                }
                if (radioButton2.Checked)
                {
                    var authors = proxy.GetAuthors();
                    foreach (var b in books)
                    {
                        foreach (var a in authors)
                        {
                            if (a.Id == b.Author_Id && a.Name == comboBox2.SelectedItem.ToString())
                                listView1.Items.Add(b.Title);
                        }
                    }
                }
                if (radioButton3.Checked)
                {
                    var publishers = proxy.GetPublishers();
                    foreach (var b in books)
                    {
                        foreach (var p in publishers)
                        {
                            if (p.Id == b.Publisher_Id && p.Name == comboBox3.SelectedItem.ToString())
                                listView1.Items.Add(b.Title);
                        }
                    }
                }
                if (radioButton4.Checked)
                {
                    foreach (var b in books)
                    {
                        if (b.Title.Contains(textBox1.Text) && textBox1.Text != "")
                        {
                            listView1.Items.Add(b.Title);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите критерии поиска");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            listView1.Items.Clear();
            ClearAll();
        }

        private void ClearAll()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            textBox1.Text = "";
        }
    }
}
