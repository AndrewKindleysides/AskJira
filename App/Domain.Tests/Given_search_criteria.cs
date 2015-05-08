using System;
using Xunit;

namespace Domain.Tests
{
    public class Search_for_all_issues_by_date
    {
        [Fact]
        public void Default_search_values_search_for_just_the_date()
        {
            var date = DateTime.Parse("4/4/2015");

            var dateFrom = date.AddDays(-2).Date;
            var dateTo = date.Date;

            var expected = string.Format("https://jira.advancedcsg.com/rest/api/2/search?jql=project=LCSMLC AND (created >= '2015-04-02 12:00' AND created <= '2015-04-04 12:00')");
            var actual = new QueryBuilder().Build(dateFrom, dateTo);
            
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void search_text_values()
        {
            var date = DateTime.Parse("4/4/2015");

            var dateFrom = date.AddDays(-2).Date;
            var dateTo = date.Date;

            var expected = string.Format("https://jira.advancedcsg.com/rest/api/2/search?jql=project=LCSMLC AND (created >= '2015-04-02 12:00' AND created <= '2015-04-04 12:00') AND (summary ~ 'search for this' OR description ~ 'search for this' OR comment ~ 'search for this')");
            var actual = new QueryBuilder().Build(dateFrom, dateTo,"search for this");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void search_issue_type()
        {
            var date = DateTime.Parse("4/4/2015");

            var dateFrom = date.AddDays(-2).Date;
            var dateTo = date.Date;

            var expected = string.Format("https://jira.advancedcsg.com/rest/api/2/search?jql=project=LCSMLC AND (created >= '2015-04-02 12:00' AND created <= '2015-04-04 12:00') AND issuetype = 'issue type A'");
            var actual = new QueryBuilder().Build(dateFrom, dateTo,"","issue type A");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void search_client()
        {
            var date = DateTime.Parse("4/4/2015");

            var dateFrom = date.AddDays(-2).Date;
            var dateTo = date.Date;

            var expected = string.Format("https://jira.advancedcsg.com/rest/api/2/search?jql=project=LCSMLC AND (created >= '2015-04-02 12:00' AND created <= '2015-04-04 12:00') AND cf[10200]~'client name'");
            var actual = new QueryBuilder().Build(dateFrom, dateTo, null, "Any","client name");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void search_component()
        {
            var date = DateTime.Parse("4/4/2015");

            var dateFrom = date.AddDays(-2).Date;
            var dateTo = date.Date;

            var expected = string.Format("https://jira.advancedcsg.com/rest/api/2/search?jql=project=LCSMLC AND (created >= '2015-04-02 12:00' AND created <= '2015-04-04 12:00') AND Component = 'component Id'");
            var actual = new QueryBuilder().Build(dateFrom, dateTo, null, "Any", "", "component Id");

            Assert.Equal(expected, actual);
        }
    }

    public class QueryBuilder
    {
        public string Build(DateTime dateFrom, DateTime dateTo, string searchText = "", string issueType = "Any", string client = "", string component = "0", string version = "0")
        {
            var v = "";
            if (!string.IsNullOrEmpty(version) && version != "0")
                v = string.Format(" AND FixVersion = '{0}'", version);

            var c = "";
            if (!string.IsNullOrEmpty(component) && component != "0")
                c = string.Format(" AND Component = '{0}'", component);

            var s = "";
            if (!string.IsNullOrEmpty(searchText))
                s = string.Format(" AND (summary ~ '{0}' OR description ~ '{0}' OR comment ~ '{0}')", searchText);

            var cl = "";
            if (!string.IsNullOrEmpty(client))
                cl = string.Format(" AND cf[10200]~'{0}'", client);

            var i = "";
            if (issueType != "Any")
                i = string.Format(" AND issuetype = '{0}'", issueType);

            var dateRange = string.Format(" AND (created >= '{0}' AND created <= '{1}')", dateFrom.Date.ToString("yyyy-MM-dd h:mm").Replace('/', '-'), dateTo.Date.ToString("yyyy-MM-dd h:mm").Replace('/', '-'));
            
            return string.Format("https://jira.advancedcsg.com/rest/api/2/search?jql=project=LCSMLC{0}{1}{2}{3}{4}{5}",dateRange, s, v, c, cl, i);
        }
    }
}
