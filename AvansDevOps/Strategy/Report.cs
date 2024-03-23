using System;
using System.Collections.Generic;

namespace AvansDevOps.Strategy
{
    public class Report
    {
        public string Title { get; private set; }
        public DateTime CreationDate { get; private set; }
        public List<string> ContentSections { get; private set; }

        public Report(string title)
        {
            Title = title;
            CreationDate = DateTime.Now; // Sets to current date
            ContentSections = new List<string>();
        }

        public void AddContentSection(string content)
        {
            ContentSections.Add(content);
        }
    }
}