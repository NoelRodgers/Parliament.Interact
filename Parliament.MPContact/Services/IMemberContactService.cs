using Parliament.MPContact.Services;

namespace Parliament.MPContact
{
    public interface IMemberContactService
    {
        IMember GetMember(string postcode);
    }
}
