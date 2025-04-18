using System;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int score  = 1;
    public string type = "food";
        
        
    private bool _inTheHole = false;

    public bool InTheHole
    {
        get { return _inTheHole; }
        set { _inTheHole = value; }
    }

    public void SetData(string foodName)
    {
        this.score = 1;
        this.type = foodName;
    }
}