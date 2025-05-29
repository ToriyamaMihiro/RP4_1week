using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEggCatchAction : MonoBehaviour
{
    // Start is called before the first frame update
    bool isEggHit;
    public bool isHave;

    [SerializeField] GameObject egg;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //判定が別なので、スクリプトをEnemyと分ける
        EggHave();//卵をキャッチする
    }

    void EggHave()
    {
        if (isHave)
        {
            //見かけ上の卵のsetActiveをtrueにする
            egg.SetActive(true);
        }

        else
        {
            egg.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        //もし飛ばされた卵なら消す
        if (collision.gameObject.name == "Egg(Clone)" && !isHave)
        {
            Destroy(collision.gameObject);
            isHave = true;
        }

        if (collision.gameObject.tag == "Player")
        {
            PlayerAction player;
            GameObject objP = GameObject.Find("Player");
            player = objP.GetComponent<PlayerAction>();
            //敵が持ってるときに取られる
            if (isHave && !player.isHave && !player.isEggMove)
            {
                isHave = false;
                player.isHave = true;
                player.isEggMove = true;
            }

            ////プレイヤーが持ってるときに奪う

            //if (player.isHave)
            //{
            //    player.isHave = false;
            //    isEggHit = true;
            //}

        }

    }
}
