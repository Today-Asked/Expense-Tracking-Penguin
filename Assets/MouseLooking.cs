using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseLooking : MonoBehaviour
{
    public Transform target; // �����I
    public float rotationSpeed = 1.0f;
    public float zoomSpeed = 5.0f;
    public GameManager gm;

    public void Start() {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        // �ˬd�ƹ�����O�_�Q����
        if (Input.GetMouseButton(0) && !gm.Block())
        {
            // �b�o�̧A�i�H�ھڷƹ������ʨӭp�����t��
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // �N�ƹ������ഫ���۾�������
            RotateCamera(mouseX, mouseY);
        }

        // �ˬd�u���O�_������
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel != 0 && !gm.Block())
        {
            // �i��۾����Y��
            ZoomCamera(scrollWheel);
        }
    }

    private void RotateCamera(float mouseX, float mouseY)
    {
        // �ھڷƹ������ʭp��۾��������M��������t��
        float horizontalRotation = mouseX * rotationSpeed;
        float verticalRotation = -mouseY * rotationSpeed; // �`�N�o�̪��ק�

        // ����۾��� Transform �ե�
        Transform cameraTransform = Camera.main.transform;

        // �N�۾�����m�ഫ�������I����������
        Vector3 relativePos = cameraTransform.position - target.position;

        // �i������M��������
        Quaternion rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);
        relativePos = rotation * relativePos;

        // ��s�۾�����m
        cameraTransform.position = target.position + relativePos;

        // �Ϭ۾��@���¦V�����I
        cameraTransform.LookAt(target.position);
    }

    private void ZoomCamera(float scrollWheel)
    {
        // ����۾��� Transform �ե�
        Transform cameraTransform = Camera.main.transform;

        // �p��۾����Y��q
        float zoomAmount = scrollWheel * zoomSpeed;

        // ��s�۾�����m�A�Ϩ�u�۬ݦV�����I����V�Y��
        cameraTransform.Translate(Vector3.forward * zoomAmount, Space.Self);
    }
}