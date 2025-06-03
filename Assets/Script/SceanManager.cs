using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceanManager : MonoBehaviour
{
    public string stageName;//ステージセレクト時のステージの名前

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
            if (Input.GetKey(KeyCode.Z))
            {
                if (stageName == "Stage1")
                {
                    SceneManager.LoadScene("Stage1");
                }
                if (stageName == "Stage2")
                {
                    SceneManager.LoadScene("Stage2");
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
            //ステージの名前の初期化
            stageName = "";
        }
    }
}


