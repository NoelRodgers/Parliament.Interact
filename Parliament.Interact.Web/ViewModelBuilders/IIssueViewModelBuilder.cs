using System.Collections.Generic;
using Parliament.Interact.Core.Domain;
using Parliament.Interact.Web.Models;

namespace Parliament.Interact.Web.ViewModelBuilders
{
    public interface IIssueViewModelBuilder
    {
        IList<IssueViewModel> Build();
        IssueViewModel Build(int id);
    }
}