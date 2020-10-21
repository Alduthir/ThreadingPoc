using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ThreadingPoc
{
    class Program
    {
        public static Queue<int> numberQueue = new Queue<int>();
        public static int numberOfConsumers = 3;
        public static int[] sums = new int[numberOfConsumers];
        public static bool producerIsRunning = false;

        public static void Main(string[] args)
        {
            Thread producingThread = new Thread(NumberProducer.ProduceNumbers);
            producingThread.Start();

            Thread[] consumerArray = new Thread[numberOfConsumers];
            for(int i  = 0; i < numberOfConsumers; i++)
            {
                NumberConsumer consumer = new NumberConsumer(i);
                Thread consumingThread = new Thread(new ThreadStart(consumer.consumeNumbers));
                consumerArray[i] = consumingThread;
                consumingThread.Start();
            }

            for(int i = 0; i < numberOfConsumers; i++)
            {
                consumerArray[i].Join();
            }

            int total = sums.Sum();
            Console.WriteLine("All threads have concluded, reaching a total sum of " + total + ".");
           
        }
    }
}
