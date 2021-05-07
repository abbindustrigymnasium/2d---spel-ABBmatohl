using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    public GameObject GameOverScene;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void DinoHit()
    {
        Debug.Log("hit");
        Time.timeScale = 0;
        GameOverScene.SetActive(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
