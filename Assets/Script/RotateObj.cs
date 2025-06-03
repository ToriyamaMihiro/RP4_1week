using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotateObj : MonoBehaviour
{
    public float rotateSpeed = 0.5f;
    public float posChange = 0;
    public GameObject scene;
    //public Vector3 worldScale = new Vector3(7,7,1);

    // Start is called before the first frame update
    void Start()
    {
      //ReSize();
    }

    void ReSize()
    {
        
    }

    void LateUpdate()
    {
        //// 親のワールドスケールを取得
        //Vector3 parentScale = transform.parent != null ? transform.parent.lossyScale : Vector3.one;

        //// ワールドスケール = ローカルスケール × 親のスケール → ローカルスケール = ワールド / 親
        //transform.localScale = new Vector3(
        //    worldScale.x / parentScale.x,
        //    worldScale.y / parentScale.y,
        //    worldScale.z / parentScale.z
        //);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
        //transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime, Space.World);
        transform.position=new Vector3 (scene.transform.position.x+posChange, transform.position.y, transform.position.z);
    }
}
