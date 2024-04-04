using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;
public class ShopUIManagement : MonoBehaviour
{
    public Transform UnitGrid;
    public ShopUnitManagement shopUnitPrefab;

    public void init()
    {
        updateShopUI();
    }

    private void updateShopUI()
    {
        var units = ShopManagement.Instance.shopUnits;

        if (units == null || units.Length <= 0)
            return;

        clearPreviousUnit();
        for (int i = 0; i < units.Length; i++)
        {
            int idx = i;
            
            var unit = units[idx];

            var unitClone = Instantiate(shopUnitPrefab, Vector3.zero, Quaternion.identity);

            unitClone.transform.SetParent(UnitGrid);

            unitClone.transform.localScale=Vector3.one;

            unitClone.UnitUIManager(unit, idx);
            
            if(unitClone.btn)
            {
                unitClone.btn.onClick.RemoveAllListeners();
                unitClone.btn.onClick.AddListener(() => buyingShopUnit(unit, idx));
            }    
        }
    }

    public void buyingShopUnit(ShopUnit unit, int index)
    {
        bool isUnlocked = Pref.GetBool(Const.Player_Hero_PREF + index);

        if(isUnlocked)
        {
            if (index == PlayerPrefs.GetInt(Const.PlayerId_PREF))
                return;
            else
                PlayerPrefs.SetInt(Const.PlayerId_PREF,index);
            updateShopUI();
        }
        else
        {
            if(PlayerPrefs.GetInt(Const.Coin_PREF)>=unit.price)
            {
                PlayerPrefs.SetInt(Const.Coin_PREF, PlayerPrefs.GetInt(Const.Coin_PREF) - unit.price);
                Pref.SetBool(Const.Player_Hero_PREF+index,true) ;
                PlayerPrefs.SetInt(Const.PlayerId_PREF, index);
                updateShopUI();
            }    
            else
            {
                Debug.Log("Not enough money");
                return;
            }
        }
       
    }    
    public void clearPreviousUnit()
    {
        if (UnitGrid == null || UnitGrid.childCount <= 0)
            return;
        for(int i=0;i<UnitGrid.childCount;i++)
        {
            var unit = UnitGrid.GetChild(i);
            if(unit)
            {
                Destroy(unit.gameObject);     
            }    
        }    

    }    
   
}
