using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kino.Interfaces;

namespace Kino.Classes
{
    public class MoviesStorage:IStorable
    {
        //Static constructor for initializing List
        static MoviesStorage() 
        {
            movies = new List<Movie>();
        }

        private static MoviesStorage instance;
        public static MoviesStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MoviesStorage();
                }
                return instance;
            }
            private set { instance = value; }
        }

        private static List<Movie> movies;

        public static List<Movie> Movies
        {
            get { return movies; }
            set { movies = value; }
        }

        //File text devidors, helping spliting the text after reading
        private static readonly char[] charDevidors = {'#','-','+','\n','\r',' '};
        
        public void AddMovie(Movie movie) 
        {
            if (movies != null)
            {
                movies.Add(movie);
            }
        }

        public Movie GetMovie(string movieName) 
        {
            return Movies.Where(x => x.MovieName.Equals(movieName)).Select(x=>x).FirstOrDefault();
        }

        public void GetInformation()
        {
            try
            {
                StreamReader fileReader = new StreamReader("DataFiles/ReservedPlacesDataBase.txt");
                if (fileReader != null)
                {
                    using (fileReader)
                    {
                        List<Movie> readedMovies = new List<Movie>();
                        //Spliting by NewLine file to part witch are movies
                        string[] movies = fileReader.ReadToEnd().Split(new char[] { charDevidors[3], charDevidors[4] }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var currentMovie in movies)
                        {
                            //Spliting by '#' current movie to part witch are it's elements
                            string[] movieElements = currentMovie.Split(new char[] { charDevidors[0] }, StringSplitOptions.RemoveEmptyEntries);

                            string movieName = movieElements[0];

                            double moviePrice = double.Parse(movieElements[1]);

                            //Spliting pojection by '+'  so we get hall and date
                            List<Projection> movieProjections = new List<Projection>();
                            if (movieElements.Length == 3)
                            {
                                foreach (var currentProjection in movieElements[2].Split(new char[] { charDevidors[2] }, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    string[] projectionElements = currentProjection.Split(new char[] { charDevidors[1] }, StringSplitOptions.RemoveEmptyEntries);

                                    //Parsing to enum
                                    Halls projHall = (Halls)Enum.Parse(typeof(Halls), projectionElements[0]);

                                    //Parsing to datetime
                                    Projection creatingProjection = new Projection(projHall, projectionElements[1]);

                                    if (projectionElements.Length > 2)
                                    {
                                        //Spliting places
                                        string[] reservedPlaces = projectionElements[2].Split(new char[] { charDevidors[5] }, StringSplitOptions.RemoveEmptyEntries);

                                        for (int i = 0; i < reservedPlaces.Length; i++)
                                        {
                                            creatingProjection.ReservePlace(int.Parse(reservedPlaces[i]));
                                        }
                                    }

                                    movieProjections.Add(creatingProjection);
                                }
                            }
                            readedMovies.Add(new Movie(movieName, moviePrice, movieProjections));
                        }
                        Movies = readedMovies;
                    }
                }
            }
            catch (Exception)
            {
                
            }
            
        }

        public void SetInformation()
        {
            StringBuilder fileContent = new StringBuilder();

            if (Movies != null)
            {
                foreach (var currentMovie in Movies)
                {
                    //MovieName
                    fileContent.Append(currentMovie.MovieName + charDevidors[0]);

                    fileContent.Append(currentMovie.Price.ToString() + charDevidors[0]);

                    foreach (var currentProjection in currentMovie.Projections)
                    {
                        fileContent.Append(currentProjection.Hall.ToString() + charDevidors[1] + currentProjection.ProjectionHour);

                        if (currentProjection.ReservedPlaces.Count!=0)
                        {
                            fileContent.Append(charDevidors[1]);
                            //reservedPlaces for currentProjection
                            for (int place = 0; place < currentProjection.ReservedPlaces.Count; place++)
                            {
                                fileContent.Append(currentProjection.GetPlace(place).ToString() + charDevidors[5]);
                            }                                                        
                        }
                        fileContent.Append(charDevidors[2]);
                    }
                    fileContent.Append(Environment.NewLine);
                }

                //Writing to file
                StreamWriter fileWriter = new StreamWriter("DataFiles/ReservedPlacesDataBase.txt", false);

                if (fileWriter != null)
                {
                    using (fileWriter)
                    {
                        fileWriter.Write(fileContent);
                    }
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
