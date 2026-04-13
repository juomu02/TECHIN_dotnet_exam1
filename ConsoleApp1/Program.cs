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
        // NumberGroups();

    }
    // public static void NumberGroups(){
    //     var randomIntArray = NewRandomIntArray(100);
    // }

    // public static int[] NewRandomIntArray(int numberAmount)
    // {

    // }

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