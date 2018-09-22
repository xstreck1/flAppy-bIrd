using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlappyGame : MonoBehaviour
{
    public bool isTraning = false;
    public Bird mainBird;
    public Bird[] birds;
    public Text endText;

    // Use this for initialization
    void Start()
    {
        endText.text = "";
        if (!isTraning)
        {
            foreach (var bird in birds)
            {
                bird.gameObject.SetActive(bird == mainBird);
            }
        }
    }



    public void EndGame()
    {
        Time.timeScale = 0f;
        endText.text = "YOU KILLED ICARUS.\nYOU BASTARD!";
    }
}
