using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Reactive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Lab7_v2_Pt2.Modules
{
    internal class WindowEventFactory
    {
        public static IObservable<TEventArgs> CreateWindowEvents<TEventArgs>(Window window) where TEventArgs : EventArgs
        {
            return Observable.Create<TEventArgs>(observer =>
            {
                var disposable = new CompositeDisposable();

                /*// Subscribe to the events of the main window
                disposable.Add(window.Closed.Subscribe(args => observer.OnNext((TEventArgs)(object)args)));

                // Subscribe to the events of all child elements inside the window
                foreach (var child in window.Children)
                {
                    if (child is Control control)
                    {
                        disposable.Add(control.PointerPressed.Subscribe(args => observer.OnNext((TEventArgs)(object)args)));
                        disposable.Add(control.PointerMoved.Subscribe(args => observer.OnNext((TEventArgs)(object)args)));
                        disposable.Add(control.PointerReleased.Subscribe(args => observer.OnNext((TEventArgs)(object)args)));
                        disposable.Add(control.PointerWheelChanged.Subscribe(args => observer.OnNext((TEventArgs)(object)args)));
                        disposable.Add(control.KeyDown.Subscribe(args => observer.OnNext((TEventArgs)(object)args)));
                        disposable.Add(control.KeyUp.Subscribe(args => observer.OnNext((TEventArgs)(object)args)));
                        disposable.Add(control.GotFocus.Subscribe(args => observer.OnNext((TEventArgs)(object)args)));
                        disposable.Add(control.LostFocus.Subscribe(args => observer.OnNext((TEventArgs)(object)args)));
                    }
                }*/

                return disposable;
            });
        }
    }
}
