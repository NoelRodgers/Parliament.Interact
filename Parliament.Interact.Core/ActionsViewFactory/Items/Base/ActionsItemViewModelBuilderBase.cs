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

        protected IActionContent GetActionContent(IssueAction issueAction, string id)
        {
            return (IActionContent)issueAction.IssueActionContents.SingleOrDefault(x => x.Key == id) ??
                           issueAction.ActionItem.ActionContents.Single(x => x.Key == id);
        }

        protected void Build(IssueAction issueAction)
        {
            Title = GetActionContent(issueAction, "Title").Content;
            Eta = GetActionContent(issueAction, "Eta").Content;
            BasicContent = GetActionContent(issueAction, "BasicContent").Content;
        }
    }
}