using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    bool isEggGoal;//卵が先にゴールしているか

    bool isCloneEggBreak;//弾の卵を消したか

    public bool isGoal;//ゴールしたか
    public bool isEggAnime;
    private Animator animator;
    private AudioSource audioSource;
    public AudioClip sound;
    public AudioClip sound2;

    int time;
    bool isLastGoal;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLastGoal && time == 0)
        {
            time++;
            isLastGoal = false;
            audioSource.PlayOneShot(sound);
        }
    }
        

  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerAction player;
        GameObject objP = GameObject.Find("Player");
        player = objP.GetComponent<PlayerAction>();

        //プレイヤーと卵が同時にゴールしたら
        if (collision.gameObject.tag == "Player" && player.isHave)
        {
            audioSource.PlayOneShot(sound);
        }

        if (collision.gameObject.name == "Egg(Clone)" && !player.isHave)
        {
            audioSource.PlayOneShot(sound2);
            
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        PlayerAction player;
        GameObject objP = GameObject.Find("Player");
        player = objP.GetComponent<PlayerAction>();

        animator.SetBool("isEgg", isEggAnime);//上向きアニメ

        //プレイヤーと卵が同時にゴールしたら
        if (collision.gameObject.tag == "Player" && player.isHave)
        {
            isGoal = true;
            
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
            isEggAnime = true;
            animator.SetBool("isEgg", isEggAnime);

            if (collision.gameObject.tag == "Player")
            {
                isGoal = true;
                isLastGoal = true;

            }
        }
    }

}
