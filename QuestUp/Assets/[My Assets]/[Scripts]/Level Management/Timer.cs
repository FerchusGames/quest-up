using System;
using System.Threading.Tasks;

namespace QuestUp
{
    public static class Timer
    {
        public static async void OnTimerEnd(float secondsDelay, Action a)
        {
            int millisecondsDelay = (int)secondsDelay * 1000; // Task.Delay takes milliseconds, so we convert the value
            await Task.Delay(millisecondsDelay);
            a?.Invoke();
        }
    }
}
