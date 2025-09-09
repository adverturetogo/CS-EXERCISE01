namespace LibrarySystem.LibrarySystem
{
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
}