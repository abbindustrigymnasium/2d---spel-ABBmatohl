using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour

{
    public GameObject[] obstacles;      //array med alla hinder
    float lastTime;
    float timeBetween = 1.5f;       //1,5s mellan tiden då objekt kan spawnas
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float r = Random.Range(0f, 1f);     //r är ett tal mellan 0 och 1
        //Debug.Log(r + "random num");
        if (Time.time % timeBetween == 0 && r < 0.75f)      //Varje 1,5s finns det 75% chans att spawna
        {

            //Debug.Log("obstacle");
            GameObject newObstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length)]);     //skapar ett random hinder från arrayen obstacles

            lastTime = Time.time;   //ändrar lasttime till den nuvarande tiden
        }


    }
}
