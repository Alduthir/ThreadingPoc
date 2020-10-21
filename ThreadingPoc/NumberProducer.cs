using System;
using System.Threading;

namespace ThreadingPoc
{
    class NumberProducer
    {
        private static Random rand = new Random();

        public static void ProduceNumbers()
        {
            Program.producerIsRunning = true;

            for(int i = 0; i < 10; i++)
            {
                int newNumber = rand.Next(10);
                Console.WriteLine("Producing thread has produced the number " + newNumber + ".");
                Program.numberQueue.Enqueue(newNumber);
                Thread.Sleep(1000);
            }

            Program.producerIsRunning = false;
        }
    }
}
