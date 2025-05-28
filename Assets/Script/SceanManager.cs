using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceanManager : MonoBehaviour
{
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

    }
}
