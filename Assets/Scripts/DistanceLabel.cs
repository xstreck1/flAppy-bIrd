using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceLabel : MonoBehaviour
{

    Text myText;
    float distance;
    public Bird bird;

    void Start()
    {
        myText = GetComponent<Text>();
    }

    void Update()
    {
        myText.text = $"DIST {bird.counter:0.00}";
    }
}
