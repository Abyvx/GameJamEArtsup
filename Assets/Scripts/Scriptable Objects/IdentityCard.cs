using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Identity Card", menuName = "Scriptable Objects/New identity card", order = 1)]
public class IdentityCard : ScriptableObject
{
    public string firstName;
    public string lastName;

    public int age;
    [TextArea(5, 8)] public string passions;

    public List<Action> funnyActions = new(3);
}
