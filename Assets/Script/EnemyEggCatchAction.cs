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
        if (isEggHit)
        {
            //見かけ上の卵のsetActiveをtrueにする
            egg.SetActive(true);
            isHave = true;
            isEggHit = false;
        }

        if (!isHave)
        {
            egg.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Egg" && !isHave)
        {
            isEggHit = true;

            //もし飛ばされた卵なら消す
            if (collision.gameObject.name == "Egg(Clone)")
            {
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "Player")
        {
            PlayerAction player;
            GameObject objP = GameObject.Find("Player");
            player = objP.GetComponent<PlayerAction>();
            //敵が持ってるときに取られる
            if (isHave && !player.isHave)
            {
                isHave = false;
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
