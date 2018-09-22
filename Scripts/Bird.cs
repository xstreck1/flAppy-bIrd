using MLAgents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Agent
{
    Rigidbody2D myBody;
    public float forceRatio = 1f;
    Vector3 startPos;
    float height = 5f;
    public float Heat { get; set; } = 0f;
    public FlappyGame game;

    float MouseY => Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

    public void Push()
    {
        myBody.AddForce(Vector2.up * forceRatio, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (Mathf.Abs(transform.position.y - MouseY) < .5f)
        {
            Heat += Time.deltaTime * 10f;
        }
        else
        {
            Heat -= Time.deltaTime * 1f;
        }
        Heat = Mathf.Clamp(Heat, 0, 100f);
        if (Heat >= 100f)
        {
            game.EndGame();
        }
    }

    public override void InitializeAgent()
    {
        myBody = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    public override void CollectObservations()
    {
        AddVectorObs(gameObject.transform.position.y);
        AddVectorObs(myBody.velocity.y);
        AddVectorObs(MouseY);
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        int jump = Mathf.FloorToInt(vectorAction[0]);

        if (jump == 1)
        {
            Push();
        }
        if (transform.position.y > height || transform.position.y < -height)
        {
            SetReward(-1f);
            Done();
        }
        else
        {
            SetReward(Mathf.Abs(transform.position.y - MouseY) * .01f);
        }
    }

    public override void AgentReset()
    {
        if (game.isTraning)
        {
            myBody.velocity = Vector3.zero;
            transform.position = startPos;
        }
        else if (transform.position.y > height || transform.position.y < -height)
        {
            game.EndGame();
        }
    }

}
