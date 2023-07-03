using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GRSpawnRoad : MonoBehaviour
{
    public GameObject right;
    public GameObject left;

    public GameObject bRight;
    public GameObject bLeft;

    GameObject nRight;
    GameObject nLeft;

    float rr = 3;
    float rl = 3;

    void Start()
    {
        //bRight.GetComponent<GRMoveRoad>().speed = -4;
        //bLeft.GetComponent<GRMoveRoad>().speed = -4;

        nRight = Instantiate(right);
        nLeft = Instantiate(left);
        nRight.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        nRight.GetComponent<Rigidbody2D>().freezeRotation = true;
        nRight.GetComponent<BoxCollider2D>().enabled = true;
        
        nLeft.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        nLeft.GetComponent<Rigidbody2D>().freezeRotation = true;
        nLeft.GetComponent<BoxCollider2D>().enabled = true;
        
        //nRight.GetComponent<GRMoveRoad>().speed = -4;
        //nLeft.GetComponent<GRMoveRoad>().speed = -4;
        InvokeRepeating("Spawn", 0, 1f);
    }

    private void Spawn()
    {
        nRight.transform.position = right.transform.position;
        nLeft.transform.position = left.transform.position;

        if (rr < 1.5f) { rr = 2.5f; }
        nRight.transform.localScale = new Vector3(0.15f, (Random.value + 0.05f) * rr, 0);
        //nRight.GetComponent<SpriteRenderer>().color = Color.red;
        rl = 6 - rr;
        if (rl < 1.5f) { rl = 2.5f; }
        nLeft.transform.localScale = new Vector3(0.15f, (Random.value + 0.05f) * rl, 0);
        //nLeft.GetComponent<SpriteRenderer>().color = Color.red;
        rr = 6 - rr;


        if (nLeft.transform.localScale.y <= 1.5f)
        {
            nLeft.transform.localScale = new Vector3(0.15f, 2f, 0);
            //nLeft.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (nRight.transform.localScale.y <= 1.5f)
        {
            nRight.transform.localScale = new Vector3(0.15f, 2f, 0);
            //nRight.GetComponent<SpriteRenderer>().color = Color.green;
        }

        Instantiate(nRight);
        Instantiate(nLeft);

    }
}
