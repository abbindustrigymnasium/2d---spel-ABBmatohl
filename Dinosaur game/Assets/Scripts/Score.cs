using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text HighScoreCounterText;
    int score;
    Text scoreText;

    float timer;

    float maxTime;

    AudioSource pointSound;
    // Start is called before the first frame update
    void Start()
    {
        HighScoreCounterText.text = "HI   " + PlayerPrefs.GetInt("highscore", 0).ToString("00000"); //texten med highscore text är det högsta scoret som någonsin uppmätts
        score = 0;
        scoreText = GetComponent<Text>();
        maxTime = 0.1f; //maxtime är 0.1s

        pointSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTime)       //om det gått 0.1s så blir scoret 1 mer och scoretexten uppdateras
        {
            score++;
            scoreText.text = score.ToString("00000");
            timer = 0;
        }

        if (Time.timeScale == 0)        //Om spelet slutar
        {
            if (score > PlayerPrefs.GetInt("highscore", 0))     //Uppdatera highscore ifall score>highscore
            {

                PlayerPrefs.SetInt("highscore", score); //Ändrar highscoret till ens score
                HighScoreCounterText.text = "HI   " + PlayerPrefs.GetInt("highscore", 0).ToString("00000");//Uppdaterar textrutan
            }

        }

        if (score % 100 == 0 && score != 0)       //Om score/100 inte har någon decimal
        {
            pointSound.Play();
        }
    }
}
