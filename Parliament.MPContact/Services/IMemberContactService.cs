using Parliament.MPContact.Contracts;
using Parliament.MPContact.Services;

namespace Parliament.MPContact
{
    public interface IMemberContactService
    {
        MemberContract GetMember(string postcode);

        string BuildLink(MemberContract data);
    }
}
