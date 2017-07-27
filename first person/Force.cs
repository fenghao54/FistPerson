using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour {

	
	void Start () {
		
	}
	
	
	void Update () {
        Vector3 positon = transform.position;
        positon.y = 0;
        transform.position = positon;
	}
}
