using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContainerInfo : MonoBehaviour {

    public Text PriceText;
    public Text NameText;
    
    public float price;
    public string itemName;

    private void Update() {
        PriceText.text = "€ " + price.ToString() + ",-";
        NameText.text = itemName;
    }
}
