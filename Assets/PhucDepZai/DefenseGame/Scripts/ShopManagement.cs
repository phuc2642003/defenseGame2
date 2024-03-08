using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManagement : MonoBehaviour
{
    public ShopUnit[] shopUnits;
    public GameManagement gameManage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void clickOnShopButton(ShopUnit shopUnit)
    {
        if(shopUnit.isActivated)
        {
            if(!shopUnit.isChosen)
            {
                shopUnit.isChosen = true;
            }    
        }    
    }
    
    public void displayText()
    {
        foreach (ShopUnit shopUnit in shopUnits)
        {
            if (shopUnit.isActivated)
            {
                if (shopUnit.isChosen)
                {
                    shopUnit.text.text = "Chosen";
                }
                else 
                {
                    shopUnit.text.text = "Owned";
                }
            }
            else
            {
                shopUnit.text.text = shopUnit.price.ToString();
            }    
        }
    }    
        
    
}
