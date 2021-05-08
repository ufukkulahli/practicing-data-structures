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

  }
}