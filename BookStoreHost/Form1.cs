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

namespace BookStoreHost
{
    public partial class Form1 : Form
    {
        DataManager db = new DataManager(); // объект контекста базы данных
        ServiceHost host;

        public Form1()
        {
            InitializeComponent();
            // !!! Only once:
            //InstallGenres();
            //InstallAuthors();
            //InstallPublishers();
            //InstallBooks();
        }

        private void InstallGenres() // only once
        {
            Genre[] arr = new Genre[3]
            {
                new Genre() {Name="Программирование" },
                new Genre() {Name="Администрирование" },
                new Genre() {Name="Компьютерная графика" }
            };
            db.Genres.AddRange(arr);
            db.SaveChanges();
            MessageBox.Show("Genres Install - Ok!");
        }
        private void InstallAuthors() // only once
        {
            Author[] arr = new Author[6]
            {
                new Author() {Name="Иванов" },
                new Author() {Name="Петров" },
                new Author() {Name="Петров" },
                new Author() {Name="Сидоров" },
                new Author() {Name="Николаев" },
                new Author() {Name="Федоров" }
            };
            db.Authors.AddRange(arr);
            db.SaveChanges();
            MessageBox.Show("Authors Install - Ok!");
        }
        private void InstallPublishers() // only once
        {
            Publisher[] arr = new Publisher[3]
            {
                new Publisher(){Name="Профессиональная литература"},
                new Publisher(){Name="Питер"},
                new Publisher(){Name="ДМК-Пресс"}
            };
            db.Publishers.AddRange(arr);
            db.SaveChanges();
            MessageBox.Show("Publishers Install - Ok!");
        }
        private void InstallBooks() // only once
        {
            Book[] arr = new Book[6]
            {
                new Book(){Title = "С# для чайников", Author_Id = 1, Genre_Id = 1, Publisher_Id = 1  },
                new Book() { Title = "Философия С/С++", Author_Id = 2, Genre_Id = 1, Publisher_Id = 2 },
                new Book() { Title = "Photoshop и непонятные кнопочки", Author_Id = 3, Genre_Id = 2, Publisher_Id = 1},
                new Book() { Title = "Роль Paint в мировой культуре", Author_Id = 4, Genre_Id = 2, Publisher_Id = 3},
                new Book() { Title = "Собери себе компьютер, человек", Author_Id = 5, Genre_Id = 3, Publisher_Id = 2},
                new Book() { Title = "Администрирование с точки зрения здравого смысла", Author_Id = 6, Genre_Id = 3, Publisher_Id = 3}
            };
            db.Books.AddRange(arr);
            db.SaveChanges();
            MessageBox.Show("Books Imstall - Ok!");
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            host = new ServiceHost(typeof(Service1));
            host.Open();
            textBox1.Text = $"{DateTime.Now.ToString()}: Служба успешно запущена";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (host != null)
                host.Close();
        }
    }
}
