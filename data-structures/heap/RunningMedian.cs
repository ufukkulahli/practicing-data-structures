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

      var currentMedian = (double)numbers[0];
      results.Add(currentMedian);
      maxHeap.Add(numbers[0]);

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
          else
          {
            minHeap.Add(currentNumber);
          }
            maxHeap.Sort();
            maxHeap.Reverse();
            minHeap.Sort();
            currentMedian = CalculateMedian(maxHeap, minHeap);
            results.Add(currentMedian);
            continue;
        }

        if(maxHeap.Count == minHeap.Count)
        {
          if(currentNumber < currentMedian)
          {
            maxHeap.Add(currentNumber);
            maxHeap.Sort();
            maxHeap.Reverse();
            currentMedian = (double)maxHeap[0];
            results.Add(currentMedian);
            continue;
          }
            minHeap.Add(currentNumber);
            minHeap.Sort();
            currentMedian = (double)minHeap[0];
            results.Add(currentMedian);
            continue;
        }

        if(maxHeap.Count < minHeap.Count)
        {
          if(currentNumber > currentMedian)
          {
            minHeap.Sort();
            maxHeap.Add(minHeap[0]);
            minHeap.RemoveAt(0);
            minHeap.Add(currentNumber);
          }
          else
          {
            maxHeap.Add(currentNumber);
          }
            maxHeap.Sort();
            maxHeap.Reverse();
            minHeap.Sort();
            currentMedian = CalculateMedian(maxHeap, minHeap);
            results.Add(currentMedian);
            continue;
        }

      }

      return results;
    }

    public double CalculateMedian(List<int> maxHeap, List<int> minHeap)
    {
      return
        (double)
          (maxHeap[0] + minHeap[0]) / 2;
    }

  }
}