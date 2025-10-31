namespace MergeArrays;

public class Program
{
    public static void Main(string[] args)
    {
        
    }

    // TODO 
    public static int[] MergeSortedArrays(int[] array1, int[] array2)
    {
        int n1 = array1.Length;
        int n2 = array2.Length;
        int[] merged = new int[n1 + n2];

        int i = 0, j = 0, k = 0;

        while (i < n1 && j < n2)
        {
            if (array1[i] <= array2[j])
            {
                merged[k++] = array1[i++];
            }
            else
            {
                merged[k++] = array2[j++];
            }
        }
        while (i < n1)
        {
            merged[k++] = array1[i++];
        }
        while (j < n2)
        {
            merged[k++] = array2[j++];
        }
        return merged;
    }

    // TODO 
    private static bool IsSorted(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < array[i - 1])
                return false;
        }
        return true;

    }
}

