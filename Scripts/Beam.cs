using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour {

    float MouseY => Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.up * MouseY;
    }
}
