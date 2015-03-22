using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Data
{
    public class BookStoreDAL
    {
        public static void SimpleBooksImport(string authorName, string title, string isbn, string price, string website)
        {
            using (var db = new BookstoreDBEntities())
            {
                Book book = new Book();
                book.Authors = CreateOrLoadAuthors(db, authorName);

                if (title == null || title == string.Empty)
                {
                    throw new ArgumentNullException("Author name can't be null!");
                }

                book.Title = title;

                if (db.Books.Any(x => x.ISBNnumber == isbn) == false)
                {
                    book.ISBNnumber = isbn;
                }
                else
                {
                    if (isbn != null)
                    {
                        throw new ArgumentException("ISBN:{0} already exists!", isbn);
                    }
                }

                if (price != null)
                {
                    book.Price = decimal.Parse(price);
                }

                book.Website = website;

                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        private static ICollection<Author> CreateOrLoadAuthors(BookstoreDBEntities db, string authorName)
        {
            if (authorName == null || authorName == string.Empty)
            {
                throw new ArgumentNullException("Author name can't be null!");
            }

            Author authorEntry = db.Authors.Where(x => x.Name == authorName).FirstOrDefault();

            if (authorEntry == null)
            {
                authorEntry = new Author();
                authorEntry.Name = authorName;
                db.Authors.Add(authorEntry);
            }

            HashSet<Author> authors = new HashSet<Author>();
            authors.Add(authorEntry);

            db.SaveChanges();
            return authors;
        }

        public static void ComplexBooksImport(List<string> authors, string title, string isbn, string price, string website, List<ReviewImport> reviews)
        {
            using (var db = new BookstoreDBEntities())
            {
                Book book = new Book();
                book.Authors = CreateOrLoadAuthors(db, authors);

                if (title == null || title == string.Empty)
                {
                    throw new ArgumentNullException("Author name can't be null!");
                }

                book.Title = title;

                if (db.Books.Any(x => x.ISBNnumber == isbn) == false)
                {
                    book.ISBNnumber = isbn;
                }
                else
                {
                    if (isbn != null)
                    {
                        throw new ArgumentException("ISBN:{0} already exists!", isbn);
                    }
                }

                if (price != null)
                {
                    book.Price = decimal.Parse(price);
                }

                book.Website = website;
                book.Reviews = CreateReviews(db, reviews, book);

                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        private static ICollection<Review> CreateReviews(BookstoreDBEntities db, List<ReviewImport> reviews, Book book)
        {
            HashSet<Review> reviewsHash = new HashSet<Review>();

            foreach (var review in reviews)
            {
                Review reviewObj = new Review();
                reviewObj.Text = review.Review;

                if (review.Date != null)
                {
                    reviewObj.DateCreated = DateTime.Parse(review.Date);
                }
                else
                {
                    reviewObj.DateCreated = DateTime.Now;
                }

                if (review.Author != null)
                {
                    if (review.Author == null || review.Author == string.Empty)
                    {
                        throw new ArgumentNullException("Author name can't be null!");
                    }

                    Author authorEntry = db.Authors.Where(x => x.Name == review.Author).FirstOrDefault();

                    if (authorEntry == null)
                    {
                        authorEntry = new Author();
                        authorEntry.Name = review.Author;
                        db.Authors.Add(authorEntry);
                    }

                    reviewObj.Author = authorEntry;

                    db.SaveChanges();
                }

                reviewObj.Book = book;
                reviewsHash.Add(reviewObj);
            }

            return reviewsHash;
        }

        private static ICollection<Author> CreateOrLoadAuthors(BookstoreDBEntities db, List<string> authorsName)
        {
            HashSet<Author> authors = new HashSet<Author>();

            for (int i = 0; i < authorsName.Count; i++)
            {
                if (authorsName[i] == null || authorsName[i] == string.Empty)
                {
                    throw new ArgumentNullException("Author name can't be null!");
                }

                string authorNameStr = authorsName[i];

                Author authorEntry = db.Authors.Where(x => x.Name == authorNameStr).FirstOrDefault();

                if (authorEntry == null)
                {
                    authorEntry = new Author();
                    authorEntry.Name = authorsName[i];
                    db.Authors.Add(authorEntry);
                }


                authors.Add(authorEntry);

                db.SaveChanges();
            }

            return authors;
        }

        public static List<Book> SimpleSearchForBooks(string title, string author, string isbn)
        {
            using (var db = new BookstoreDBEntities())
            {
                var query = db.Books.Include("Reviews").AsQueryable();

                if (title != null && title != string.Empty)
                {
                    query = query.Where(x => x.Title == title).Select(x => x);
                }
                if (author != null && author != string.Empty)
                {
                    query = query.Where(x => x.Authors.Any(y => y.Name.ToLower() == author.ToLower()));
                }
                if (isbn != null && isbn != string.Empty)
                {
                    query = query.Where(x => x.ISBNnumber.ToLower() == isbn.ToLower());
                }
                query = query.OrderBy(x => x.Title);

                return query.ToList();
            }
        }

        public static List<Review> SearchForReviewsByAuthor(string authorName)
        {
            var db = new BookstoreDBEntities();

            return db.Reviews.Include("Book").Include("Author").Where(x => x.Author.Name.ToLower() == authorName.ToLower()).
                OrderBy(x => x.DateCreated).ThenBy(x => x.Text).ToList();

        }

        public static List<Review> SearchForReviewsByPeriod(string startDate, string endDate)
        {

            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);

            var db = new BookstoreDBEntities();

            return db.Reviews.Include("Book").Include("Author").Where(x => x.DateCreated > start && x.DateCreated < end).
                    OrderBy(x => x.DateCreated).ThenBy(x => x.Text).ToList();

        }
    }
}
