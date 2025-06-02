using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScanChangeAction : MonoBehaviour
{
    float speed = 12f;
    Vector2 target = new Vector2(0,0);

    bool isStart;

    // Start is called before the first frame update
    void Start()
    {
        isStart = true;
    }

    // Update is called once per frame
    void Update()
    {

        GoalManager player;
        GameObject obj = GameObject.Find("Goal");
        player = obj.GetComponent<GoalManager>();



        //ƒS[ƒ‹‚µ‚½‚ç
        if (player.isGoal)
        {
            //•‚¢lŠp‚ğˆÚ“®‚³‚¹‚é
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            //2•bŒã‚ÉƒV[ƒ“ˆÚ“®
            Invoke("SceanLoad", 1.8f);

        }
    }

    void SceanLoad()
    {
        int nowSceneIndexNumber = SceneManager.GetActiveScene().buildIndex;

        //ƒV[ƒ“‘JˆÚ
        nowSceneIndexNumber = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(++nowSceneIndexNumber);
    }
}
