using System.Diagnostics;
using GBX.NET;
using GBX.NET.Engines.Game;
using GBX.NET.LZO;


public (float, int) GetAverage(string path, bool ignoreIngame = true)
{
    var replay = GameBox.ParseNode<CGameCtnReplayRecord>(path);
    var ls = replay?.Ghosts?.FirstOrDefault()?.RecordData?.Samples;
    if (ls == null) throw new Exception("No samples found");

    var blocklist = new List<float>(){ -1, 0, 1};
    var actionKeys = new List<float>(){ };

    var matches = ls.GroupBy(x=> x.Steer).Where(x=> !blocklist.Any(c=> c == x.Key) );
    

}



var wa = Stopwatch.StartNew();
var ls = replay.Ghosts.FirstOrDefault().RecordData.Samples;

    foreach (var replayRecord in ls)
    {
        while (wa.ElapsedMilliseconds < replayRecord.Timestamp.Value.TotalMilliseconds)
        {
        }

        var index = ls.IndexOf(replayRecord);
    if (index > 2)
    {
        var lastItem = ls[index - 1];
        var lastLastItem = ls[index - 1];
        if (lastItem != null && lastLastItem != null)
        {
            if (lastLastItem.Steer == replayRecord.Steer && lastItem.Steer == replayRecord.Steer)
            {
                if (!(replayRecord.Steer == 1 || replayRecord.Steer == -1 || replayRecord.Steer == 0))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
            }
        }
    }
        
        Console.WriteLine($"[{wa.Elapsed.Minutes}:{wa.Elapsed.Seconds}:{wa.Elapsed.Milliseconds}] - {replayRecord.Steer.Value}");
        Console.ForegroundColor = ConsoleColor.White;

}


Console.ReadKey();