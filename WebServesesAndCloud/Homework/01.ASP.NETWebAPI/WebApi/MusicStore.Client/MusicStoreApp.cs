using MusicStore.Data;
using MusicStore.Data.Migrations;
using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Client
{
    class MusicStoreApp
    {
        private static string URL = "http://localhost:54533/";

        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicStoreContext, Configuration>());

            //CreateArtist("Aerosmith","USA",new DateTime(1990,1,1));
            //CreateAlbum("Padashti kamanqci", 1990, "Warner");
            //CreateSong("I Don't Wanna Miss a Thing", 1998, Genre.Rock, 6);
            //ShowAllArtists();
            //ShowAllAlbums();
            //ShowAllSongs();
            //Update("Artists", 3, new Artist() { Name = "Kalin Genadiev", Country = "USA", DateOfBirth = DateTime.Now });
            //Delete("Artists", 1);

        }

        private static void CreateArtist(string name, string country, DateTime dateOfBirth)
        {
            Artist artist = new Artist();
            artist.Name = name;
            artist.Country = country;
            artist.DateOfBirth = dateOfBirth;

            var client = new HttpClient
            {
                BaseAddress = new Uri(URL)
            };
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response =
              client.PostAsJsonAsync<Artist>("api/Artists", artist).Result;

            Console.WriteLine("{0} ({1})",
                (int)response.StatusCode, response.ReasonPhrase);
        }

        private static void CreateSong(string title,int year,Genre genre,int artistId)
        {
            Song song = new Song();
            song.Title = title;
            song.Year = year;
            song.Type = genre;
            song.ArtistId = artistId;

            var client = new HttpClient
            {
                BaseAddress = new Uri(URL)
            };
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response =
              client.PostAsJsonAsync<Song>("api/Songs", song).Result;

            Console.WriteLine("{0} ({1})",
                (int)response.StatusCode, response.ReasonPhrase);
        }

        private static void CreateAlbum(string title, int year, string producer, HashSet<Artist> artists = null, HashSet<Song> songs = null)
        {
            Album album = new Album();
            album.Title = title;
            album.Year = year;
            album.Producer = producer;
            album.Artists = artists;
            album.Songs=songs;

            var client = new HttpClient
            {
                BaseAddress = new Uri(URL)
            };
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response =
              client.PostAsJsonAsync<Album>("api/Albums", album).Result;

            Console.WriteLine("{0} ({1})",
                (int)response.StatusCode, response.ReasonPhrase);
        }

        private static void Update<T>(string controller, int id, T obj)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(URL)
            };
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response =
              client.PutAsJsonAsync<T>("api/" + controller + "/" + id,obj).Result;

            Console.WriteLine("{0} ({1})",
                (int)response.StatusCode, response.ReasonPhrase);
        }

        private static void Delete(string controller, int id)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(URL)
            };
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response =
                client.DeleteAsync("api/" + controller + "/" + id).Result;

            Console.WriteLine("{0} ({1})",
                (int)response.StatusCode, response.ReasonPhrase);

        }

        private static void ShowAllArtists()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(URL)
            };
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response =
                client.GetAsync("api/Artists").Result;
            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content
                    .ReadAsAsync<IEnumerable<Artist>>().Result;

                foreach (var artist in artists)
                {
                    Console.WriteLine("Name:{0}\nBirth date:{1}\nCountry:{2}\n",
                        artist.Name, artist.DateOfBirth, artist.Country);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})",
                    (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void ShowAllAlbums()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(URL)
            };
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response =
                client.GetAsync("api/Albums").Result;
            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content
                    .ReadAsAsync<IEnumerable<Album>>().Result;

                foreach (var album in albums)
                {
                    Console.WriteLine("Title:{0}\nYear:{1}\nProducer:{2}\n",
                        album.Title, album.Year, album.Producer);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})",
                    (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private static void ShowAllSongs()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(URL)
            };
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response =
                client.GetAsync("api/Songs").Result;
            if (response.IsSuccessStatusCode)
            {
                var songs = response.Content
                    .ReadAsAsync<IEnumerable<Song>>().Result;

                foreach (var song in songs)
                {
                    Console.WriteLine("Title:{0}\nYear:{1}\nType:{2}\n",
                        song.Title, song.Year, song.Type);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})",
                    (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
