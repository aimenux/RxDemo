# Welcome to RxDemo !

## This is a console application that shows a simple usage of Rx.

>*Reactive Extensions (Rx) is a library for composing asynchronous and event-based programs using observable sequences and LINQ-style query operators. The Rx library is available for desktop application development in .NET. It is also released for Silverlight, Windows Phone 7 and JavaScript. For more informations about Rx, i recommend this [link](http://www.introtorx.com/content/v1.0.10621.0/00_Foreword.html).*

**Technical requirements** : .NET 4.5.2, VS 17

We show the use of the following concepts : Subject, ReplaySubject, BehaviorSubject and AsyncSubject.

> Subject is the most basic of the subjects for providing push notifications after subscriptions.
  
> ReplaySubject provides the feature of caching values and then replaying them for any late subscriptions.
  
> BehaviorSubject is similar to ReplaySubject<T> except it only remembers the last publication.
  
> AsyncSubject is similar to the Replay and Behavior subjects in the way that it caches values. However, it will only store the last value and only publish it when the sequence is completed.
