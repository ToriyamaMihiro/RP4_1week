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
        if (isHave)
        {
            //��������̗���setActive��true�ɂ���
            egg.SetActive(true);
        }

        else
        {
            egg.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        //������΂��ꂽ�������������Ă��Ȃ�������
        //��΂��ꂽ���������ė�������
        if (collision.gameObject.name == "Egg(Clone)" && !isHave)
        {
            Destroy(collision.gameObject);
            isHave = true;
        }

        ////�v���C���[�ɓ���������
        //if (collision.gameObject.tag == "Player")
        //{
        //    PlayerAction player;
        //    GameObject objP = GameObject.Find("Player");
        //    player = objP.GetComponent<PlayerAction>();

        //    //���������Ă��邩�v���C���[�͎����Ă��Ȃ��������ړ��\�Ȃ�
        //    //�����v���C���[�Ɏ����
        //    if (isHave && !player.isHave && !player.isEggMove)
        //    {
        //        isHave = false;
        //        player.isHave = true;
        //        player.isEggMove = true;
        //    }
        //}
    }
}
