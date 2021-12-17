public class Program
{
    static Dictionary<int, (int, int[])> results = new Dictionary<int, (int, int[])>();

    public static void Main()
    {
        var topFloor = 100;

        Display(topFloor, HeightTest(topFloor));
    }

    static (int, int[]) HeightTest(int NumFloors)
    {
        if (results.ContainsKey(NumFloors))
            return results[NumFloors];

        var (levelBestSteps, levelTested) = (int.MaxValue, new int[0]);
        if (NumFloors == 0)
            (levelBestSteps, levelTested) = (0, new int[0]);
        else
        {
            for (var i = 1; i <= NumFloors; i++)
            {
                var (newSteps, newTested) = HeightTest(NumFloors, i);
                if (newSteps < levelBestSteps)   //better result found
                {
                    levelBestSteps = newSteps;
                    levelTested = newTested;
                }
            }
        }
        var result = (levelBestSteps, levelTested);
        results[NumFloors] = result;
        Display(NumFloors, result);
        return result;
    }

    static (int, int[]) HeightTest(int NumFloors, int Testing)
    {
        var (rightSteps, rightTested) = HeightTest(NumFloors - Testing);

        var leftSteps = Testing - 1;

        var steps = Math.Max(leftSteps, rightSteps) + 1;

        var NewTested = new int[rightTested.Length + 1];
        NewTested[0] = Testing;
        rightTested.CopyTo(NewTested, 1);

        return (steps, NewTested);
    }

    static void Display(int numFloors, (int, int[]) result)
    {
        Console.WriteLine($"Floors:{numFloors} Total Steps:{result.Item1}");
        Console.WriteLine($"[{string.Join(',', result.Item2)}]\r\n");
    }
}



