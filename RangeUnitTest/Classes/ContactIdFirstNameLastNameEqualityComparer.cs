namespace RangeUnitTest.Classes;

public class ContactIdFirstNameLastNameEqualityComparer : IEqualityComparer<Contacts>
{
    public bool Equals(Contacts x, Contacts y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.ContactId == y.ContactId && x.FirstName == y.FirstName && x.LastName == y.LastName;
    }

    public int GetHashCode(Contacts obj)
    {
        return HashCode.Combine(obj.ContactId, obj.FirstName, obj.LastName);
    }
}