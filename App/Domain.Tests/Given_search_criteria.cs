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
    }
    
    public class SearchItem
    {
        public DateTime DateFrom;
        public DateTime DateTo;
        public string SearchText;
        public string IssueType;
        public string Client;
        public string Component;
        public string Version;

        public SearchItem(DateTime dateFrom, DateTime dateTo)
        {
            DateFrom = dateFrom;
            DateTo = dateTo;
            SearchText = "";
            IssueType = "Any";
            Client = "";
            Component = "0";
            Version = "0";
        }
    }

    public class QueryBuilder
    {
        public string Build(SearchItem searchItem)
        {
            var queryString = string.Format(
                    "https://jira.advancedcsg.com/rest/api/2/search?jql=project=LCSMLC AND (created >= '{0}' AND created <= '{1}')",
                    FormatTheDate(searchItem.DateFrom),
                    FormatTheDate(searchItem.DateTo));

            if (searchItem.Version != "0")
                queryString += string.Format(" AND FixVersion = '{0}'", searchItem.Version);

            if (searchItem.Component != "0")
                queryString += string.Format(" AND Component = '{0}'", searchItem.Component);

            if (searchItem.SearchText != "")
                queryString += string.Format(" AND (summary ~ '{0}' OR description ~ '{0}' OR comment ~ '{0}')", searchItem.SearchText);

            if (searchItem.Client != "")
                queryString += string.Format(" AND cf[10200]~'{0}'", searchItem.Client);

            if (searchItem.IssueType != "Any")
                queryString += string.Format(" AND issuetype = '{0}'", searchItem.IssueType);

            return queryString;
        }

        private string FormatTheDate(DateTime date)
        {
            return date.Date.ToString("yyyy-MM-dd h:mm").Replace('/', '-');
        }
    }
}