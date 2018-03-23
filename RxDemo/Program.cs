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
            // Subject<T> is the most basic of the subjects for providing push notifications after subscriptions.

            Console.WriteLine("Subject");
            using (var stream = new Subject<string>())
            {
                stream.OnNext("a");
                stream.Subscribe(Console.WriteLine);
                stream.OnNext("b");
                stream.OnNext("c");
            }

            PressAnyKey("Press any key to continue ..");

            // ReplaySubject<T> provides the feature of caching values and then replaying them for any late subscriptions.

            Console.WriteLine("ReplaySubject");
            using (var stream = new ReplaySubject<string>())
            {
                stream.OnNext("a");
                stream.OnNext("b");
                stream.OnNext("c");
                stream.Subscribe(Console.WriteLine);
            }

            PressAnyKey("Press any key to continue ..");

            // ReplaySubject<T> allows you to specify simple cache expiry settings that can alleviate this memory issue. 
            // One option is that you can specify the size of the buffer in the cache.

            Console.WriteLine("ReplaySubject(Buffer)");
            const int bufferSize = 2;
            using (var stream = new ReplaySubject<string>(bufferSize))
            {
                stream.OnNext("a");
                stream.OnNext("b");
                stream.OnNext("c");
                stream.Subscribe(Console.WriteLine);
            }

            PressAnyKey("Press any key to continue ..");

            // ReplaySubject<T> allows you to specify simple cache expiry settings that can alleviate this memory issue. 
            // Another option is that you can provide a window time for the cache.

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

            PressAnyKey("Press any key to continue ..");

            // BehaviorSubject<T> is similar to ReplaySubject<T> except it only remembers the last publication. 
            // BehaviorSubject<T> also requires you to provide it a default value of T. 
            // This means that all subscribers will receive a value immediately (unless it is already completed).

            Console.WriteLine("BehaviorSubject(default)");

            // default value will be written to the console
            using (var stream = new BehaviorSubject<string>("a"))
            {
                stream.Subscribe(Console.WriteLine);
            }

            Console.WriteLine("BehaviorSubject(latest)");

            // the last value will be written to the console
            using (var stream = new BehaviorSubject<string>("a"))
            {
                stream.OnNext("b");
                stream.OnNext("c");
                stream.Subscribe(Console.WriteLine);
            }

            PressAnyKey("Press any key to continue ..");

            // BehaviorSubject<T> is similar to ReplaySubject<T> except it only remembers the last publication. 
            // No values will be published as the sequence has completed. Nothing is written to the console.

            Console.WriteLine("BehaviorSubject(OnCompleted)");
            using (var stream = new BehaviorSubject<string>("a"))
            {
                stream.OnNext("b");
                stream.OnNext("c");
                stream.OnCompleted();
                stream.Subscribe(Console.WriteLine);
            }

            PressAnyKey("Press any key to continue ..");

            // AsyncSubject<T> is similar to the Replay and Behavior subjects in the way that it caches values.
            // However, it will only store the last value and only publish it when the sequence is completed.

            Console.WriteLine("AsyncSubject(nothing)");
            using (var stream = new AsyncSubject<string>())
            {
                stream.OnNext("a");
                stream.OnNext("b");
                stream.OnNext("c");
                stream.Subscribe(Console.WriteLine);
            }

            Console.WriteLine("AsyncSubject(latest)");
            using (var stream = new AsyncSubject<string>())
            {
                stream.OnNext("a");
                stream.OnNext("b");
                stream.OnNext("c");
                stream.OnCompleted();
                stream.Subscribe(Console.WriteLine);
            }

            PressAnyKey("Press any key to exit ..");
        }

        private static void PressAnyKey(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
