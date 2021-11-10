using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tmp : MonoBehaviour
{
    private float size;
    private float top;
    private RectTransform rt;

    // Start is called before the first frame update
    void Start() { 
        rt = GetComponent<RectTransform>();

        top = rt.position.y;
        size = rt.sizeDelta.y;
    }

    // Update is called once per frame
    void Update()
    {
        var scroll = -Input.mouseScrollDelta;
        var Vpos = rt.position.y + (scroll.y * 100);
        Vpos = Mathf.Clamp(Vpos, top, top + size/2);

        rt.position = new Vector2(transform.position.x, Vpos);
    }
}