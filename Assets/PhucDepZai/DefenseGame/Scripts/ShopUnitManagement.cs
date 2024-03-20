using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUnitManagement : MonoBehaviour
{
    public Text price;
    public Image heroImg;
    public Button btn;

    public void UnitUIManager(ShopUnit unit, int index)
    {
        if (unit == null)
            return;
        if (heroImg)
            heroImg.sprite = unit.img;

        bool isUnlocked = Pref.GetBool(Const.Player_Hero_PREF + index);
        if(price)
        {
            if (isUnlocked)
            {
                if (PlayerPrefs.GetInt(Const.PlayerId_PREF) == index)
                {
                    price.text = "Chosen";
                }
                else
                {
                    price.text = "Owned";
                }
            }
            else
            {
                price.text = unit.price.ToString();
            }    
        }    
        
    }    

}
