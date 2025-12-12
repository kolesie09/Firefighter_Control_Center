using System.Collections.Generic;

public class CustomHashSet : HashSet<string>
{
    private HashSet<string> ignoredValues;

    public CustomHashSet()
    {
        ignoredValues = new HashSet<string> { "0" };
    }

    public new bool Add(string item)
    {
        if (ignoredValues.Contains(item))
        {
            return false; // Nie dodawaj elementu, jeśli jest w zbiorze ignorowanych wartości
        }

        return base.Add(item);
    }
}
