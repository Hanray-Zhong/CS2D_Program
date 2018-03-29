using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopping : MonoBehaviour {
    public GameObject ShoppingWindow;
    public GameObject TimeOut;
    public float shoppingTime;

    private float time = 0;

    private void Start()
    {
        time = 0;
    }

    void Update () {
        time++;
		if(time < shoppingTime && Input.GetKeyDown(KeyCode.B))
        {
            ShoppingWindow.SetActive(true);
        }
        if(time >= shoppingTime)
        {
            TimeOut.SetActive(true);
        }
    }
}
