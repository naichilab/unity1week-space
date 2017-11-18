using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawner : MonoBehaviour
{
    public enum EffectType
    {
        good, great, perfect, miss
    }


    [SerializeField] private GameObject good;
    [SerializeField] private GameObject great;
    [SerializeField] private GameObject perfect;
    [SerializeField] private GameObject miss;

    public void Show(EffectType t)
    {
        GameObject prefab;
        switch (t)
        {
            case EffectType.good:
                prefab = good;
                break;
            case EffectType.great:
                prefab = great;
                break;
            case EffectType.perfect:
                prefab = perfect;
                break;
            case EffectType.miss:
                prefab = miss;
                break;
            default:
                throw new NotImplementedException();
        }

        Instantiate(prefab, this.transform.position, Quaternion.identity, this.transform);
    }

}
