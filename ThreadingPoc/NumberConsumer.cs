using System;
using System.Collections.Generic;
using System.Linq;

namespace ThreadingPoc
{
    class NumberConsumer 
    {
        private List<int> numberCollection = new List<int>();
        private int threadNumber;

        public NumberConsumer(int threadNumber)
        {
            this.threadNumber = threadNumber;
        }
        
        public void consumeNumbers()
        {
            while(Program.producerIsRunning || Program.numberQueue.Count > 0)
            {
                int myNumber = -1;
                lock (Program.numberQueue)
                {
                    if (Program.numberQueue.Count > 0)
                    {
                        myNumber = Program.numberQueue.Dequeue();
                    }
                }

                if (myNumber != -1)
                {
                    Console.WriteLine("Thread " + threadNumber + " has obtained the number " + myNumber + ".");
                    numberCollection.Add(myNumber);
                }
            }

            int threadSum = numberCollection.Sum();

            Console.WriteLine("Thread " + threadNumber + " concluded with a total of " + threadSum + ".");
            Program.sums[threadNumber] = threadSum;
        }

    }
}
