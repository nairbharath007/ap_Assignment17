using MovieStoreAppWithLists.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreAppWithLists.Model
{
    class MovieController
    {
        private MovieManager manager;

        public MovieController()
        {
            manager = new MovieManager();
        }

        public Movie SetMovieDetails()
        {
            int movieId;
            string movieName;
            int year;
            string director;

            while (true) // Keep prompting until valid input is provided for Movie ID
            {
                Console.Write("Enter Movie ID: ");
                string idInput = Console.ReadLine();

                if (int.TryParse(idInput, out movieId))
                {
                    break; // Valid integer input, exit the loop
                }
                else
                {
                    Console.WriteLine("Invalid input for Movie ID. Please enter a valid integer.");
                }
            }

            Console.Write("Enter Movie Name: ");
            movieName = Console.ReadLine();

            while (true) // Keep prompting until valid input is provided for Year
            {
                Console.Write("Enter Year: ");
                string yearInput = Console.ReadLine();

                if (int.TryParse(yearInput, out year) && year >= 1900 && year <= DateTime.Now.Year)
                {
                    break; // Valid year input, exit the loop
                }
                else
                {
                    Console.WriteLine("Invalid year. Please enter a valid year between 1900 and the current year.");
                }
            }

            Console.Write("Enter Director: ");
            director = Console.ReadLine();

            Movie newMovie = new Movie(movieId, movieName, year, director);

            bool addedSuccessfully = manager.AddMovie(newMovie);

            if (addedSuccessfully)
            {
                Console.WriteLine("Movie added successfully!");
            }
            else
            {
                Console.WriteLine("Failed to add the movie. The movie list is full (maximum 5 movies) or a movie with the same ID or Name already exists.");
            }

            return newMovie;



        }

        public void Start()
        {
            while (true)
            {
                DisplayMenu();
                int choice;

                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        //DisplayMovies(null);
                        Console.WriteLine(manager.GetMoviesFormatted(manager.GetAllMovies()));
                        break;
                    case 2:
                        AddMovie();
                        break;
                    case 3:
                        FindMoviesByYear();
                        break;
                    case 4:
                        RemoveMovieByName();
                        break;
                    case 5:
                        manager.ClearList();
                        Console.WriteLine("All movies removed from the store.");
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void RemoveMovieByName()
        {
            Console.Write("Enter the name of the movie to remove: ");
            string movieName = Console.ReadLine();
            manager.RemoveMovieByName(movieName);
            Console.WriteLine($"Movie '{movieName}' removed successfully!");
        }

        private void FindMoviesByYear()
        {
            Console.Write("Enter the year to find movies: ");
            int searchYear;

            try
            {
                searchYear = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            Console.WriteLine(manager.GetMoviesFormatted(manager.FindMoviesByYear(searchYear)));
            //DisplayMovies(manager.FindMoviesByYear(searchYear)); // Display filtered movies
        }

        private void AddMovie()
        {
            if (manager.GetAllMovies().Count >= 5)
            {
                Console.WriteLine("The movie list is full (maximum 5 movies).");
                return;
            }
            Movie newMovie = SetMovieDetails();
            /*if (newMovie != null)
            {
                bool addedSuccessfully = manager.AddMovie(newMovie);
                if (addedSuccessfully)
                {
                    Console.WriteLine("Movie added successfully!");
                }
                else
                {
                    Console.WriteLine("The movie list is full (maximum 5 movies).");
                }
            }*/
        }

        public void DisplayMenu()
        {
            Console.WriteLine("\nMovie Store Menu");
            Console.WriteLine("1. Display all movies");
            Console.WriteLine("2. Add a movie");
            Console.WriteLine("3. Find a movie by year");
            Console.WriteLine("4. Remove a movie by name");
            Console.WriteLine("5. Clear the list");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
        }

        /*private void DisplayMovies(List<Movie> moviesToDisplay)
        {
            string formattedMovies = manager.GetMoviesFormatted(moviesToDisplay);
            Console.WriteLine(formattedMovies);
        }*/
    }
}
