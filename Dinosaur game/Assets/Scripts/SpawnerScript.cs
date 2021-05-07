using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour

{
    public GameObject[] obstacles;
    float lastTime;
    float timeBetween = 1.5f;
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
        float r = Random.Range(0f, 1f);
        Debug.Log(r + "random num");
        if (Time.time >= lastTime + timeBetween && r < 0.1f)
        {

            Debug.Log("obstacle");
            GameObject newObstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length)]);

            lastTime = Time.time;
        }


    }
}
