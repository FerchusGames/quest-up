using System;
using System.Threading.Tasks;

public static class Timer
{
    public static async void Trigger(int time, Action a)
    {
        await Task.Delay(time);
        a?.Invoke();
    }
}
