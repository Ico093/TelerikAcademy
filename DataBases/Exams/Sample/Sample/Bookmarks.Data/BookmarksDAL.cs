using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookmarks.Data
{
    public static class BookmarksDAL
    {
        public static void ImportBookmarks(string username, string title, string URL, IList<string> tags, string notes)
        {
            string[] tagsFromTitle = title.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < tagsFromTitle.Length; i++)
            {
                tags.Add(tagsFromTitle[i]);
            }

            using (var db = new BookmarksDBEntities())
            {
                Bookmark bookmark = new Bookmark();
                User user = CreateOrLoadUser(db, username);
                bookmark.User = user;
                bookmark.Title = title;
                bookmark.URL = URL;
                IList<Tag> loadedTags = CreateOrLoadTags(db, tags);
                bookmark.Tags = loadedTags;
                bookmark.Notes = notes;

                db.Bookmarks.Add(bookmark);

                db.SaveChanges();
            }
        }

        private static User CreateOrLoadUser(BookmarksDBEntities db, string username)
        {
            User user = db.Users.Where(x => x.Username.ToLower() == username.ToLower()).Select(x => x).FirstOrDefault();

            if (user == null)
            {
                user = new User() { Username = username };
                db.Users.Add(user);
            }

            db.SaveChanges();

            return user;
        }

        private static IList<Tag> CreateOrLoadTags(BookmarksDBEntities db, IList<string> tags)
        {
            List<Tag> loadedTags = new List<Tag>();

            for (int i = 0; i < tags.Count; i++)
            {
                string tagString = tags[i];

                var tag = (from t in db.Tags where t.Name.ToLower() == tagString.ToLower() select t).FirstOrDefault();

                if (tag == null)
                {
                    tag = new Tag() { Name = tags[i].ToLower() };
                    db.Tags.Add(tag);
                }

                loadedTags.Add(tag);
                db.SaveChanges();
            }

            return loadedTags;
        }

        public static IList<Bookmark> SimpleBookmarkSearch(string username, string tagString)
        {
            using (var db = new BookmarksDBEntities())
            {
                var user = db.Users.Where(x => x.Username.ToLower() == username.ToLower()).Select(x => x).FirstOrDefault();
                var tag = db.Tags.Where(x => x.Name.ToLower() == tagString.ToLower()).Select(x => x).FirstOrDefault();

                var bookmarkQuery = db.Bookmarks.AsQueryable();

                if (user != null)
                {
                    bookmarkQuery = bookmarkQuery.Where(x => x.UserId == user.UserId).Select(x => x);
                }

                if (tag != null)
                {
                    bookmarkQuery = bookmarkQuery.Where(x => x.Tags.Any(y => y.Name == tag.Name)).Select(x => x);
                }
                bookmarkQuery = bookmarkQuery.OrderBy(x => x.URL);

                return bookmarkQuery.ToList();
            }
        }

        public static IList<Bookmark> ComplexBookmarkSearch(string username, List<string> tags, int maxResults)
        {
            using (var db = new BookmarksDBEntities())
            {
                var user = db.Users.Where(x => x.Username.ToLower() == username.ToLower()).Select(x => x).FirstOrDefault();

                var bookmarkQuery = db.Bookmarks.Include("User").Include("Tags").AsQueryable();

                if (user != null)
                {
                    bookmarkQuery = bookmarkQuery.Where(x => x.UserId == user.UserId).Select(x => x);
                }

                foreach (var tag in tags)
                {
                    bookmarkQuery = bookmarkQuery.Where(x => x.Tags.Any(y => y.Name == tag)).Select(x => x);
                }
                bookmarkQuery = bookmarkQuery.OrderBy(x => x.URL);
                bookmarkQuery = bookmarkQuery.Take(maxResults);

                return bookmarkQuery.ToList();
            }
        }
    }
}
