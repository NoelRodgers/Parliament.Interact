using System.Collections.Generic;
using Parliament.Interact.Core.Domain;

namespace Parliament.Interact.Core.Services
{
    public interface IIssueService
    {
        List<Issue> GetTopFiveIssues();

        Issue GetIssueById(int id);
    }
}