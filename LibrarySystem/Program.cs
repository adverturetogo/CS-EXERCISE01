using System;
using System.Collections.Generic;

namespace LibrarySystem.LibrarySystem
{
    class Program
    {
        static void Main()
        {
            LibraryManager library = new();

            library.AddItem(new Novel(1, "To Kill a Mockingbird", "Harper Lee"));
            library.AddItem(new Magazine(2, "National Geographic", 256));
            library.AddItem(new TextBook(3, "Introduction to Algorithms", "MIT Press"));
            library.AddItem(new Novel(4, "1984", "George Orwell"));

            Member alice = new("Alice");
            Member bob = new("Bob");
            library.RegisterMember(alice);
            library.RegisterMember(bob);

            Console.WriteLine("=== Library Catalog ===");
            library.ShowCatalog();

            Console.WriteLine("\n=== Alice's Borrowing Process ===");
            for (int id = 1; id <= 3; id++)
            {
                var item = library.FindItemById(id);
                if (item != null) Console.WriteLine(alice.BorrowItem(item));
            }

            Console.WriteLine("\n=== Attempting to Borrow 4th Item ===");
            var fourth = library.FindItemById(4);
            if (fourth != null) Console.WriteLine(alice.BorrowItem(fourth));

            Console.WriteLine("\n=== Alice's Borrowed Items ===");
            alice.GetBorrowedItems().ForEach(i => Console.WriteLine(i.GetDetails()));
        }
    }
}