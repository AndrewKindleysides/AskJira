using Xunit;

namespace Domain.Tests
{
    namespace Number_of_pages_is_calculated
    {
        public class when_items_per_page_is_set_to
        {
            [Fact]
            public void _10_jiras_per_page()
            {
                var pageCalculator = new PageCalculator(10);
                var pages = pageCalculator.NumberOfPages(12546);
                Assert.Equal(1255, pages);
            }

            [Fact]
            public void _50_jiras_per_page()
            {
                var pageCalculator = new PageCalculator(50);
                var pages = pageCalculator.NumberOfPages(12546);
                Assert.Equal(251, pages);
            }

            [Fact]
            public void _100_jiras_per_page()
            {
                var pageCalculator = new PageCalculator(100);
                var pages = pageCalculator.NumberOfPages(12546);
                Assert.Equal(126, pages);
            }

            [Fact]
            public void _500_jiras_per_page()
            {
                var pageCalculator = new PageCalculator(500);
                var pages = pageCalculator.NumberOfPages(12546);
                Assert.Equal(26, pages);
            }
        }
    }
}
