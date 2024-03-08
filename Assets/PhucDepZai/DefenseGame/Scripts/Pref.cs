using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pref : MonoBehaviour
{
    public int GetValueFromComputer(string key)
    {
        return PlayerPrefs.GetInt(key);
    }    
    
}
