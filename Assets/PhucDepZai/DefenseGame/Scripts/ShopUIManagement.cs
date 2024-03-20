using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopUIManagement : MonoBehaviour
{
    public Transform UnitGrid;
    public ShopUnitManagement shopUnitPrefab;
    private ShopManagement shopManage;
    private GameManagement gameManage;

    public void updateShopUI()
    {
        shopManage = FindObjectOfType<ShopManagement>();
        gameManage = FindObjectOfType<GameManagement>();

        var units = shopManage.shopUnits;

        if (units == null || units.Length <= 0)
            return;
        if (UnitGrid.childCount > 0)
            return;    
        for (int i = 0; i < units.Length; i++)
        {
            var unit = units[i];

            var unitClone = Instantiate(shopUnitPrefab, Vector3.zero, Quaternion.identity);

            unitClone.transform.SetParent(UnitGrid);

            unitClone.transform.localScale=Vector3.one;

            unitClone.UnitUIManager(unit, i);
        }
    }
   
}
