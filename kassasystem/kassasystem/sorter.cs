using System.Collections;
using System.Globalization;
using kassasystem;

/// <summary>
/// This class is an implementation of the 'IComparer' interface.
/// </summary>
public class ListViewColumnSorter : IComparer
{
    /// <summary>
    /// Specifies the column to be sorted
    /// </summary>
    private int ColumnToSort;

    /// <summary>
    /// Specifies the order in which to sort (i.e. 'Ascending').
    /// </summary>
    private SortOrder OrderOfSort;

    /// <summary>
    /// Case insensitive comparer object
    /// </summary>
    private CaseInsensitiveComparer ObjectCompare;

    /// <summary>
    /// Class constructor. Initializes various elements
    /// </summary>
    public ListViewColumnSorter()
    {
        // Initialize the column to '0'
        ColumnToSort = 0;

        // Initialize the sort order to 'none'
        OrderOfSort = SortOrder.None;

        // Initialize the CaseInsensitiveComparer object
        ObjectCompare = new CaseInsensitiveComparer();
    }

    /// <summary>
    /// This method is inherited from the IComparer interface. It compares the two objects passed using a case insensitive comparison.
    /// </summary>
    /// <param name="x">First object to be compared</param>
    /// <param name="y">Second object to be compared</param>
    /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
    public int Compare(object x, object y)
    {
        int compareResult;
        ListViewItem listViewX, listViewY;
        TypedListViewItem? typedListViewX, typedListViewY;

        // Cast the objects to be compared to ListViewItem objects
        listViewX = (ListViewItem)x;
        listViewY = (ListViewItem)y;
        typedListViewX = listViewX as TypedListViewItem;
        typedListViewY = listViewY as TypedListViewItem;

        if (typedListViewX != null && typedListViewY != null)
        {
            Type type = typedListViewX.TypeDictionary[typedListViewX.SubItems[ColumnToSort].Text];

            if (type != typedListViewY.TypeDictionary[typedListViewY.SubItems[ColumnToSort].Text])
                goto StringComparison;

            int returnValue = 0;
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Int64:
                    if (!Int64.TryParse(typedListViewX.SubItems[ColumnToSort].Text, out Int64 parsedIntX) ||
                        !Int64.TryParse(typedListViewY.SubItems[ColumnToSort].Text, out Int64 parsedIntY))
                        goto StringComparison;

                    if (parsedIntX < parsedIntY)
                        returnValue = -1;
                    else if (parsedIntX > parsedIntY)
                        returnValue = 1;

                    if (OrderOfSort == SortOrder.Descending)
                        return -returnValue;

                    return returnValue;

                case TypeCode.Decimal:
                    string x_text = typedListViewX.SubItems[ColumnToSort].Text.Replace('.', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    string y_text = typedListViewY.SubItems[ColumnToSort].Text.Replace('.', Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    if (!Decimal.TryParse(x_text, out decimal parsedDecX) ||
                        !Decimal.TryParse(y_text, out decimal parsedDecY))
                        goto StringComparison;

                    if (parsedDecX < parsedDecY)
                        returnValue = -1;
                    else if (parsedDecX > parsedDecY)
                        returnValue = 1;

                    if (OrderOfSort == SortOrder.Descending)
                        return -returnValue;

                    return returnValue;

                default: goto StringComparison;
            }
        }

StringComparison: // Label :P

        // Compare the two items
        compareResult = ObjectCompare.Compare(listViewX.SubItems[ColumnToSort].Text, listViewY.SubItems[ColumnToSort].Text);

        // Calculate correct return value based on object comparison
        if (OrderOfSort == SortOrder.Ascending)
        {
            // Ascending sort is selected, return normal result of compare operation
            return compareResult;
        }
        else if (OrderOfSort == SortOrder.Descending)
        {
            // Descending sort is selected, return negative result of compare operation
            return (-compareResult);
        }
        else
        {
            // Return '0' to indicate they are equal
            return 0;
        }
    }

    /// <summary>
    /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
    /// </summary>
    public int SortColumn
    {
        set
        {
            ColumnToSort = value;
        }
        get
        {
            return ColumnToSort;
        }
    }

    /// <summary>
    /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
    /// </summary>
    public SortOrder Order
    {
        set
        {
            OrderOfSort = value;
        }
        get
        {
            return OrderOfSort;
        }
    }

}
