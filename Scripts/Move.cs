using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    public float speed = 1f;
    public float tileSize = 1f;
    public FlappyGame game;
	
	// Update is called once per frame
	void Update () {
        if (!game.ended)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

            if (transform.position.x < -tileSize)
            {
                transform.position += Vector3.right * tileSize;
            }
        }
	}
}
