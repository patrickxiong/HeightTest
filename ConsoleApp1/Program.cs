using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetTitle(" Hello World! ", 5));

            var bc = new BookCollection();
            bc.ListBooks();

            ref Book book = ref bc.GetBookByTitle("Call of the Wild, The");
            if (book != null)
                book = new Book { Title = "Republic, The", Author = "Plato" };
            bc.ListBooks();
        }

        public static string GetTitle(string t, int i) =>
            t == null || i > t.Length ? t
            :
            $"{t.Substring(0, i - 3)}...";

        delegate void TestDelegate3(); // ❌ Defined inside a method
        public void Start()
        {
            var a = GetInt();

            int GetInt(){
                return 5;
            }
        }

        //public static string GetTitle2(string t, int i) =>
        //    {
        //     if(t==null) return null;
        //    else 
        //    return
        // t == null || i > t.Length? t
        // :
        // $"{t.Substring(0, i - 3)}...";
    }

    public class Book
    {
        public string Author;
        public string Title;
    }

    public class BookCollection
    {
        private Book[] books = { new Book { Title = "Call of the Wild, The", Author = "Jack London" },
                        new Book { Title = "Tale of Two Cities, A", Author = "Charles Dickens" }
                       };
        private Book nobook = null;
        private Book myBook = null;
        public ref Book GetBookByTitle(string title)
        {
            for (int ctr = 0; ctr < books.Length; ctr++)
            {
                if (title == books[ctr].Title)
                {
                    myBook =books[ctr];
                    return ref myBook;
                }
            }
            return ref nobook;
        }

        public void ListBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title}, by {book.Author}");
            }
            Console.WriteLine();
        }
    }
}
