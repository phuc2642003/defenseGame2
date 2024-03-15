using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManagement : MonoBehaviour
{
    public ShopUnit[] shopUnits;
    // Start is called before the first frame update
    void Start()
    {
        init();
    }
    private void init()
    {
        if (shopUnits == null || shopUnits.Length <= 0) return;

        for(int i=0; i<shopUnits.Length;i++)
        {
            if (shopUnits[i]!=null)
            {
                if(i==0)
                {
                    Pref.SetBool(Const.Player_Hero_PREF + i, true);
                }
                else
                {
                    if(!PlayerPrefs.HasKey(Const.Player_Hero_PREF + i))
                    {
                        Pref.SetBool(Const.Player_Hero_PREF + i,false);
                    }    
                    
                }    
            }    
        }    
    }    
    
}
