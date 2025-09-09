using System.Collections.Generic;

namespace LibrarySystem.LibrarySystem
{
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
}