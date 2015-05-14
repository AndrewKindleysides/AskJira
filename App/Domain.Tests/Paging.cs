using Xunit;

namespace Domain.Tests
{
    namespace Paging
    {
        public class number_of_pages_of_results_is_calculated
        {
            [Fact]
            public void for_10_items_per_page()
            {
                var pageCalculator = new PageCalculator(10);
                var pages = pageCalculator.NumberOfPages(12546);
                Assert.Equal(1255, pages);
            }

            [Fact]
            public void for_50_items_per_page()
            {
                var pageCalculator = new PageCalculator(50);
                var pages = pageCalculator.NumberOfPages(12546);
                Assert.Equal(251, pages);
            }

            [Fact]
            public void for_100_items_per_page()
            {
                var pageCalculator = new PageCalculator(100);
                var pages = pageCalculator.NumberOfPages(12546);
                Assert.Equal(126, pages);
            }
        }
    }
}