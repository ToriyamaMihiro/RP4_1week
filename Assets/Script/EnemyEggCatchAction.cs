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
        //���肪�ʂȂ̂ŁA�X�N���v�g��Enemy�ƕ�����
        EggHave();//�����L���b�`����
    }

    void EggHave()
    {
        if (isEggHit)
        {
            //��������̗���setActive��true�ɂ���
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

            //������΂��ꂽ���Ȃ����
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
            //�G�������Ă�Ƃ��Ɏ����
            if (isHave && !player.isHave)
            {
                isHave = false;
            }

            ////�v���C���[�������Ă�Ƃ��ɒD��

            //if (player.isHave)
            //{
            //    player.isHave = false;
            //    isEggHit = true;
            //}

        }

    }
}
