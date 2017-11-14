using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class GameData : MonoBehaviour
{
    public IntReactiveProperty Score = new IntReactiveProperty();
}
