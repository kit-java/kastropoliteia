using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange startToChange = new StatToChange();


    public enum StatToChange
    {
        none,
        health,
        mana,
        stamina
    }
}
