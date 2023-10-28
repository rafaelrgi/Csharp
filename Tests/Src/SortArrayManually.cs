namespace SortArrayManually;

/*
Sort an array of integers manually.
*/

public class Test
{
  public static int[] Run(int[] array)
  {
    int[] numbers = new int[array.Length];
    array.CopyTo(numbers, 0);

    if (numbers.Length < 2)
      return numbers;

    int pivot = numbers.Length - 1;
    Sort(numbers, pivot);
    //The biggest one ends in the beggining...
    for (int i = 1; i < numbers.Length; i++)
      Swap(numbers, i - 1, i);

    return numbers;
  }


  static void Sort(int[] array, int pivot)
  {
    if (pivot < 0)
      return;

    for (int i = 0; i < array.Length; i++)
    {
      if (array[i] > array[pivot])
        Swap(array, i, pivot);
    }

    Sort(array, pivot - 1);
  }

  static void Swap(int[] array, int index1, int index2)
  {
    (array[index2], array[index1]) = (array[index1], array[index2]);
  }

}