using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    bool isEggGoal;//卵が先にゴールしているか

    bool isCloneEggBreak;//弾の卵を消したか

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        PlayerAction player;
        GameObject objP = GameObject.Find("Player");
        player = objP.GetComponent<PlayerAction>();

        int nowSceneIndexNumber = SceneManager.GetActiveScene().buildIndex;

        //プレイヤーと卵が同時にゴールしたら
        if (collision.gameObject.tag == "Player" && player.isHave)
        {
            //シーン遷移
            nowSceneIndexNumber = SceneManager.GetActiveScene().buildIndex;

            SceneManager.LoadScene("TestPlayer");

        }

        //卵が先にゴールしてプレイヤーが後からゴールしたら
        if (collision.gameObject.name == "Egg(Clone)" && !player.isHave || isEggGoal)
        {
            if (!isCloneEggBreak)
            {
                Destroy(collision.gameObject);
                isCloneEggBreak = true;
            }
            isEggGoal = true;
            //卵が先に入っているリソースに切り替える

            if (collision.gameObject.tag == "Player")
            {
                //シーン遷移
                nowSceneIndexNumber = SceneManager.GetActiveScene().buildIndex;

                SceneManager.LoadScene("GameScene");
            }
        }
    }

}
