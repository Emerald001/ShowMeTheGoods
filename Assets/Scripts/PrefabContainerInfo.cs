using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabContainerInfo : MonoBehaviour
{
    public Text PriceText;
    public Text NameText;
    public Text AmountText;

    public float price;
    public float amount;
    public string itemName;
    public int ID;
    public delegate void Func(GameObject @object);

    private void Update() {
        PriceText.text = "€ " + price.ToString() + ",-";
        NameText.text = itemName;
        //AmountText.text = "X" + amount.ToString();
    }

    public void RemoveThis() {
        var tmp = GetComponentInParent<Mandje>();
        tmp.RemoveItem(this.gameObject);
    }
}
