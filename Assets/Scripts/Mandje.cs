using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mandje : MonoBehaviour {
    public GameObject prefabContainer;
    public GameObject parentCanvas;
    public GameObject priceContainer;
    public Transform StartingPosition;

    private List<GameObject> mandje = new List<GameObject>();
    private List<GameObject> spawnedObjects = new List<GameObject>();
    private Dictionary<GameObject, float> mandjeDic = new Dictionary<GameObject, float>();

    public void AddItem(GameObject Item) {
        if (mandjeDic.ContainsKey(Item)) {
            mandjeDic[Item] += 1;
            ReloadMandje();
            return;
        }
        mandjeDic.Add(Item, 1); 
        ReloadMandje();
    }

    public void RemoveItem(GameObject Item) {
        var tmp = Item.GetComponent<PrefabContainerInfo>().ID;
        if (mandjeDic.ContainsKey(tmp)) {
            if (mandjeDic[tmp] > 1) {
                mandjeDic[tmp] -= 1;
                ReloadMandje();
                return;
            }
            mandjeDic.Remove(tmp);
        }
        ReloadMandje();
    }

    public void ReloadMandje() {
        Dictionary<GameObject, float>.KeyCollection keys = mandjeDic.Keys;
        mandje.Clear();
        foreach (GameObject key in keys) {
            mandje.Add(key);
        }

        var tmpPrice = 0f;
        var tmpProductAmount = 0f;

        if (spawnedObjects.Count > 0) {
            for (int i = 0; i < spawnedObjects.Count; i++) {
                GameObject.Destroy(spawnedObjects[i]);
            }
        }

        for (int i = 0; i < mandjeDic.Count; i++) {
            var offset = new Vector2(StartingPosition.position.x, StartingPosition.position.y - (i * 200));
            var tmp = Instantiate(prefabContainer, offset, Quaternion.identity);
            tmp.transform.SetParent(parentCanvas.transform);

            var tmpInfo = tmp.GetComponent<PrefabContainerInfo>();
            var mandjeInfo = mandje[i].GetComponent<ContainerInfo>();

            tmpInfo.amount = mandjeDic[mandje[i]];
            tmpProductAmount += mandjeDic[mandje[i]];
            tmpInfo.ID = mandje[i];
            tmpInfo.itemName = mandjeInfo.itemName;
            tmpInfo.price = mandjeInfo.price;
            tmpPrice += mandjeInfo.price * mandjeDic[mandje[i]];

            spawnedObjects.Add(tmp);
        }

        priceContainer.transform.position = new Vector2(StartingPosition.position.x, StartingPosition.position.y - ((mandjeDic.Count * 200) + 50));
        var tmpPriceContainer = priceContainer.GetComponent<PrefabContainerInfo>();
        tmpPriceContainer.price = tmpPrice;
        tmpPriceContainer.amount = tmpProductAmount;
    }
}