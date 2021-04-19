using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdcactus : MonoBehaviour
{
    public float moveSpeed;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + moveSpeed + Time.deltaTime,
        transform.position.y);//rör föremålet åt vänster

        if (transform.position.x < -13f)
            Destroy(gameObject);
    }

}
