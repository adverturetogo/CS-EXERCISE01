using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem.LibrarySystem
{
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
}