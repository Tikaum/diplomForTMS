namespace FinalSurgeTests.Utils
{
    public class CsvDataOfAthlets
    {
        public static IEnumerable<TestCaseData> GetTestCases()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseDir, "Resources", "DataOfAthlets.csv");
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                string weight = parts[0];
                string height = parts[1];
                string age = parts[2];
                string runDistance = parts[3];
                string expectedTotalCalories = parts[4];
                yield return new TestCaseData(weight, height, age, runDistance, expectedTotalCalories)
                .SetName($"Указан_атлет_с_массой_{weight}_фунтов,_ростом_{height}_дюймов," +
                $"_возрастом_{age}_лет,_бегущий дистанцию_{runDistance}_миль.");
            }
        }
    }
}
