var topFloor = 100;

//At lease we can start at 1/3 of total floors, total steps will not be more than 1/3
var best = (int)Math.Ceiling(topFloor / 3m);

var (steps, tested) = HeightTest(0, topFloor, new int[0], 0);

Console.WriteLine($"At least {steps} steps needed:");
Console.Write("[");
foreach (var i in tested)
{
    Console.Write(i);
    Console.Write(' ');
}
Console.Write("]");


(int, int[]) HeightTest(int Safe, int TopFloor, int[] Tested, int Testing)
{
    //already worse than best result so fa, give up search
    if (Tested.Length > best)
        return (Tested.Length, new int[] { });

    //only displays the status for at most search depth 2,otherwise too much time spends on display
    if (Tested.Length <= 1)
    {
        foreach (var item in Tested)
        {
            Console.Write(item);
            Console.Write(' ');
        }
        Console.WriteLine($"{Testing}");
    }

    if (Testing == 0)
    {
        if (Safe == TopFloor)   //we are at the top floor, search finished
            return (0, Tested);

        var (levelBestSteps, levelTested) = (int.MaxValue, new int[0]);

        //start from 1/3 of remaining floors
        for (var i = (int)Math.Ceiling((TopFloor - Safe) / 3.0m) + Safe; i > Safe; i--)
        {
            var (newSteps, newTested) = HeightTest(Safe, TopFloor, Tested, i);

            if (newSteps < levelBestSteps)   //better result found
            {
                levelBestSteps = newSteps;
                levelTested = newTested;

                if (levelBestSteps < best && Tested.Length == 0)  //top level better result, set as the new search depth limit
                {
                    best = levelBestSteps;
                    Console.WriteLine($"new best found: {best}");
                }
            }
            else  //getting worse result, stop searching
                break;
        }
        return (levelBestSteps, levelTested);
    }
    else
    {
        var NewTested = new int[Tested.Length + 1];
        Tested.CopyTo(NewTested, 0);
        NewTested[Tested.Length] = Testing;

        var (rightSteps, rightTested) = HeightTest(Testing, TopFloor, NewTested, 0);
        var leftSteps = NewTested.Length + Testing - Safe - 1;

        var steps = Math.Max(leftSteps, rightSteps);

        return (steps, rightTested);
    }

}

