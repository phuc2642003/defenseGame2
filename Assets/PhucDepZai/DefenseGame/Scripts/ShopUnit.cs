using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUnit : MonoBehaviour
{
    public GameObject heroPrefab { get; set; }
    public int price { get ; set; }
    public bool isActivated { get; set; }
    public bool isChosen { get; set; }
    public Text text { get; set; }
    public int id { get; set; }

}
