using System.Xml.Serialization;
using Parliament.MPContact.Services;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Parliament.MPContact.Contracts
{
    [XmlRoot("Members")]
    public class MemberContract
    {
            [XmlElement("Member")]
            public List<Member> Members { get; set; }

    }

    [XmlRoot("Member")]
    public class Member
    {
        [XmlAttribute("Member_Id")]
        public string Id { get; set; }

        [XmlElement("DisplayAs")]
        public string DisplayName { get; set; }
    }


}