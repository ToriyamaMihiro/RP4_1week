using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAction : MonoBehaviour
{
    float downPosition;
    float MoveSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
      
        downPosition = transform.position.y - 3;
    }

    // Update is called once per frame
    void Update()
    {
        ButtonAction button;
        GameObject obj = GameObject.Find("Button");
        button = obj.GetComponent<ButtonAction>();

        //もしボタンがONになったらドアが 開く
        //右に行く
        if (button.isOpen)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, downPosition, transform.position.z), MoveSpeed * Time.deltaTime);
        }
    }
}
