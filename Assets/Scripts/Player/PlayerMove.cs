using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerMove : MonoBehaviour
{
    private Vector3 pos;
    float x, y, z;
    float fov;
    float moveSpeed = 10.0f;
    //マウス感度
    [SerializeField, Range(1.0f, 150.0f)]
    private float _mouseSensitive = 1.0f;
    //マウスの始点 
    private Vector3 previousMousePosition;
    //カメラ回転の始点情報
    private Vector3 _presentCamRotation;
    private Vector3 _presentPlayerRotation;
    private Vector3 _presentCamPos;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        _presentCamRotation = cam.transform.localEulerAngles;
        _presentPlayerRotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotationMouseControl(); //カメラの回転 マウス
        CameraMove();
        CameraZoom();
    }

    //カメラの回転 マウス
    private void CameraRotationMouseControl()
    {
        if (Input.GetMouseButtonDown(1))
        {
            previousMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(1))
        {
            //(移動開始座標 - マウスの現在座標) / 解像度 で正規化
            float x = (previousMousePosition.x - Input.mousePosition.x) / Screen.width;
            float y = (previousMousePosition.y - Input.mousePosition.y) / Screen.height;

            previousMousePosition = Input.mousePosition;
            //Debug.Log(Input.mousePosition);

            //回転開始角度 ＋ マウスの変化量 * マウス感度
            _presentCamRotation.x = _presentCamRotation.x - y * _mouseSensitive * 1f;
            _presentPlayerRotation.y = _presentPlayerRotation.y + x * _mouseSensitive * 1f;
            _presentCamRotation.x = Mathf.Clamp(_presentCamRotation.x, -80f, 80f);

            cam.transform.localEulerAngles = _presentCamRotation;
            transform.eulerAngles = _presentPlayerRotation;
        }
    }

    private void CameraMove()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Height");
        z = Input.GetAxisRaw("Vertical");
        pos = this.transform.position;
        Vector3 PlayerMovement = transform.right * x + transform.forward * z;
        PlayerMovement.y = 0;
        PlayerMovement = Vector3.Normalize(PlayerMovement);
        PlayerMovement += transform.up * y;

        pos += PlayerMovement * moveSpeed * Time.deltaTime;
        this.transform.position = pos;
    }

    private void CameraZoom()
    {
        fov = Input.mouseScrollDelta.y * 10;
        float camfov = cam.fieldOfView;
        camfov += fov;
        camfov = Mathf.Clamp(camfov, 50f, 100f);
        cam.fieldOfView = camfov;
        //Debug.Log("cam.fieldOfView" + cam.fieldOfView);
        //Debug.Log("fov" + fov);
    }
}
