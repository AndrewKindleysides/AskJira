using Xunit;

namespace Domain.Tests
{
    public class Paging
    {
        [Fact]
        public void number_of_pages_of_results_is_determined()
        {
            var pageCalculator = new PageCalculator();
            var pages = pageCalculator.NumberOfPages(12546);
            Assert.Equal(126,pages);
        }
    }
}
