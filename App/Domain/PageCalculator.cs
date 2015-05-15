namespace Domain
{
    public class PageCalculator
    {
        private readonly int _itemsPerPage;

        public PageCalculator(int itemsPerPage)
        {
            _itemsPerPage = itemsPerPage;
        }

        public int NumberOfPages(int totalJiras)
        {
            return (totalJiras + _itemsPerPage - 1) / _itemsPerPage;
        }
    }
}