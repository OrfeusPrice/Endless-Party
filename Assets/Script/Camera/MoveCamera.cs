using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveCamera : MonoBehaviour
{
    // ��������� ������, �� ������� ����� ��������� ������
    public Transform target;
    [Header("Camera position restrictions")]
    public float minY;
    public float maxY;
    public float minX;
    public float maxX;

    void Update()
    {
        UpdateCameraPosition();
    }

    // �������� ������� ������ �� ������
    void UpdateCameraPosition()
    {
        transform.position = new Vector3(
            // ��������� �������� �������, �� ������� �� ���������
            Mathf.Clamp(target.position.x, minX, maxX),
            Mathf.Clamp(target.position.y, minY, maxY),
            // ��������� ������ z ������ ���������� ���������� 
            transform.position.z // (���� ������ ����-�� �������������, �������� ��, ��������, -10)
          );
    }





}
