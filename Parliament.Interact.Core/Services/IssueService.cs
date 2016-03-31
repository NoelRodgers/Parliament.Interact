using System.Collections.Generic;
using System.Linq;
using Parliament.Interact.Core.Domain;
using Parliament.Interact.Core.Domain.Context;

namespace Parliament.Interact.Core.Services
{
    public class IssueService : IIssueService
    {

        private IQueryable<Issue> GetIssues(InteractDbContext context)
        {
            return context.Issues
                            .Include("TimeLines")
                            .Include("FurtherReadings")
                            .Include("IssueActions")
                            .Include("IssueActions.ActionItem")
                            .Include("IssueActions.IssueActionContents")
                            .Include("IssueActions.ActionItem.ActionContents")
                            .OrderBy(issue => issue.LogicalOrder);
        }

        public List<Issue> GetTopFiveIssues()
        {
            using (var context = new InteractDbContext())
            {
                return GetIssues(context).Take(5).ToList();
            }
        }

        public Issue GetIssueById(int id)
        {
            using (var context = new InteractDbContext())
            {
                return GetIssues(context).Single(issue => issue.Id == id);
            }
        }
    }
}