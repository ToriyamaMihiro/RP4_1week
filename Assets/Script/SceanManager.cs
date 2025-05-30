using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceanManager : MonoBehaviour
{
    public string stageName;//�X�e�[�W�Z���N�g���̃X�e�[�W�̖��O

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int nowSceneIndexNumber = SceneManager.GetActiveScene().buildIndex;

        if (Input.GetKeyDown(KeyCode.R))
        {
            nowSceneIndexNumber = SceneManager.GetActiveScene().buildIndex;

            SceneManager.LoadScene(nowSceneIndexNumber);
        }

        if (SceneManager.GetActiveScene().name == "StageSelect")
        {
            //�G���Ă���X�e�[�W�̓����ɉ����ăV�[�������[�h
            if (Input.GetKey(KeyCode.Z))
            {
                if (stageName == "Stage1")
                {
                    SceneManager.LoadScene("GameScene");
                }
                if (stageName == "Stage2")
                {
                    SceneManager.LoadScene("TestPlayer");
                }
                if (stageName == "Stage3")
                {
                    SceneManager.LoadScene("Test");
                }
            }

        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stage")
        {
            stageName = collision.gameObject.name;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stage")
        {
            //�X�e�[�W�̖��O�̏�����
            stageName = "";
        }
    }
}


