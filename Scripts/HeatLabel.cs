using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatLabel : MonoBehaviour {

    public Bird mainBird;
    Text myText;
    float heat;
    public FlappyGame game;

    void Start()
    {
        myText = GetComponent<Text>();
    }

    void Update()
    {
        if (!game.ended)
        {
            myText.text = $"HEAT {mainBird.Heat:0.00}";
        }
    }
}
