using System.Collections.Generic;
using System.Linq;
using practicing_data_structures.data_structures.heap;
using Xunit;

namespace practicing_data_structures.tests.heap
{
  public class RunningMedianTests
  {

    [Fact]
    public void WhenMaxHeapCountMoreThanMinHeapCount_And_CurrentNumberIsSamllerThanCurrentMedian()
    {
      // Arrange
      var numbers = new int[]{ 2, 1 };
      var median = new RunningMedian();

      // Act
      median.Find(numbers);

      // Assert
      Assert.Equal(2, median.minHeap[0]);
      Assert.Equal(1, median.maxHeap[0]);
    }

    [Fact]
    public void WhenMaxHeapCountMoreThanMinHeapCount_And_CurrentNumberIsBiggerThanCurrentMedian()
    {
      // Arrange
      var numbers = new int[]{ 1, 2 };
      var median = new RunningMedian();

      // Act
      median.Find(numbers);

      // Assert
      Assert.Equal(2, median.minHeap[0]);
      Assert.Equal(1, median.maxHeap[0]);
    }

    [Fact]
    public void WhenMaxHeapCountEqualToMinHeapCount_And_CurrentNumberIsSmallerThanCurrentMedian()
    {
      // Arrange
      var numbers = new int[]{ 10, 12, 3 };
      var median = new RunningMedian();

      // Act
      median.Find(numbers);

      // Assert
      Assert.Equal(10, median.maxHeap[0]);
      Assert.Equal(3, median.maxHeap[1]);
      Assert.Equal(12, median.minHeap[0]);
    }

    [Fact]
    public void WhenMaxHeapCountEqualToMinHeapCount_And_CurrentNumberIsBiggerThanCurrentMedian()
    {
      // Arrange
      var numbers = new int[]{ 1, 2, 3 };
      var median = new RunningMedian();

      // Act
      median.Find(numbers);

      // Assert
      Assert.Equal(1, median.maxHeap[0]);
      Assert.Equal(2, median.minHeap[0]);
      Assert.Equal(3, median.minHeap[1]);
    }

    [Fact]
    public void WhenMaxHeapCountLessThanMinHeapCount_And_CurrentNumberIsBiggerThanCurrentMedian()
    {
      // Arrange
      var numbers = new int[]{ 1, 2, 3, 4 };
      var median = new RunningMedian();

      // Act
      median.Find(numbers);

      // Assert
      Assert.Equal(2, median.maxHeap[0]);
      Assert.Equal(1, median.maxHeap[1]);
      Assert.Equal(3, median.minHeap[0]);
      Assert.Equal(4, median.minHeap[1]);
    }

    [Fact]
    public void WhenMaxHeapCountLessThanMinHeapCount_And_CurrentNumberIsSmallerThanCurrentMedian()
    {
      // Arrange
      var numbers = new int[]{ 10, 11, 12, 4 };
      var median = new RunningMedian();

      // Act
      median.Find(numbers);

      // Assert
      Assert.Equal(10, median.maxHeap[0]);
      Assert.Equal(4,  median.maxHeap[1]);
      Assert.Equal(11, median.minHeap[0]);
      Assert.Equal(12, median.minHeap[1]);
    }

    [Fact]
    public void CalculateMedian()
    {
      // Arrange
      var maxHeap = new List<int>{4};
      var minHeap = new List<int>{6};

      // Act
      var median = new RunningMedian().CalculateMedian(maxHeap, minHeap);

      // Assert
      Assert.Equal(5, median);
    }

    [Fact]
    public void FindMedian()
    {
      // Arrange
      var numbers = new int[]{ 12, 4, 5, 3, 8, 7 };
      var median = new RunningMedian();

      // Act
      var results = median.Find(numbers).ToList();

      // Assert
      Assert.Equal(12.0 , results[0]);
      Assert.Equal(8.0  , results[1]);
      Assert.Equal(5.0  , results[2]);
      Assert.Equal(4.5  , results[3]);
      Assert.Equal(5.0  , results[4]);
      Assert.Equal(6.0  , results[5]);
    }

    [Fact]
    public void FindMedian2()
    {
      // Arrange
      var numbers = new int[]{ 7, 3, 5, 2 };
      var median = new RunningMedian();

      // Act
      var results = median.Find(numbers).ToList();

      // Assert
      Assert.Equal(7  , results[0]);
      Assert.Equal(5  , results[1]);
      Assert.Equal(5  , results[2]);
      Assert.Equal(4  , results[3]);
    }

