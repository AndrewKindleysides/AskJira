using System;

namespace Domain
{
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
        public string BuildBatched(SearchItem searchItem, int pageNumber)
        {
            var startAt = 100*pageNumber;
            var queryString = string.Format(
                "https://jira.advancedcsg.com/rest/api/2/search?jql=project=LCSMLC AND (created >= '{0}' AND created <= '{1}') &maxResults=100&startAt={2}",
                FormatTheDate(searchItem.DateFrom),
                FormatTheDate(searchItem.DateTo),
                startAt);

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