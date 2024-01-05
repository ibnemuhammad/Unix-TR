using TR.tests;

namespace TR;

public class MemoryUsageTest
{

    public void TestMemoryUsageFor3000IterationsOriginal() {
        string testContent = File.ReadAllText("test.txt");
        for (int i = 0; i < 3000; i++)
        {
            var trUtility = new TRUTility(testContent);

            _ = trUtility.ReplaceRangeriginalVersion("[:upper:]", "[:lower:]");
            //File.AppendAllText("result.txt", replaceResult);
        }
        
    }

    internal void TestMemoryUsageFor3000Iterations()
    {
        string testContent = File.ReadAllText("test.txt");
        for (int i = 0; i < 3000; i++)
        {
            var trUtility = new TRUTility(testContent);

            _ = trUtility.ReplaceRange("[:upper:]", "[:lower:]");
            //File.AppendAllText("result.txt", replaceResult);
        }
    }
}
