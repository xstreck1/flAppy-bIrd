using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceLabel : MonoBehaviour {

    Text myText;
    float distance;
    
	void Start ()
    {
        myText = GetComponent<Text>();
    }
	
	void Update ()
    {
        distance += Time.deltaTime;
        myText.text = $"DIST {distance:0.00}";
    }
}
