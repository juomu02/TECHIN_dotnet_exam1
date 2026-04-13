public class Exam
{

    static void Main()
    {
        // 1. Parašykite programą, kuri suranda temperatūrų anomaliją. Temperatūros anomalija
        // nustatoma tada, kai dienos temperatūra skiriasi 8 ar daugiau laipsnių nuo vidurkio.
        // Užpildykite masyvą 30 dienos temperatūrų (atsitiktiniai double skaičiai nuo -10 iki
        // 35°C). Atspausdinkite į ekraną pradini masyvą, suraskite visas dienas kai buvo
        // anomali temperatūra ir juos atspausdinkite į ekraną. Viso: 2 tšk.
        TemperatureAnomalies();

        // 2. Sugeneruokite 1000 elementų masyvą su atsitiktiniais reikšmėmis (reikšmės nuo 1 iki
        // 100). Sugrupuokite juos į grupes po 10 (1–10, 11–20, … 91–100) ir parodykite kiek
        // procentaliai kiekvienai grupei priklauso elementų (2 tšk). Pvz.:
        // 1-10 -&gt; 12%
        // 11-20 -&gt; 3%
        // ir .t.t
        // Viso: 2 tšk.
        NumberGroups();

    }
    public static void NumberGroups()
    {
        var numberAmount = 1000;
        var randomIntArray = NewRandomIntArray(numberAmount);
        var groupsOfInt = GroupIntegers(randomIntArray);
        var groupsByPercentage = CalculatePercentages(groupsOfInt, numberAmount);
        PrintNumberGroups("Skaičių grupės:", groupsByPercentage);
    }

    public static int[] NewRandomIntArray(int numberAmount)
    {
        var output = new int[numberAmount];
        for (int number = 0; number < numberAmount; number++)
        {
            Random randObj = new(number);
            output[number] = randObj.Next(0, 100);
        }
        return output;
    }
    public static Dictionary<string, int> GroupIntegers(int[] randomIntArray)
    {
        var groupDict = new Dictionary<string, int>{
            {"1-10", 0},
            {"11-20", 0},
            {"21-30", 0},
            {"31-40", 0},
            {"41-50", 0},
            {"51-60", 0},
            {"61-70", 0},
            {"71-80", 0},
            {"81-90", 0},
            {"91-100", 0}
        };

        for (int numberIndex = 0; numberIndex < randomIntArray.Length; numberIndex++)
        {
            switch (randomIntArray[numberIndex])
            {
                case <= 10:
                    groupDict["1-10"]++;
                    break;
                case > 10 and <= 20:
                    groupDict["11-20"]++;
                    break;
                case > 20 and <= 30:
                    groupDict["21-30"]++;
                    break;
                case > 30 and <= 40:
                    groupDict["31-40"]++;
                    break;
                case > 40 and <= 50:
                    groupDict["41-50"]++;
                    break;
                case > 50 and <= 60:
                    groupDict["51-60"]++;
                    break;
                case > 60 and <= 70:
                    groupDict["61-70"]++;
                    break;
                case > 70 and <= 80:
                    groupDict["71-80"]++;
                    break;
                case > 80 and <= 90:
                    groupDict["81-90"]++;
                    break;
                default:
                    groupDict["91-100"]++;
                    break;
            }
        }
        return groupDict;
    }
    public static Dictionary<string, string> CalculatePercentages(Dictionary<string, int> dicgroupsOfInt, int numberAmount)
    {
        var groupsByPercentage = new Dictionary<string, string> { };
        foreach (KeyValuePair<string, int> entry in dicgroupsOfInt)
        {
            groupsByPercentage.Add(entry.Key, $"{Math.Round((double)entry.Value / (double)numberAmount * 100.0, 1)}%");
        }
        return groupsByPercentage;
    }
    public static void PrintNumberGroups(string title, Dictionary<string, string> groupsOfInt)
    {
        Console.WriteLine(title);
        Console.WriteLine(string.Join($"{System.Environment.NewLine}", groupsOfInt));
    }
    public static void TemperatureAnomalies()
    {
        var tempArray = RandomTemperatures(30);
        Console.WriteLine($"Sugeneruotas temperatūrų masyvas: {string.Join(", ", tempArray)}");

        var tempAvg = FindAverageTemperature(tempArray);
        Console.WriteLine($"Vidutinė temperatūra yra { Math.Round(tempAvg, 2)} laipsnių(-is)");

        var tempAnomalies = FindTempAnomalies(tempArray, tempAvg);
        Console.WriteLine($"Anomalinės temperatūros: {string.Join(", ", tempAnomalies)}");
    }
    public static double[] RandomTemperatures(int numberAmount)
    {
        var output = new double[numberAmount];
        for (int number = 0; number < numberAmount; number++)
        {
            Random randObj = new(number);
            output[number] = randObj.Next(0, 45) - 10;
        }
        return output;
    }
    public static double FindAverageTemperature(double[] temperatureArray)
    {
        double output;
        double tempSum = 0;
        for (int tempIndex = 0; tempIndex < temperatureArray.Length; tempIndex++)
        {
            tempSum += (double)temperatureArray[tempIndex];
        }

        output = tempSum / (double)temperatureArray.Length;
        return output;
    }
    public static List<double> FindTempAnomalies(double[] tempArray, double tempAvg)
    {
        var output = new List<double> { };
        for (int tempIndex = 0; tempIndex < tempArray.Length; tempIndex++)
        {
            if (tempArray[tempIndex] <= (tempAvg - 8) || tempArray[tempIndex] >= (tempAvg + 8))
            {
                output.Add(tempArray[tempIndex]);
            }
        }

        return output;
    }
}