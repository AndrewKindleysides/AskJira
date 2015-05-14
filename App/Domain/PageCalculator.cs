namespace Domain
{
    public class PageCalculator
    {
        private readonly int _numberOfItems;

        public PageCalculator(int numberOfItems)
        {
            _numberOfItems = numberOfItems;
        }

        public int NumberOfPages(int totalJiras)
        {
            return (totalJiras + _numberOfItems - 1) / _numberOfItems;
        }
    }
}