using exploring_LINQ;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class Program
{
    private static List<Movie> movies = new List<Movie>();


    public static void Main( string[] args )
    {
        Console.WriteLine( "Movie Database Console Application" );
        Console.WriteLine( "----------------------------------" );

        LoadMovies();

        if ( movies.Count == 0 )
        {
            Console.WriteLine( "No movies loaded. Exiting application." );
            return;
        }

        DisplayMainMenu();
    }

    private static void LoadMovies()
    {
        try
        {
            string json = File.ReadAllText( "DATA.json" );
            movies = JsonSerializer.Deserialize<List<Movie>>( json ) ?? new List<Movie>();
            Console.WriteLine( $"Successfully loaded {movies.Count} movies." );
        }
        catch ( FileNotFoundException )
        {
            Console.WriteLine( "Error: movies.json file not found." );
        }
        catch ( JsonException )
        {
            Console.WriteLine( "Error: Invalid JSON format in movies.json." );
        }
        catch ( Exception ex )
        {
            Console.WriteLine( $"Error loading movies: {ex.Message}" );
        }
    }

    private static void DisplayMainMenu()
    {
        while ( true )
        {
            Console.WriteLine( "\nMain Menu" );
            Console.WriteLine( "1. View all movies" );
            Console.WriteLine( "2. Search movies" );
            Console.WriteLine( "3. Advanced queries" );
            Console.WriteLine( "4. Statistics" );
            Console.WriteLine( "0. Exit" );
            Console.Write( "Select an option: " );

            if ( !int.TryParse( Console.ReadLine() , out int choice ) )
            {
                Console.WriteLine( "Invalid input. Please enter a number." );
                continue;
            }

            switch ( choice )
            {
                case 1:
                    DisplayAllMovies();
                    break;
                case 2:
                    DisplaySearchMenu();
                    break;
                case 3:
                    DisplayAdvancedQueryMenu();
                    break;
                case 4:
                    DisplayStatisticsMenu();
                    break;
                case 0:
                    Console.WriteLine( "Goodbye!" );
                    return;
                default:
                    Console.WriteLine( "Invalid option. Please try again." );
                    break;
            }
        }
    }

    private static void DisplayAllMovies()
    {
        Console.WriteLine( "\nAll Movies (Sorted by Title)" );
        Console.WriteLine( "---------------------------" );

        var sortedMovies = movies.OrderBy( m => m.Title ).ToList();
        DisplayMovieList( sortedMovies );
    }

    private static void DisplaySearchMenu()
    {
        while ( true )
        {
            Console.WriteLine( "\nSearch Movies" );
            Console.WriteLine( "1. By title" );
            Console.WriteLine( "2. By director" );
            Console.WriteLine( "3. By actor" );
            Console.WriteLine( "4. By genre" );
            Console.WriteLine( "5. By rating category" );
            Console.WriteLine( "6. By year" );
            Console.WriteLine( "0. Back to main menu" );
            Console.Write( "Select an option: " );

            if ( !int.TryParse( Console.ReadLine() , out int choice ) )
            {
                Console.WriteLine( "Invalid input. Please enter a number." );
                continue;
            }

            switch ( choice )
            {
                case 1:
                    SearchByTitle();
                    break;
                case 2:
                    SearchByDirector();
                    break;
                case 3:
                    SearchByActor();
                    break;
                case 4:
                    SearchByGenre();
                    break;
                case 5:
                    SearchByRatingCategory();
                    break;
                case 6:
                    SearchByYear();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine( "Invalid option. Please try again." );
                    break;
            }
        }
    }

    private static void DisplayAdvancedQueryMenu()
    {
        while ( true )
        {
            Console.WriteLine( "\nAdvanced Queries" );
            Console.WriteLine( "1. Movies with rating above..." );
            Console.WriteLine( "2. Movies between years..." );
            Console.WriteLine( "3. Movies by director with rating above..." );
            Console.WriteLine( "4. Movies starring two specific actors" );
            Console.WriteLine( "5. Longest movie titles" );
            Console.WriteLine( "0. Back to main menu" );
            Console.Write( "Select an option: " );

            if ( !int.TryParse( Console.ReadLine() , out int choice ) )
            {
                Console.WriteLine( "Invalid input. Please enter a number." );
                continue;
            }

            switch ( choice )
            {
                case 1:
                    QueryByMinRating();
                    break;
                case 2:
                    QueryByYearRange();
                    break;
                case 3:
                    QueryByDirectorAndMinRating();
                    break;
                case 4:
                    QueryByMultipleActors();
                    break;
                case 5:
                    QueryLongestTitles();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine( "Invalid option. Please try again." );
                    break;
            }
        }
    }

    private static void DisplayStatisticsMenu()
    {
        while ( true )
        {
            Console.WriteLine( "\nStatistics" );
            Console.WriteLine( "1. Average rating by genre" );
            Console.WriteLine( "2. Movies count by rating category" );
            Console.WriteLine( "3. Top 10 highest rated movies" );
            Console.WriteLine( "4. Bottom 10 lowest rated movies" );
            Console.WriteLine( "5. Year with most movies" );
            Console.WriteLine( "6. Most common actor" );
            Console.WriteLine( "0. Back to main menu" );
            Console.Write( "Select an option: " );

            if ( !int.TryParse( Console.ReadLine() , out int choice ) )
            {
                Console.WriteLine( "Invalid input. Please enter a number." );
                continue;
            }

            switch ( choice )
            {
                case 1:
                    ShowAverageRatingByGenre();
                    break;
                case 2:
                    ShowCountByRatingCategory();
                    break;
                case 3:
                    ShowTop10RatedMovies();
                    break;
                case 4:
                    ShowBottom10RatedMovies();
                    break;
                case 5:
                    ShowYearWithMostMovies();
                    break;
                case 6:
                    ShowMostCommonActor();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine( "Invalid option. Please try again." );
                    break;
            }
        }
    }

    #region Search Methods
    private static void SearchByTitle()
    {
        Console.Write( "\nEnter title or part of title: " );
        string? searchTerm = Console.ReadLine();

        var results = movies.Where( m => m.Title.Contains( searchTerm ?? "NO_ANSWER_SHOULD_RETURN" , StringComparison.OrdinalIgnoreCase ) )
                          .OrderBy( m => m.Title )
                          .ToList();

        Console.WriteLine( $"\nFound {results.Count} movies matching '{searchTerm}':" );
        DisplayMovieList( results );
    }

    private static void SearchByDirector()
    {
        Console.Write( "\nEnter director name or part of name: " );
        string? searchTerm = Console.ReadLine();

        var results = movies.Where( m => m.Director.Contains( searchTerm ?? "NO_ANSWER_SHOULD_RETURN" , StringComparison.OrdinalIgnoreCase ) )
                          .OrderBy( m => m.Director )
                          .ThenBy( m => m.Year )
                          .ToList();

        Console.WriteLine( $"\nFound {results.Count} movies directed by '{searchTerm}':" );
        DisplayMovieList( results );
    }

    private static void SearchByActor()
    {
        Console.Write( "\nEnter actor name or part of name: " );
        string? searchTerm = Console.ReadLine();
        var results = movies.Where( m => m.Actors.Any( a => a.Contains( searchTerm ?? "NO_ANSWER_SHOULD_RETURN" , StringComparison.OrdinalIgnoreCase ) ) )
                          .OrderBy( m => m.Title )
                          .ToList();

        Console.WriteLine( $"\nFound {results.Count} movies featuring '{searchTerm}':" );
        DisplayMovieList( results );
    }

    private static void SearchByGenre()
    {
        Console.Write( "\nEnter genre: " );
        string genre = Console.ReadLine() ?? "NO_ANSWER_SHOULD_BE_RETURNED";

        var results = movies.Where( m => m.Genre.Equals( genre , StringComparison.OrdinalIgnoreCase ) )
                          .OrderBy( m => m.Title )
                          .ToList();

        Console.WriteLine( $"\nFound {results.Count} {genre} movies:" );
        DisplayMovieList( results );
    }

    private static void SearchByRatingCategory()
    {
        Console.Write( "\nEnter rating category (G, PG, PG-13, R, etc.): " );
        string category = Console.ReadLine() ?? "NO_ANSWER_SHOULD_BE_RETURNED";

        var results = movies.Where( m => m.RatingCategory.Equals( category , StringComparison.OrdinalIgnoreCase ) )
                          .OrderByDescending( m => m.Rating )
                          .ToList();

        Console.WriteLine( $"\nFound {results.Count} {category} rated movies:" );
        DisplayMovieList( results );
    }

    private static void SearchByYear()
    {
        Console.Write( "\nEnter year: " );
        if ( int.TryParse( Console.ReadLine() , out int year ) )
        {
            var results = movies.Where( m => m.Year == year )
                              .OrderBy( m => m.Title )
                              .ToList();

            Console.WriteLine( $"\nFound {results.Count} movies from {year}:" );
            DisplayMovieList( results );
        }
        else
        {
            Console.WriteLine( "Invalid year entered." );
        }
    }
    #endregion

    #region Advanced Query Methods
    private static void QueryByMinRating()
    {
        Console.Write( "\nEnter minimum rating (0.0 - 10.0): " );
        if ( double.TryParse( Console.ReadLine() , out double minRating ) && minRating >= 0 && minRating <= 10 )
        {
            var results = movies.Where( m => m.Rating >= minRating )
                              .OrderByDescending( m => m.Rating )
                              .ToList();

            Console.WriteLine( $"\nFound {results.Count} movies with rating {minRating} or higher:" );
            DisplayMovieList( results );
        }
        else
        {
            Console.WriteLine( "Invalid rating entered. Please enter a number between 0 and 10." );
        }
    }

    private static void QueryByYearRange()
    {
        Console.Write( "\nEnter starting year: " );
        if ( !int.TryParse( Console.ReadLine() , out int startYear ) )
        {
            Console.WriteLine( "Invalid year entered." );
            return;
        }

        Console.Write( "Enter ending year: " );
        if ( !int.TryParse( Console.ReadLine() , out int endYear ) )
        {
            Console.WriteLine( "Invalid year entered." );
            return;
        }

        var results = movies.Where( m => m.Year >= startYear && m.Year <= endYear )
                          .OrderBy( m => m.Year )
                          .ThenBy( m => m.Title )
                          .ToList();

        Console.WriteLine( $"\nFound {results.Count} movies between {startYear} and {endYear}:" );
        DisplayMovieList( results );
    }

    private static void QueryByDirectorAndMinRating()
    {
        Console.Write( "\nEnter director name: " );
        string director = Console.ReadLine() ?? "NO_ANSWER_SHOULD_BE_RETURNED";

        Console.Write( "Enter minimum rating (0.0 - 10.0): " );
        if ( !double.TryParse( Console.ReadLine() , out double minRating ) || minRating < 0 || minRating > 10 )
        {
            Console.WriteLine( "Invalid rating entered." );
            return;
        }

        var results = movies.Where( m => m.Director.Contains( director , StringComparison.OrdinalIgnoreCase ) &&
                                      m.Rating >= minRating )
                          .OrderByDescending( m => m.Rating )
                          .ToList();

        Console.WriteLine( $"\nFound {results.Count} movies by {director} with rating {minRating} or higher:" );
        DisplayMovieList( results );
    }

    private static void QueryByMultipleActors()
    {
        Console.Write( "\nEnter first actor name: " );
        string actor1 = Console.ReadLine() ?? "NO_ANSWER_SHOULD_BE_RETURNED";

        Console.Write( "Enter second actor name: " );
        string actor2 = Console.ReadLine() ?? "NO_ANSWER_SHOULD_BE_RETURNED";

        var results = movies.Where( m => m.Actors.Any( a => a.Contains( actor1 , StringComparison.OrdinalIgnoreCase ) ) &&
                                      m.Actors.Any( a => a.Contains( actor2 , StringComparison.OrdinalIgnoreCase ) ) )
                          .OrderBy( m => m.Title )
                          .ToList();

        Console.WriteLine( $"\nFound {results.Count} movies featuring both {actor1} and {actor2}:" );
        DisplayMovieList( results );
    }

    private static void QueryLongestTitles()
    {
        Console.Write( "\nEnter number of movies to show: " );
        if ( !int.TryParse( Console.ReadLine() , out int count ) || count <= 0 )
        {
            Console.WriteLine( "Invalid number entered." );
            return;
        }

        var results = movies.OrderByDescending( m => m.Title.Length )
                          .Take( count )
                          .ToList();

        Console.WriteLine( $"\nTop {count} movies with longest titles:" );
        DisplayMovieList( results );
    }
    #endregion

    #region Statistics Methods
    private static void ShowAverageRatingByGenre()
    {
        var stats = movies.GroupBy( m => m.Genre )
                        .Select( g => new
                        {
                            Genre = g.Key ,
                            AverageRating = g.Average( m => m.Rating ) ,
                            MovieCount = g.Count()
                        } )
                        .OrderByDescending( g => g.AverageRating )
                        .ToList();

        Console.WriteLine( "\nAverage Rating by Genre:" );
        Console.WriteLine( "-----------------------" );
        foreach ( var stat in stats )
        {
            Console.WriteLine( $"{stat.Genre}: {stat.AverageRating:F2} (from {stat.MovieCount} movies)" );
        }
    }

    private static void ShowCountByRatingCategory()
    {
        var stats = movies.GroupBy( m => m.RatingCategory )
                        .Select( g => new
                        {
                            Rating = g.Key ,
                            MovieCount = g.Count()
                        } )
                        .OrderByDescending( g => g.MovieCount )
                        .ToList();

        Console.WriteLine( "\nMovie Count by Rating Category:" );
        Console.WriteLine( "-----------------------------" );
        foreach ( var stat in stats )
        {
            Console.WriteLine( $"{stat.Rating}: {stat.MovieCount} movies" );
        }
    }

    private static void ShowTop10RatedMovies()
    {
        var topMovies = movies.OrderByDescending( m => m.Rating )
                            .Take( 10 )
                            .ToList();

        Console.WriteLine( "\nTop 10 Highest Rated Movies:" );
        Console.WriteLine( "---------------------------" );
        DisplayMovieList( topMovies );
    }

    private static void ShowBottom10RatedMovies()
    {
        var bottomMovies = movies.OrderBy( m => m.Rating )
                               .Take( 10 )
                               .ToList();

        Console.WriteLine( "\nBottom 10 Lowest Rated Movies:" );
        Console.WriteLine( "------------------------------" );
        DisplayMovieList( bottomMovies );
    }

    private static void ShowYearWithMostMovies()
    {
        var yearStats = movies.GroupBy( m => m.Year )
                            .Select( g => new
                            {
                                Year = g.Key ,
                                MovieCount = g.Count()
                            } )
                            .OrderByDescending( g => g.MovieCount )
                            .First();

        Console.WriteLine( $"\nYear with most movies: {yearStats.Year} ({yearStats.MovieCount} movies)" );
    }

    private static void ShowMostCommonActor()
    {
        var actorStats = movies.SelectMany( m => m.Actors )
                             .GroupBy( a => a )
                             .Select( g => new
                             {
                                 Actor = g.Key ,
                                 MovieCount = g.Count()
                             } )
                             .OrderByDescending( g => g.MovieCount )
                             .First();

        Console.WriteLine( $"\nMost common actor: {actorStats.Actor} (appeared in {actorStats.MovieCount} movies)" );
    }
    #endregion

    #region Helper Methods
    private static void DisplayMovieList( List<Movie> movieList )
    {
        if ( movieList.Count == 0 )
        {
            Console.WriteLine( "No movies found." );
            return;
        }

        foreach ( var movie in movieList )
        {
            Console.WriteLine( $"\n{movie.Title} ({movie.Year})" );
            Console.WriteLine( $"Director: {movie.Director}" );
            Console.WriteLine( $"Actors: {string.Join( ", " , movie.Actors )}" );
            Console.WriteLine( $"Genre: {movie.Genre}, Rating: {movie.Rating:F1} ({movie.RatingCategory})" );
        }

        Console.WriteLine( $"\nTotal: {movieList.Count} movies" );
    }

    private static void DisplayMovieSummary( List<Movie> movieList )
    {
        if ( movieList.Count == 0 )
        {
            Console.WriteLine( "No movies found." );
            return;
        }

        foreach ( var movie in movieList )
        {
            Console.WriteLine( $"{movie.Title} ({movie.Year}) - {movie.Rating:F1}/10" );
        }

        Console.WriteLine( $"\nTotal: {movieList.Count} movies" );
    }
    
    #endregion
}