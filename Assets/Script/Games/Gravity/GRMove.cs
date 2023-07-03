using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GRMove : MonoBehaviour
{
    int score = 0;
    bool enJump = true;
    public TextMeshProUGUI text;
    public Image gravity;
    Color color;
    private int live = 2;
    public GameObject[] livesObj = new GameObject[3];
    public GRSpawnFood spawn1;
    public GRSpawnRoad spawn2;
    private void Start()
    {
        color = gravity.color;
        Physics2D.gravity.Set(8f,Physics2D.gravity.y);
    }
    private void Update()
    {
        if (Input.touchCount > 0 && enJump)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
                Move();
        }
    }
    public void Move()
    {
        GetComponent<SpriteRenderer>().flipY = !GetComponent<SpriteRenderer>().flipY;
        Physics2D.gravity.Set(Physics2D.gravity.x * -1, Physics2D.gravity.y);
        enJump = false;
        color.a = 0.5f;
        gravity.color = color;
        Invoke("JumpEnabled", 0.8f);
    }

    private void JumpEnabled()
    {
        color.a = 1f;
        gravity.color = color;
        enJump = true;
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Food")
        {
            ScoreInc();
        }
        if (col.tag == "PlayerDestr")
        {
            live_dec();
        }

    }


    public void ScoreInc()
    {
        score++;
        text.text = "Score: " + score.ToString();
    }

    public void live_dec()
    {
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
        if (live >= 0)
        {
            livesObj[live].SetActive(false);
            live--;
        }
    }
}
