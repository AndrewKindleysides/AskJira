using System;
using Xunit;

namespace Domain.Tests
{
    public class Search_for_jiras
    {
        public class by_no_items
        {

            [Fact]
            public void just_the_date()
            {
                var date = DateTime.Parse("4/4/2015");
                var searchItem = new SearchItem(date.AddDays(-2).Date, date.Date);

                var expected =
                    string.Format(
                        "https://jira.advancedcsg.com/rest/api/2/search?jql=project=LCSMLC AND (created >= '2015-04-02 12:00' AND created <= '2015-04-04 12:00')");
                var actual = new QueryBuilder().Build(searchItem);

                Assert.Equal(expected, actual);
            }
        }

        public class by_single_item
        {
            private readonly SearchItem _searchItem;

            public by_single_item()
            {
                var date = DateTime.Parse("4/4/2015");
                _searchItem = new SearchItem(date.AddDays(-2).Date, date.Date);
            }

            [Fact]
            public void search_text_values()
            {
                var expected =
                    string.Format(
                        "https://jira.advancedcsg.com/rest/api/2/search?jql=project=LCSMLC AND (created >= '2015-04-02 12:00' AND created <= '2015-04-04 12:00') AND (summary ~ 'search for this' OR description ~ 'search for this' OR comment ~ 'search for this')");
                _searchItem.SearchText = "search for this";
                var actual = new QueryBuilder().Build(_searchItem);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void search_issue_type()
            {
                var expected =
                    string.Format(
                        "https://jira.advancedcsg.com/rest/api/2/search?jql=project=LCSMLC AND (created >= '2015-04-02 12:00' AND created <= '2015-04-04 12:00') AND issuetype = 'issue type A'");
                _searchItem.IssueType = "issue type A";
                var actual = new QueryBuilder().Build(_searchItem);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void search_client()
            {
                var expected =
                    string.Format(
                        "https://jira.advancedcsg.com/rest/api/2/search?jql=project=LCSMLC AND (created >= '2015-04-02 12:00' AND created <= '2015-04-04 12:00') AND cf[10200]~'client name'");
                _searchItem.Client = "client name";
                var actual = new QueryBuilder().Build(_searchItem);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void search_component()
            {
                var expected =
                    string.Format(
                        "https://jira.advancedcsg.com/rest/api/2/search?jql=project=LCSMLC AND (created >= '2015-04-02 12:00' AND created <= '2015-04-04 12:00') AND Component = 'component Id'");
                _searchItem.Component = "component Id";
                var actual = new QueryBuilder().Build(_searchItem);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void search_fix_version()
            {
                var expected =
                    string.Format(
                        "https://jira.advancedcsg.com/rest/api/2/search?jql=project=LCSMLC AND (created >= '2015-04-02 12:00' AND created <= '2015-04-04 12:00') AND FixVersion = 'version Id'");
                _searchItem.Version = "version Id";
                var actual = new QueryBuilder().Build(_searchItem);
                Assert.Equal(expected, actual);
            }
        }

        public class by_multiple_items
        {
            private readonly SearchItem _searchItem;

            public by_multiple_items()
            {
                var date = DateTime.Parse("4/4/2015");
                _searchItem = new SearchItem(date.AddDays(-2).Date, date.Date)
                {
                    Client = "client search",
                    Component = "search compenent",
                    SearchText = "search for this",
                    IssueType = "issue type search item",
                    Version = "1.0"
                };
            }

            [Fact]
            public void query_is_built_with_the_values()
            {
                var actual = new QueryBuilder().Build(_searchItem);
                Assert.Contains("https://jira.advancedcsg.com/rest/api/2/search?jql=project=LCSMLC", actual);
                Assert.Contains("AND issuetype = 'issue type search item'", actual);
                Assert.Contains("AND cf[10200]~'client search'", actual);
                Assert.Contains("AND (summary ~ 'search for this' OR description ~ 'search for this' OR comment ~ 'search for this')", actual);
                Assert.Contains("AND Component = 'search compenent'", actual);
                Assert.Contains("AND FixVersion = '1.0'", actual);
            }
        }
    }
}