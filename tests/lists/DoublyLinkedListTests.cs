using System;
using Xunit;
using practicing_data_structures.data_structures.lists.doubly;
using System.IO;
using System.Reflection;

namespace practicing_data_structures.data_structures.lists
{
  public sealed class DoublyLinkedListTests
  {
    [Fact]
    public void Test()
    {
      
string solutionPath = Directory.GetCurrentDirectory();
            
            

            // Determine the default location for the server side config.json file.
            // The user may override this with a command line option if they want.
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string configLocation = Path.Combine(solutionPath, "omnisharp.json");
            if (!File.Exists(configLocation))
            {
                configLocation = Path.Combine(executableLocation, "config.json");
            }

      var words = new DoublyLinkedList<string>();

      Assert.Throws<NotImplementedException>(() => words.Append("hello"));

      words.Clear();
      Assert.Equal(0, words.Count);
      Assert.True(words.IsEmpty());
      Assert.Throws<Exception>(() => words.First);
      Assert.Throws<Exception>(() => words.Last);
    }
  }
}
