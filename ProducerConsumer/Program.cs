using System;
using System.Collections.Generic;
using System.Threading;

namespace ProducerConsumer
{
    class Program
    {
        static Queue<int> products = new Queue<int>();
        static void Main(string[] args)
        {
            Thread t1 = new Thread(Produce);
            Thread t2 = new Thread(Consume);

            t1.Name = "Producer";
            t2.Name = "Consumer";

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }

        static void Produce()
        {
            int produceAttempt = 0;
            while (true)
            {
                {
                    if (products.Count < 3)
                    {
                        produceAttempt = 0;
                        products.Enqueue(1);
                        Console.WriteLine(Thread.CurrentThread.Name + " produced: " + products.Count);
                    }
                    else
                    {
                        if (produceAttempt < 8)
                        {
                            Console.WriteLine(Thread.CurrentThread.Name + " couldn't produce: " + products.Count);
                            produceAttempt++;
                        }
                        else
                            Thread.Sleep(1500);
                    }
                }
            }
        }

        static void Consume()
        {
            int consumeAttempt = 0;
            while (true)
            {
                if (products.Count > 0)
                {
                    consumeAttempt = 0;
                    products.Dequeue();
                    Console.WriteLine(Thread.CurrentThread.Name + " consumed: " + products.Count);
                }
                else
                {
                    if (consumeAttempt < 8)
                    {
                        Console.WriteLine(Thread.CurrentThread.Name + " couldn't comsume: " + products.Count);
                        consumeAttempt++;
                    }
                    else
                        Thread.Sleep(1500);
                }
            }
        }
    }
}

