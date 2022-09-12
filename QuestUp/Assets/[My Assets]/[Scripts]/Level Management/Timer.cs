using System;
using System.Threading.Tasks;

public static class Timer
{
    public static async void OnTimerEnd(float _secondsDelay, Action a)
    {
        int _millisecondsDelay = (int)_secondsDelay * 1000; // Task.Delay takes milliseconds, so we convert the value
        await Task.Delay(_millisecondsDelay);
        a?.Invoke();
    }
}
