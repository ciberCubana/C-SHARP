using System;
using System.Collections.Generic;

namespace Movies
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie movie1 = new Movie();
            
            movie1.Title= "Troy";
            movie1.Genere = "Dramma";
            movie1.Price= 10.99;

            Movie movie2 = new Movie();
            
            movie2.Title= "Titanic";
            movie2.Genere = "Dramma";
            movie2.Price= 2.99;

            Movie movie3 = new Movie();
            
            movie3.Title= "Shlinder's list";
            movie3.Genere = "Dramma";
            movie3.Price= 15.99;

List<Movie> myMovies = new List<Movie>();

myMovies.Add(movie1);
myMovies.Add(movie2);
myMovies.Add(movie3); 



foreach (Movie movie in myMovies ){
    Console.WriteLine("Title: "+ movie.Title+ " Genre: "+ movie.Genere
					    + "Price: "+ movie.Price);
                    }
            

        }
    }

    public class Movie 
{
    
    public string Title { get; set; }
    public string Genere { get; set; }
    public double Price { get; set; }
}
}
