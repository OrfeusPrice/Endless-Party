using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 0.03f; //�������� ��������
    public Sprite stay; //����������� �������� ���������
    public Sprite[] stay_arr = new Sprite[3];
    private float side; //���������� �������, � ������� ������� �����
    public GameObject player;
    public Animator anim;

    // Update is called once per frame
    private void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Input.GetAxis("Horizontal") * Time.deltaTime;  //�������� �����/������ �� ����������� �������
        transform.position += new Vector3(0, speed, 0) * Input.GetAxis("Vertical") * Time.deltaTime;    //�������� �����/���� �� ����������� �������
        side = Input.GetAxis("Horizontal"); //����������, � ����� ������� ��������� ������� ����� ��� ��������

        if (side < 0)
        {
            player.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (side > 0)
        {
            player.GetComponent<SpriteRenderer>().flipX = false;
        }

        if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
        {
            player.GetComponent<Animator>().enabled = true;   //�������� �������� ��� ��������
            GetComponent<AudioSource>().playOnAwake = true;
            GetComponent<AudioSource>().enabled = true;

            if (Input.GetAxis("Vertical") > 0)
            {
                anim.SetBool("Top", true);
                anim.SetBool("Down", false);
                stay = stay_arr[1];
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                anim.SetBool("Down", true);
                anim.SetBool("Top", false);
                stay = stay_arr[2];
            }
            if (Input.GetAxis("Vertical") == 0)
            {
                anim.SetBool("Top", false);
                anim.SetBool("Down", false);
                stay = stay_arr[0];
            }
        }
        else
        {
            player.GetComponent<Animator>().enabled = false;
            player.GetComponent<SpriteRenderer>().sprite = stay;
            GetComponent<AudioSource>().enabled = false;
            anim.SetBool("Top", false);
            anim.SetBool("Down", false);
        }
    }
}
