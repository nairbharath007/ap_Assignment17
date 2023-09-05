using MovieStoreAppWithLists.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreAppWithLists.Model
{
     class MovieManager
    {
        private List<Movie> movies;

        public MovieManager()
        {
            movies = new List<Movie>();
        }

        public bool AddMovie(Movie movie)
        {
            if (movies.Count >= 5)
            {
                throw new MovieStoreException("The movie list is full (maximum 5 movies).");

            }
            if (movies.Any(m => m.MovieId == movie.MovieId || m.MovieName == movie.MovieName))
            {
                throw new DuplicateMovieException("A movie with the same ID or Name already exists.");
            }

            movies.Add(movie);
            return true;
        }

        public List<Movie> GetAllMovies()
        {
            return movies;
        }
        /*public void DisplayAllMovies()
        {
            if (movies.Count == 0)
            {
                Console.WriteLine("No movies in the store.");
                return;
            }

            Console.WriteLine("List of all movies:");
            foreach (Movie movie in movies)
            {
                Console.WriteLine(movie.ToString());
            }
        }*/



        public List<Movie> FindMoviesByYear(int year)
        {
            if (year < 1900 || year > DateTime.Now.Year)
            {
                throw new InvalidYearException("Invalid year. Please enter a valid year between 1900 and the current year.");
            }
            return movies.FindAll(movie => movie.Year == year);
        }

        public void RemoveMovieByName(string name)
        {
            Movie movieToRemove = movies.Find(movie => movie.MovieName.Equals(name));
            if (movieToRemove != null)
            {
                movies.Remove(movieToRemove);
            }
            else
            {
                throw new MovieNotFoundException($"Movie '{name}' not found.");
            }
        }

        public void ClearList()
        {
            movies.Clear();
        }

        /*public string GetAllMoviesFormatted()
        {
            if (movies.Count == 0)
            {
                return "No movies found.";
            }

            string formattedMovies = "List of movies:\n";
            foreach (Movie movie in movies)
            {
                formattedMovies += movie.ToString() + "\n";
            }

            return formattedMovies;
        }*/

        public string GetMoviesFormatted(List<Movie> moviesToDisplay = null)
        {
            List<Movie> moviesList = moviesToDisplay ?? movies;
            if (moviesList.Count == 0)
            {
                return "No movies found.";
            }

            string formattedMovies = "List of movies:\n";
            foreach (Movie movie in moviesToDisplay)
            {
                formattedMovies += movie.ToString() + "\n";
            }

            return formattedMovies;
        }
    }
}
