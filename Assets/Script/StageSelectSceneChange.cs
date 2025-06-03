using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class StageSelectSceneChange : MonoBehaviour
{
    float speed = 13f;

    Vector2 startPosition = new Vector2(-22.4f, 0);
    Vector2 endPosition = new Vector2(0, 0);

    public bool isToutch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //黒い四角を移動させる
        transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
       
        //z押したら
        if (Input.GetKey(KeyCode.Z) && isToutch)
        {
            //黒い四角を移動させる
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
           

        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stage")
        {
            isToutch = true;
        }
    }
}
