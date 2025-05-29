using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEggTakeAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyEggCatchAction eggCatch;
        GameObject obj = GameObject.FindWithTag("EggCatch");
        eggCatch = obj.GetComponent<EnemyEggCatchAction>();

        PlayerAction player;
        GameObject objP = GameObject.Find("Player");
        player = objP.GetComponent<PlayerAction>();

        //íDÇÌÇÍÇΩÇÁè¡Ç∑
        if (collision.gameObject.tag == "Player" &&  eggCatch.isHave&&!player.isEggMove)
        {
            eggCatch.isHave = false;
            player.isHave = true;
            player.isEggMove = true;
        }
    }
}
