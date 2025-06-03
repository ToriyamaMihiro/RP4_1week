using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceanManager : MonoBehaviour
{
    public string stageName;//ステージセレクト時のステージの名前
    public bool isToutch;
    public bool isStop;

    // Start is called before the first frame update
    void Start()
    {

    }

    void NextScene()
    {
        SceneManager.LoadScene(stageName);
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

        if (SceneManager.GetActiveScene().name == "Title")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("StageSelect");
            }
        }

            if (SceneManager.GetActiveScene().name == "StageSelect")
        {
            //触っているステージの入口に応じてシーンをロード
            if (Input.GetKey(KeyCode.Z) && isToutch)
            {
                

                if (stageName == "Stage1")
                {
                    isStop = true;
                    Invoke("NextScene", 1.8f);
                }
                if (stageName == "Stage2")
                {
                    isStop = true;
                    Invoke("NextScene", 1.8f);
                }
                if (stageName == "Stage3")
                {
                    isStop = true;
                    Invoke("NextScene", 1.8f);
                }
                if (stageName == "Stage4")
                {
                    isStop = true;
                    Invoke("NextScene", 1.8f);
                }
                if (stageName == "Stage5")
                {
                    isStop = true;
                    Invoke("NextScene", 1.8f);
                }
            }

        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stage")
        {
            stageName = collision.gameObject.name;
            isToutch = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stage")
        {
            //ステージの名前の初期化
            //stageName = "";
            isToutch = false;
        }
    }
}


