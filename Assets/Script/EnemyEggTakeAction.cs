using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEggTakeAction : MonoBehaviour
{
    [SerializeField] EnemyEggCatchAction linkedEgg;

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
        //GameObject obj = GameObject.FindWithTag("EggCatch");
        //EnemyEggCatchAction eggCatch = obj.GetComponent<EnemyEggCatchAction>();

        PlayerAction player;
        GameObject objP = GameObject.Find("Player");
        player = objP.GetComponent<PlayerAction>();

        //ÉvÉåÉCÉÑÅ[Ç…ìñÇΩÇ¡ÇΩÇÁéÊÇÁÇÍÇÈ
        if (collision.gameObject.tag == "Player" && linkedEgg.isHave && !player.isEggMove)
        {
            linkedEgg.isHave = false;
            player.isHave = true;
            player.isEggMove = true;
        }
    }
}
