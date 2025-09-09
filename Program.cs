using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    public enum ItemType { Novels, Magazine, TextBook }

    public abstract class LibraryItem
    {
        private readonly int _id;
        private readonly string _title;

        public int Id => _id;          
        public string Title => _title;
        public ItemType Type { get; set; }

        public LibraryItem(int id, string title, ItemType type)
        {
            _id = id;
            _title = title;
            Type = type;
        }

        public abstract string GetDetails();
    }

    public class Novel : LibraryItem
    {
        private readonly string _author;
        public string Author => _author;

        public Novel(int id, string title, string author)
            : base(id, title, ItemType.Novels)
        {
            _author = author;
        }

        public override string GetDetails()
            => $"Novel: {Title} (ID: {Id}), Author: {Author}";
    }

    public class Magazine : LibraryItem
    {
        private readonly int _issueNumber;
        public int IssueNumber => _issueNumber;

        public Magazine(int id, string title, int issueNumber)
            : base(id, title, ItemType.Magazine)
        {
            _issueNumber = issueNumber;
        }

        public override string GetDetails()
            => $"Magazine: {Title} (ID: {Id}), Issue Number: {IssueNumber}";
    }

    public class TextBook : LibraryItem
    {
        private readonly string _publisher;
        public string Publisher => _publisher;

        public TextBook(int id, string title, string publisher)
            : base(id, title, ItemType.TextBook)
        {
            _publisher = publisher;
        }

        public override string GetDetails()
            => $"TextBook: {Title} (ID: {Id}), Publisher: {Publisher}";
    }

    public class Member
    {
        private readonly string _name;
        private readonly List<LibraryItem> _borrowedItems;

        public string Name => _name;
        public List<LibraryItem> BorrowedItems => _borrowedItems;

        public Member(string name)
        {
            _name = name;
            _borrowedItems = new List<LibraryItem>();
        }

        public string BorrowItem(LibraryItem item)
        {
            if (_borrowedItems.Count >= 3)
                return "You cannot borrow more than 3 items.";

            _borrowedItems.Add(item);
            return $"{item.Title} has been added to {Name}'s list of borrowed books.";
        }

        public string ReturnItem(LibraryItem item)
        {
            if (_borrowedItems.Contains(item))
            {
                _borrowedItems.Remove(item);
                return $"{item.Title} has been successfully returned.";
            }
            return "The item was not in the list of borrowed items.";
        }

        public List<LibraryItem> GetBorrowedItems() => _borrowedItems;
    }

    public class LibraryManager
    {
        private readonly List<LibraryItem> _catalog = new();
        private readonly List<Member> _members = new();

        public void AddItem(LibraryItem item) => _catalog.Add(item);
        public void RegisterMember(Member member) => _members.Add(member);

        public void ShowCatalog()
        {
            Console.WriteLine("\nLibrary Catalog:");
            foreach (var item in _catalog)
                Console.WriteLine(item.GetDetails());
        }

        public LibraryItem? FindItemById(int id)           
            => _catalog.Find(i => i.Id == id);

        public Member? FindMemberByName(string name)
            => _members.Find(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

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