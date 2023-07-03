using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GRMove : MonoBehaviour
{
    int score = 0;
    bool enJump = true;
    public bool _AIPlay = false;
    public TextMeshProUGUI text;
    public Image gravity;
    Color color;
    private int live = 2;
    public GameObject[] livesObj = new GameObject[3];
    public GRSpawnFood spawn1;
    public GRSpawnRoad spawn2;
    public GameObject DonatePanel;
    private void Start()
    {
        color = gravity.color;
        Physics2D.gravity = new Vector2(6, Physics2D.gravity.y);
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

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (enJump && _AIPlay)
            Move();
    }
    public void Move()
    {
        GetComponent<SpriteRenderer>().flipY = !GetComponent<SpriteRenderer>().flipY;
        Physics2D.gravity = new Vector2(-Physics2D.gravity.x, Physics2D.gravity.y);
        enJump = false;
        color.a = 0.5f;
        gravity.color = color;
        Invoke("JumpEnabled", 1f);
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
        else if (live < 0){ DonatePanel.SetActive(true); Time.timeScale = 0; }
    }
}
