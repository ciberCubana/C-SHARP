using System;
using System.Collections.Generic;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DramaBook> mybooks = new List<DramaBook>();
            mybooks.Add(new DramaBook("el silencio de los corderos"));
            mybooks.Add(new DramaBook("corazon"));
            mybooks.Add(new DramaBook("el principito"));
            
            foreach(DramaBook db in mybooks)
                Console.WriteLine(db.Describe());
            Console.ReadKey();
        }
    }

    // public interface ICheckout{
    //     void CheckMeOut();
    // }

    // public interface IPurchable{
    //     void Buy();
    // }

    // public abstract class Book{
    //     public string title{get;set;}
    //     public int amountofpages{get;set;}
    //     public abstract void Read();
    //     public abstract void Bookmark();
    // }

    // public class Horror: Book, IPurchable, ICheckout{
    //     public void Buy()
    //     {
    //         Console.WriteLine("I bought a book");
    //     }
    //     public void CheckMeOut(){
    //         Console.WriteLine("I checked out a book");
    //     }
    //     public override void Read(){

    //     }
    //     public override void Bookmark(){

    //     }

    // }

    public interface IBooks
    {
        string Describe();

        string Title
        {
            get;
            set;
        }
    }

    class DramaBook : IBooks
    {
        private string title;

        public DramaBook(string title)
        {
            this.title = title;
        }

        public string Describe()
        {
            return "This is a drama book  and it title is " + this.title;
        }

       
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
    }
}