using System.Linq;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Core.Domain;

namespace Parliament.Interact.Core.ActionsViewFactory.Items.Base
{
    public abstract class ActionsItemViewModelBuilderBase 
    {
        public abstract ActionViewName ActionName { get; }
        public virtual string Title { get; protected set; }
        public virtual string Eta { get; protected set; }
        public virtual string BasicContent { get; protected set; }

        protected IActionContent GetActionContent(Issue issue, string id)
        {
            var issueAction = issue.IssueActions.Single(x => x.ActionItem.ViewName == ActionName);
            return (IActionContent)issueAction.IssueActionContents.SingleOrDefault(x => x.Key == id) ??
                           issueAction.ActionItem.ActionContents.Single(x => x.Key == id);
        }

        protected void Build(Issue issue )
        {
            Title = GetActionContent(issue, "Title").Content;
            Eta = GetActionContent(issue, "Eta").Content;
            BasicContent = GetActionContent(issue, "BasicContent").Content;
        }
    }
}