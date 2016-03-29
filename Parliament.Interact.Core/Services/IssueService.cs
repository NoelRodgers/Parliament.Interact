using System.Collections.Generic;
using System.Linq;
using Parliament.Interact.Core.Domain;
using Parliament.Interact.Core.Domain.Context;

namespace Parliament.Interact.Core.Services
{
    public class IssueService : IIssueService
    {
        public List<Issue> GetTopFiveIssues()
        {
            using (var context = new InteractDbContext())
            {
                return context.Issues.Include("TimeLines")
                              .Include("FurtherReadings")
                              .OrderBy(issue => issue.LogicalOrder)
                              .Take(5).ToList();
            }
        }

        public Issue GetIssueById(int id)
        {
            using (var context = new InteractDbContext())
            {
                return context.Issues.Single(issue => issue.Id == id);
            }
        }
    }
}