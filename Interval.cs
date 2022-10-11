using System.Timers;
using Timer = System.Timers.Timer;

namespace Utilities;

public class Interval
{
	private readonly Timer timer;

	private Interval(int interval)
	{
		timer = new(interval);
	}

	public static Interval Start(Action f1, int interval)
	{
		Interval i = new(interval);

		i.timer.Elapsed += (_, _) => f1();
		i.timer.AutoReset = true;
		i.timer.Enabled = true;

		return i;
	}

	public static void Stop(Interval interval)
	{
		if(interval?.timer is null)
		{
			return;
		}
		
		interval.timer.Enabled = false;
	}

	public static bool IsRunning(Interval interval) => interval?.timer?.Enabled ?? false;
}