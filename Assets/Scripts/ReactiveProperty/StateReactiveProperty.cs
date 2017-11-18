using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;


public enum State
{
    Title,
    GamePlay,
    Result,
}


public class StateReactiveProperty : ReactiveProperty<State>
{
    public StateReactiveProperty()
    {
    }

    public StateReactiveProperty(State initialValue) : base(initialValue)
    {
    }

    public StateReactiveProperty(IObservable<State> source) : base(source)
    {
    }

    public StateReactiveProperty(IObservable<State> source, State initialValue) : base(source, initialValue)
    {
    }
}
