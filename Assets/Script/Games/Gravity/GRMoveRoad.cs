using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GRMoveRoad : MonoBehaviour
{
    //public float speed = 0;
    public GameObject destr;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Destroyer")
            Destroy(gameObject);
    }
}
