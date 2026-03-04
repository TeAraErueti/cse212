public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create a new array of type double with the given length.
        double[] result = new double[length];

        // Step 2: Loop from index 0 up to length - 1.
        for (int i = 0; i < length; i++)
        {
            // Step 3: For each index, calculate the multiple.
            // Since index starts at 0 but we want the first multiple, multiply number by (i + 1).
            result[i] = number * (i + 1);
        }

        // Step 4: Return the completed array.
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Determine how many elements are in the list.
        int count = data.Count;

        // Step 2: Find the starting index of the portion that needs to move to the front.
        // This will be count - amount.
        int startIndex = count - amount;

        // Step 3: Use GetRange to copy the last 'amount' elements.
        List<int> temp = data.GetRange(startIndex, amount);

        // Step 4: Remove those elements from the end of the original list.
        data.RemoveRange(startIndex, amount);

        // Step 5: Insert the saved elements at the beginning of the list.
        data.InsertRange(0, temp);

        // Step 6: The list should now be rotated to the right.
    }
}
