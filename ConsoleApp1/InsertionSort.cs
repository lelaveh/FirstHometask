namespace ConsoleApp1
{
    public class InsertionSort
    {
        public static void insertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int current = array[i];
                int j = i;
                while (j > 0 && current < array[j - 1])
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = current;
            }
        }
    }
}