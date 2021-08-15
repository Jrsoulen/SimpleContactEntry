using SimpleContactEntry.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleContactEntry
{
    public static class CallListMethods
    {
        public static List<CallContact> CreateCallList(IEnumerable<Contact> contactList)
        {
            List<CallContact> callContacts = new List<CallContact>();

            foreach (var contact in contactList)
            {
                if (contact.Phone.Any(p => p.Type.ToLower() == "home"))
                {
                    var callContact = new CallContact()
                    {
                        Name = contact.Name,
                        Phone = contact.Phone.Where(p => p.Type.ToLower() == "home").First().Number
                    };
                    callContacts.Add(callContact);
                }
            }
            return callContacts.OrderBy(c => c.Name.Last).ThenBy(c => c.Name.First).ToList();
        }
    }
}
