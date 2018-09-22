using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceLabel : MonoBehaviour {

    Text myText;
    float distance;
    public FlappyGame game;

    void Start ()
    {
        myText = GetComponent<Text>();
    }
	
	void Update ()
    {
        if (!game.ended)
        {

            distance += Time.deltaTime;
            myText.text = $"DIST {distance:0.00}";
        }
    }
}
