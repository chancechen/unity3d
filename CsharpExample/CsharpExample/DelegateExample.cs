
// C# 中的委托类似于 C 或 C++ 中的函数指针。
// 与 C 或 C++ 中的函数指针不同，委托是面向对象、类型安全的，并且是安全的。

// 委托声明定义一种类型，它用一组特定的参数以及返回类型封装方法。
// 对于静态方法，委托对象封装要调用的方法。
// 对于实例方法，委托对象同时封装一个实例和该实例上的一个方法

// 声明委托 : public delegate void ProcessBookDelegate(Book book);
// 实例化委托 :  bookDB.ProcessPaperbackBooks(new ProcessBookDelegate(PrintTitle));
// 调用委托 :processBook(b);

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpExample
{

    using System.Collections;

    // Declare a delegate type for processing a book:
    public delegate void ProcessBookDelegate(Book book);
    public delegate bool IsRunningDelegate( Book book );

    // Describes a book in the book list:
    public struct Book
    {
        public string Title;        // Title of the book.
        public string Author;       // Author of the book.
        public decimal Price;       // Price of the book.
        public bool Paperback;      // Is it paperback?

        public Book(string title, string author, decimal price, bool paperBack)
        {
            Title = title;
            Author = author;
            Price = price;
            Paperback = paperBack;
        }
    }

    // Maintains a book database.
    public class BookDB
    {
        // List of all books in the database:
        ArrayList list = new ArrayList();

        // Add a book to the database:
        public void AddBook(string title, string author, decimal price, bool paperBack)
        {
            list.Add(new Book(title, author, price, paperBack));
        }

        // Call a passed-in delegate on each paperback book to process it: 
        public void ProcessPaperbackBooks(ProcessBookDelegate processBook)
        {
            foreach (Book b in list)
            {
                if (b.Paperback)
                    // Calling the delegate:
                    processBook(b);
            }
        }
    }

    // Class to total and average prices of books:
    class PriceTotaller
    {
        int countBooks = 0;
        decimal priceBooks = 0.0m;

        internal void AddBookToTotal(Book book)
        {
            countBooks += 1;
            priceBooks += book.Price;
        }

        internal decimal AveragePrice()
        {
            return priceBooks / countBooks;
        }
    }

    delegate void MyDelegate(string s);
    class MyClass
    {
        public static void Hello(string s)
        {
            Console.WriteLine("  Hello, {0}!", s);
        }

        public static void Goodbye(string s)
        {
            Console.WriteLine("  Goodbye, {0}!", s);
        }
    }

    class DelegateExample:Instance<DelegateExample>
    {
        // Print the title of the book.
        static void PrintTitle(Book b){

            Console.WriteLine("   {0}", b.Title);
        }

        // Initialize the book database with some test books:
        static void AddBooks(BookDB bookDB){

            bookDB.AddBook("The C Programming Language", "Brian W. Kernighan and Dennis M. Ritchie", 19.95m, true);
            bookDB.AddBook("The Unicode Standard 2.0", "The Unicode Consortium", 39.95m, true);
            bookDB.AddBook("The MS-DOS Encyclopedia", "Ray Duncan", 129.95m, false);
            bookDB.AddBook("Dogbert's Clues for the Clueless", "Scott Adams", 12.00m, true);
        }
        

        public override void Show()
        {
            BookDB bookDB = new BookDB();            
            // Initialize the database with some books:
            AddBooks(bookDB);

            // Print all the titles of paperbacks:
            Console.WriteLine("Paperback Book Titles:");
            // Create a new delegate object associated with the static 
            // method Test.PrintTitle:
            bookDB.ProcessPaperbackBooks(new ProcessBookDelegate(PrintTitle));

            // Get the average price of a paperback by using
            // a PriceTotaller object:
            PriceTotaller totaller = new PriceTotaller();
            // Create a new delegate object associated with the nonstatic 
            // method AddBookToTotal on the object totaller:
            bookDB.ProcessPaperbackBooks(new ProcessBookDelegate(totaller.AddBookToTotal));
            Console.WriteLine("Average Paperback Book Price: ${0:#.##}",totaller.AveragePrice());

            MyDelegate a, b, c, d;

            // Create the delegate object a that references 
            // the method Hello:
            a = new MyDelegate(MyClass.Hello);
            // Create the delegate object b that references 
            // the method Goodbye:
            b = new MyDelegate(MyClass.Goodbye);
            // The two delegates, a and b, are composed to form c: 
            c = a + b;
            // Remove a from the composed delegate, leaving d, 
            // which calls only the method Goodbye:
            d = c - a;

            Console.WriteLine("Invoking delegate a:");
            a("A");
            Console.WriteLine("Invoking delegate b:");
            b("B");
            Console.WriteLine("Invoking delegate c:");
            c("C");
            Console.WriteLine("Invoking delegate d:");
            d("D");
        }
    }
}
