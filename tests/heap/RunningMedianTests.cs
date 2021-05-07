using practicing_data_structures.data_structures.heap;
using Xunit;

namespace practicing_data_structures.tests.heap
{
  public class RunningMedianTests
  {
    [Fact]
    public void Test()
    {
      Assert.Throws<System.NotImplementedException>( () => new RunningMedian().Find(null) );
    }
  }
}