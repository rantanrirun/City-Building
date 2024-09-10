using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Teleport : MonoBehaviour
{
    //ワープ先座標の指定
    public Vector3 default_pos = new Vector3(60f, 60f, 60f);
    // Use this for initialization
    void Start()
    {
        transform.position = default_pos;
    }

    // Update is called once per frame
    void Update()
    {
        //キーボードのY(任意)を押すと、default_posで設定したXYZ座標にワープする
        if (Input.GetKey(KeyCode.Y))
        {
            transform.position = default_pos;
        }
    }
}
