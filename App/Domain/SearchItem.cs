using System;

namespace Domain
{
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
}