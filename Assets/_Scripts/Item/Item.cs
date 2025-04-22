using System;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int score  = 1;
    public string type = "food";
    

    public void SetData(string foodName)
    {
        this.score = 1;
        this.type = foodName;
    }
}