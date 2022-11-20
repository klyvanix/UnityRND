using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ElementalType : ScriptableObject
{
    public string Name;
    public Color Color;
    public ElementalType WeakAgainst;
    public ElementalType StrongAgainst;
}
