using System.Linq;
using System.Web.UI.WebControls;
using Parliament.Interact.Core.ActionsViewFactory.Enum;
using Parliament.Interact.Core.Domain;

namespace Parliament.Interact.Web.ViewModelBuilders.Base
{
    public abstract class ActionsItemViewModelBuilderBase
    {
        public abstract ActionViewName ActionView { get; }
        public virtual string Title { get; protected set; }
        public virtual string Eta { get; protected set; }
        public virtual string BasicContent { get; protected set; }

        protected void Build(Issue issue )
        {
            var issueAction = issue.IssueActions.Single(x => x.ActionItem.ViewName == ActionView);
            var eta = (IActionContent)issueAction.IssueActionContents.SingleOrDefault(x => x.Key == "Eta") ??
                           issueAction.ActionItem.ActionContents.Single(x => x.Key == "Eta");
            var basicContent = (IActionContent)issueAction.IssueActionContents.SingleOrDefault(x => x.Key == "BasicContent") ??
                                      issueAction.ActionItem.ActionContents.Single(x => x.Key == "BasicContent");
            var title = (IActionContent)issueAction.IssueActionContents.SingleOrDefault(x => x.Key == "Title") ??
                           issueAction.ActionItem.ActionContents.Single(x => x.Key == "Title");
        }
    }
}