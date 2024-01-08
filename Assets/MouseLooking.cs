using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseLooking : MonoBehaviour
{
    public Transform target; // 中心點
    public float rotationSpeed = 1.0f;
    public float zoomSpeed = 5.0f;
    public GameManager gm;

    public void Start() {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        // 檢查滑鼠左鍵是否被按住
        if (Input.GetMouseButton(0) && !gm.Block())
        {
            // 在這裡你可以根據滑鼠的移動來計算旋轉速度
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // 將滑鼠移動轉換為相機的旋轉
            RotateCamera(mouseX, mouseY);
        }

        // 檢查滾輪是否有移動
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel != 0 && !gm.Block())
        {
            // 進行相機的縮放
            ZoomCamera(scrollWheel);
        }
    }

    private void RotateCamera(float mouseX, float mouseY)
    {
        // 根據滑鼠的移動計算相機的水平和垂直旋轉速度
        float horizontalRotation = mouseX * rotationSpeed;
        float verticalRotation = -mouseY * rotationSpeed; // 注意這裡的修改

        // 獲取相機的 Transform 組件
        Transform cameraTransform = Camera.main.transform;

        // 將相機的位置轉換為中心點的局部坐標
        Vector3 relativePos = cameraTransform.position - target.position;

        // 進行水平和垂直旋轉
        Quaternion rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);
        relativePos = rotation * relativePos;

        // 更新相機的位置
        cameraTransform.position = target.position + relativePos;

        // 使相機一直朝向中心點
        cameraTransform.LookAt(target.position);
    }

    private void ZoomCamera(float scrollWheel)
    {
        // 獲取相機的 Transform 組件
        Transform cameraTransform = Camera.main.transform;

        // 計算相機的縮放量
        float zoomAmount = scrollWheel * zoomSpeed;

        // 更新相機的位置，使其沿著看向中心點的方向縮放
        cameraTransform.Translate(Vector3.forward * zoomAmount, Space.Self);
    }
}