using System;
using System.Collections.Generic;
using System.Linq;
using Parliament.Common.Caching;
using Parliament.Common.Extensions;
using Parliament.Common.Interfaces;
using Parliament.Interact.Core.Domain;
using Parliament.Interact.Core.Domain.Context;

namespace Parliament.Interact.Core.Services
{
    public class IssueService : CachedService, IIssueService
    {
        public IssueService(IConfigurationBuilder configurationBuilder)
            : base(configurationBuilder, "InteractDb")
        {
        }

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
            return GetCached("Top5Issues", () => { 
                using (var context = new InteractDbContext())
                {
                    return GetIssues(context).Take(5).ToList();
                }
            });
        }

        public Issue GetIssueById(int id)
        {
            return GetCached("Issue{0}".FormatString(id), () =>
            {
                using (var context = new InteractDbContext())
                {
                    return GetIssues(context).Single(issue => issue.Id == id);
                }
            });
        }


    }
}