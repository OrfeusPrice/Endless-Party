using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CatBasil : MonoBehaviour
{
    public GameObject player;
    public GameObject button;
    public GameObject diaglog;
    public int count = 1;
    public TextMeshProUGUI text;

    public void Dialog()
    {
        switch (count)
        {
            case 1:
                diaglog.SetActive(true);
                text.text = "�����.....";
                count++;
                break;
            case 2:
                diaglog.SetActive(true);
                text.text = "������!";
                count++;
                break;
            case 3:
                diaglog.SetActive(true);
                text.text = "��...��...��...";
                count++;
                break;
            case 4:
                diaglog.SetActive(true);
                text.text = "*������ �����*";
                count++;
                break;
            case 5:
                diaglog.SetActive(true);
                text.text = "*������*";
                count++;
                break;
            case 6:
                diaglog.SetActive(true);
                text.text = "�������, � �� �� ����� �� ��� ������?";
                count++;
                break;
            case 7:
                diaglog.SetActive(true);
                text.text = "���, ��������, ������� �����?";
                count++;
                break;
            case 8:
                diaglog.SetActive(true);
                text.text = "��������� ��������������, �������!";
                count++;
                break;
            
            
            
            default:
                diaglog.SetActive(true);
                text.text = "�� ������ ���, �������!";
                count++;
                break;
        }
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            button.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            button.SetActive(false);
            diaglog.SetActive(false);
        }
    }
}
