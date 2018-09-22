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

    public Sprite normal;
    public Sprite flap;

    float MouseY => Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

    public void Push()
    {
        if (!game.ended)
        {
            myBody.AddForce(Vector2.up * forceRatio, ForceMode2D.Impulse);
        }
        if (!game.isTraning)
        {
            GetComponent<SpriteRenderer>().sprite = flap;
            StartCoroutine(ResetFlap());
        }
    }

    IEnumerator ResetFlap()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<SpriteRenderer>().sprite = normal;
    }

    private void Update()
    {
        if (Mathf.Abs(transform.position.y - MouseY) < .5f)
        {
            Heat += Time.deltaTime * 10f;
        }
        else
        {
            Heat -= Time.deltaTime * 2.5f;
        }
        Heat = Mathf.Clamp(Heat, 0, 100f);
        if (Heat >= 100f && !game.isTraning)
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
            SetReward(Mathf.Log(Mathf.Abs(transform.position.y - MouseY) + 1f) * .01f - 0.02f);
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
