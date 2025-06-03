using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    public bool isOpen;

    float downPosition;
    float MoveSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        downPosition = transform.position.y - 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        //プレイヤーか弾が当たったらドアを開く
        if ( collision.gameObject.tag == "Player")
        {
            isOpen = true;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, downPosition, transform.position.z), MoveSpeed * Time.deltaTime);
        }
    }
}
