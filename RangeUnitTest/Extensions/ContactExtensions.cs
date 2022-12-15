using RangeUnitTest.Classes;

namespace RangeUnitTest.Extensions;

public static class ContactExtensions
{
    /// <summary>
    /// Get Indices for between two contacts.
    /// </summary>
    /// <param name="sender">List of <seealso cref="Contacts"/></param>
    /// <param name="firstContact"><seealso cref="ContactName"/></param>
    /// <param name="lastContact"><seealso cref="ContactName"/></param>
    /// <returns>Start contact index, last contact index with ^ (hat)</returns>
    public static (Index startIndex, Index endIndex) BetweenContacts(this List<Contacts> sender, ContactName firstContact, ContactName lastContact)
    {
        return
        (
            sender.FirstOrDefault(contact => contact.FirstName ==
                firstContact.FirstName && contact.LastName == firstContact.LastName).StartIndex,

            sender.FirstOrDefault(contact => contact.FirstName ==
                lastContact.FirstName && contact.LastName == lastContact.LastName).EndIndex

        );
    }
    public static Range BetweenContacts1(this List<Contacts> sender, ContactName firstContact, ContactName lastContact)
    {
        var startIndex = sender.FirstOrDefault(contact => contact.FirstName == firstContact.FirstName && contact.LastName == firstContact.LastName).StartIndex;
        var endIndex = sender.FirstOrDefault(contact => contact.FirstName == lastContact.FirstName && contact.LastName == lastContact.LastName).EndIndex;
        return startIndex..endIndex;

    }
    /// <summary>
    /// Set indices for each contact
    /// </summary>
    /// <param name="contactsArray"><see cref="Contacts"/> array</param>
    /// <returns>start and end indices set for entire array</returns>
    public static List<Contacts> ContactsListIndices(this Contacts[] contactsArray)
    {
        List<int> rangeReverse = Enumerable.Range(0, contactsArray.Length).Reverse().ToList();

        List<Contacts> contacts = contactsArray.Select(
            (contact, index) => new Contacts()
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                StartIndex = new Index(index),
                EndIndex = new Index(rangeReverse[index], true)
            }).ToList();

        return contacts;

    }
}