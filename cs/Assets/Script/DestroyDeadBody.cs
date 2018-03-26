using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDeadBody : MonoBehaviour {

	
	void Update () {
        GameObject.Destroy(gameObject, 5);
	}
}
