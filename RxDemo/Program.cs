using System;
using System.Reactive.Subjects;
using System.Threading;

namespace RxDemo
{
    internal class Program
    {
        // IObserver<T> : 'reader' / 'consumer' ; IObservable<T> : 'writer' / 'publisher'
        private static void Main()
        {
            // Subject
            Console.WriteLine("Subject");
            using (var stream = new Subject<string>())
            {
                stream.Subscribe(Console.WriteLine);
                stream.OnNext("a");
                stream.OnNext("b");
                stream.OnNext("c");
            }

            // ReplaySubject
            Console.WriteLine("ReplaySubject");
            using (var stream = new ReplaySubject<string>())
            {
                stream.OnNext("a");
                stream.OnNext("b");
                stream.OnNext("c");
                stream.Subscribe(Console.WriteLine);
            }

            // ReplaySubject
            Console.WriteLine("ReplaySubject(Buffer)");
            const int bufferSize = 2;
            using (var stream = new ReplaySubject<string>(bufferSize))
            {
                stream.OnNext("a");
                stream.OnNext("b");
                stream.OnNext("c");
                stream.Subscribe(Console.WriteLine);
            }

            // ReplaySubject
            Console.WriteLine("ReplaySubject(Window)");
            var window = TimeSpan.FromMilliseconds(150);
            using (var stream = new ReplaySubject<string>(window))
            {
                stream.OnNext("a");
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
                stream.OnNext("b");
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
                stream.OnNext("c");
                stream.Subscribe(Console.WriteLine);
            }

            // BehaviorSubject
            Console.WriteLine("BehaviorSubject");
            using (var stream = new BehaviorSubject<string>("a"))
            {
                stream.OnNext("b");
                stream.OnNext("c");
                stream.Subscribe(Console.WriteLine);
            }

            // BehaviorSubject
            Console.WriteLine("BehaviorSubject OnCompleted");
            using (var stream = new BehaviorSubject<string>("a"))
            {
                stream.OnNext("b");
                stream.OnNext("c");
                stream.OnCompleted();
                stream.Subscribe(Console.WriteLine);
            }

            // AsyncSubject
            Console.WriteLine("AsyncSubject");
            using (var stream = new AsyncSubject<string>())
            {
                stream.OnNext("a");
                stream.OnNext("b");
                stream.OnNext("c");
                stream.OnCompleted();
                stream.Subscribe(Console.WriteLine);
            }

            Console.ReadKey();
        }
    }
}
