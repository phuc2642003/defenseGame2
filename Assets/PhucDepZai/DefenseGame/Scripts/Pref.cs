using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pref : MonoBehaviour
{
    public static void SetBool(string key, bool value)
    {
        if(value)
        {
            PlayerPrefs.SetInt(key, 1);
        }    
        else
        {
            PlayerPrefs.SetInt(key, 0);
        }    
    }
    public static bool GetBool(string key)
    {
        int value = PlayerPrefs.GetInt(key);
        if(value==1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }    
    
}
