using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectSceneChange : MonoBehaviour
{
    float speed = 13f;

    Vector2 startPosition = new Vector2(-22.4f, 0);
    Vector2 endPosition = new Vector2(0, 0);
    bool isMove;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //z押したら
        if (Input.GetKey(KeyCode.Z))
        {
            SceanManager sceneMane;
            GameObject obj = GameObject.Find("Player");
            sceneMane = obj.GetComponent<SceanManager>();

            if (sceneMane.isToutch)
            {
                isMove = true;
            }

        }
        if (isMove) {
            //黒い四角を移動させる
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
        }
        else
        {
            //黒い四角を移動させる
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);

        }
    }

}
