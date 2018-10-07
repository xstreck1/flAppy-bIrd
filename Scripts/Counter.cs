// Counter.cs
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour {
    public Bird bird;
    Text scoreText;

    void Start () {
        scoreText = GetComponent<Text>();
    }
	
	void Update () {
        scoreText.text = Mathf.Floor(bird.counter / 2f).ToString();
    }
}
