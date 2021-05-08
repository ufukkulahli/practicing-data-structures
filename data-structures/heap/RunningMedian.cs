using System.Collections.Generic;

namespace practicing_data_structures.data_structures.heap
{
  public sealed class RunningMedian
  {
    public readonly List<int> maxHeap = new List<int>();
    public readonly List<int> minHeap = new List<int>();

    public IEnumerable<double> Find(int[] numbers)
    {
      var results = new List<double>();
      
      var currentMedian = numbers[0];
      maxHeap.Add(currentMedian);

      for(var i=1; i<numbers.Length; i++)
      {
        var currentNumber = numbers[i];

        if(maxHeap.Count > minHeap.Count)
        {
          if(currentNumber < currentMedian)
          {
            maxHeap.Sort();
            maxHeap.Reverse();
            minHeap.Add(maxHeap[0]);
            maxHeap.RemoveAt(0);
            maxHeap.Add(currentNumber);
          }
        }
      }

      return results;
    }
  }
}