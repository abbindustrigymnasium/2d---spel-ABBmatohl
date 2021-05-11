using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class birdcactus : MonoBehaviour
{
    public float moveSpeed;
    public Transform Dino;







    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime,
        transform.position.y);//rör föremålet åt vänster

        if (transform.position.x < -18f)
            Destroy(gameObject);    //om föremålet är tillräckligt långt åt vänster förstörs det(förhindrar lag)




    }


}
