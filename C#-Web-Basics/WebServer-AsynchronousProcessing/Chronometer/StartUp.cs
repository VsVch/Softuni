using MyChronometer;

IChronometer chronometer = new Chronometer();

string line;

while ((line = Console.ReadLine()) != "exit".ToLower())
{
    if (line == "start".ToLower())
    {
        Task.Run(() =>
        {
            chronometer.Start();
        });
    }
    else if (line == "stop".ToLower())
    {
        chronometer.Stop();
    }
    else if (line == "lap".ToLower())
    {
        Console.WriteLine(chronometer.Lap());
    }
    else if (line == "laps".ToLower())
    {
        if (chronometer.Laps.Count == 0)
        {
            Console.WriteLine("Laps: no laps");
            continue;
        }
        Console.WriteLine("Laps: ");

        for (int i = 0; i < chronometer.Laps.Count; i++)
        {
            Console.WriteLine($"{i}, {chronometer.Laps[i]}");
        }
    }
    else if (line == "reset".ToLower())
    { 
        chronometer.Reset();
    }
    else if (line == "time".ToLower())
    {
        Console.WriteLine(chronometer.GetTime);
    }    
}