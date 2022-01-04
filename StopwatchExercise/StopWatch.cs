using System;

namespace StopwatchExercise
{
    public class StopWatch
    {
        public enum State { NotStarted, Running, Paused}
        public DateTime StartTime { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public DateTime PausedTime { get; set; }

        public State currentState = State.NotStarted;

        
        public StopWatch()
        {
            
        }
        


        public void Start()
        {
            Console.Clear();
            Console.WriteLine("Please press 'start', 'pause', 'unpause', 'stop' or 'end'\n");
            StartTime = DateTime.Now;
            Console.WriteLine("StopWatch start time: 00.00.00" + "\n");
            currentState = State.Running;

        }
        public void Pause()
        {
            PausedTime = DateTime.Now;
            ElapsedTime += PausedTime - StartTime;
            Console.WriteLine($"\nElapsed Time: {ElapsedTime}\n");
            currentState = State.Paused;
        }
        public void Unpause()
        {
            StartTime = DateTime.Now;
            Console.WriteLine($"\nElapsed Time: {ElapsedTime}\n");
            currentState = State.Running;


        }
        public void Stop()
        {
            if (currentState != State.Paused)
            {
                ElapsedTime += DateTime.Now - StartTime;
            }

            Console.WriteLine($"\nStop Time = {ElapsedTime}.\n");
            ElapsedTime = new TimeSpan();

            currentState = State.NotStarted;

        }
        public void Run()
        {
            string command;

            Console.WriteLine("Please press 'start', 'pause', 'unpause', 'stop' or 'end'\n");

            do
            {
                
                command = Console.ReadLine();

                switch (command)
                {
                    case "start":
                        if (currentState == StopWatch.State.NotStarted)
                            Start();
                        else
                            Console.WriteLine("StopWatch has already started punk..");
                        break;
                    case "pause":
                        if (currentState == StopWatch.State.Running)
                            Pause();
                        else
                            Console.WriteLine("StopWatch isn't running.");
                        break;
                    case "unpause":
                        if (currentState == StopWatch.State.Paused)
                            Unpause();
                        else
                            Console.WriteLine("StopWatch isn't currently paused.");
                        break;
                    case "stop":
                        if (currentState == StopWatch.State.Running || currentState == StopWatch.State.Paused)
                            Stop();
                        else
                            Console.WriteLine("Cannot stop an already stopped stopwatch..");
                        break;
                    case "end":
                        break;
                }
            } while (command != "end");

        }
    }
}
