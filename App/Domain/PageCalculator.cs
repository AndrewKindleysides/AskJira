namespace Domain
{
    public class PageCalculator
    {
        public int NumberOfPages(int totalJiras)
        {
            return (totalJiras + 100 - 1) / 100;
        }
    }
}