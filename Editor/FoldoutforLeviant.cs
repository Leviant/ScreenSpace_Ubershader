//Made by Aidan.ogg#0001 for Leviant#8796
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct FoldoutforLeviant
{
    static int foldState;
    static Material _material;

    public static void Initialize(Material material)
    {
        foldState = Mathf.RoundToInt(material.GetFloat("_Fold"));
        _material = material;
    }

    public static FoldoutforLeviant Get(int bit)
    {
        return new FoldoutforLeviant { bit = bit };
    }

    public int bit;
    public bool state
    {
        get { return (foldState & (1 << bit)) != 0; }
        set
        {
            foldState = value ? foldState | (1 << bit) : foldState & ~(1 << bit);
            _material.SetFloat("_Fold", foldState);
        }
    }
}