    [Fact]
    public void FindMedian3()
    {
      // Arrange
      var numbers = new int[]{ 5, 15, 10, 20, 3 };
      var median = new RunningMedian();

      // Act
      var results = median.Find(numbers).ToList();

      // Assert
      Assert.Equal(5    , results[0]);
      Assert.Equal(10   , results[1]);
      Assert.Equal(10   , results[2]);
      Assert.Equal(12.5 , results[3]);
      Assert.Equal(10   , results[4]);
    }

    [Fact]
    public void FindMedian4()
    {
      // Arrange
      var numbers = new int[]{ 10, 20, 30 };
      var median = new RunningMedian();

      // Act
      var results = median.Find(numbers).ToList();

      // Assert
      Assert.Equal(10   , results[0]);
      Assert.Equal(15   , results[1]);
      Assert.Equal(20   , results[2]);
    }

    [Fact]
    public void FindMedian5()
    {
      // Arrange
      var numbers = new int[]{ 5, 8, 1, 4, 2, 8, 5, 5 };
      var median = new RunningMedian();

      // Act
      var results = median.Find(numbers).ToList();

      // Assert
      Assert.Equal(5    , results[0]);
      Assert.Equal(6.5  , results[1]);
      Assert.Equal(5    , results[2]);
      Assert.Equal(4.5  , results[3]);
      Assert.Equal(4    , results[4]);
      Assert.Equal(4.5  , results[5]);
      Assert.Equal(5    , results[6]);
      Assert.Equal(5    , results[7]);
    }

    [Fact]
    public void FindMedian6()
    {
      // Arrange
      var numbers = new int[]{ 32, 22, 55, 9, 35, 36 };
      var median = new RunningMedian();

      // Act
      var results = median.Find(numbers).ToList();

      // Assert
      Assert.Equal(32 , results[0]);
      Assert.Equal(27 , results[1]);
      Assert.Equal(32 , results[2]);
      Assert.Equal(27 , results[3]);
      Assert.Equal(32 , results[4]);
      Assert.Equal(33.5 , results[5]);
    }

    [Fact]
    public void FindMedian7()
    {
      // Arrange
      var numbers = new int[]{ 3, 10, 5, 20, 7, 6 };
      var median = new RunningMedian();

      // Act
      var results = median.Find(numbers).ToList();

      // Assert
      Assert.Equal(3   , results[0]);
      Assert.Equal(6.5 , results[1]);
      Assert.Equal(5   , results[2]);
      Assert.Equal(7.5 , results[3]);
      Assert.Equal(7   , results[4]);
      Assert.Equal(6.5 , results[5]);
    }

    [Fact]
    public void FindMedian8()
    {
      // Arrange
      var numbers = new int[]{ 20, 1, 11, 19, 21, 17, 6 };
      var median = new RunningMedian();

      // Act
      var results = median.Find(numbers).ToList();

      // Assert
      Assert.Equal(20   , results[0]);
      Assert.Equal(10.5 , results[1]);
      Assert.Equal(11   , results[2]);
      Assert.Equal(15   , results[3]);
      Assert.Equal(19   , results[4]);
      Assert.Equal(18   , results[5]);
      Assert.Equal(17   , results[6]);
    }

    [Fact]
    public void FindMedian9()
    {
      // Arrange
      var numbers = new int[]{ 1,2,3,4,5,6,7,8,9,10 };
      var median = new RunningMedian();

      // Act
      var results = median.Find(numbers).ToList();

      // Assert
      Assert.Equal(1   , results[0]);
      Assert.Equal(1.5 , results[1]);
      Assert.Equal(2   , results[2]);
      Assert.Equal(2.5 , results[3]);
      Assert.Equal(3   , results[4]);
      Assert.Equal(3.5 , results[5]);
      Assert.Equal(4   , results[6]);
      Assert.Equal(4.5 , results[7]);
      Assert.Equal(5   , results[8]);
      Assert.Equal(5.5 , results[9]);
    }

    [Fact]
    public void FindMedian10()
    {
      // Arrange
      var numbers = new int[]{ 10,9,8,7,6,5,4,3,2,1 };
      var median = new RunningMedian();

      // Act
      var results = median.Find(numbers).ToList();

      // Assert
      Assert.Equal(10  , results[0]);
      Assert.Equal(9.5 , results[1]);
      Assert.Equal(9   , results[2]);
      Assert.Equal(8.5 , results[3]);
      Assert.Equal(8   , results[4]);
      Assert.Equal(7.5 , results[5]);
      Assert.Equal(7   , results[6]);
      Assert.Equal(6.5 , results[7]);
      Assert.Equal(6   , results[8]);
      Assert.Equal(5.5 , results[9]);
    }

  }
}