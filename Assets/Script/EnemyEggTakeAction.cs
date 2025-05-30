using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEggTakeAction : MonoBehaviour
{
    [SerializeField] EnemyEggCatchAction eggCatch;

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
        PlayerAction player;
        GameObject objP = GameObject.Find("Player");
        player = objP.GetComponent<PlayerAction>();

        
        //�v���C���[�ɓ������������������Ă��邩���̈ړ����\�Ȃ�
        //�v���C���[�ɗ��������
        if (collision.gameObject.tag == "Player" && eggCatch.isHave && !player.isEggMove)
        {
            eggCatch.isHave = false;
            player.isHave = true;
            player.isEggMove = true;
        }

    }
}
