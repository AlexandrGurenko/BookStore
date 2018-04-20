using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ClassLibrary1;

namespace BookStoreHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {

        DataManager db = new DataManager();
        public List<Genre> GetGenres()
        {
            var genres = db.Genres.ToList();
            return genres;
        }
        public List<Author> GetAuthors()
        {
            var authors = db.Authors.ToList();
            return authors;
        }

        public List<Publisher> GetPublishers()
        {
            var publishers = db.Publishers.ToList();
            return publishers;
        }

        public List<Book> GetBooks()
        {
            var books = db.Books.ToList();
            return books;
        }
    }
}