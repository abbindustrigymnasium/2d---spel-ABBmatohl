using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class birdcactus : MonoBehaviour
{
    public float moveSpeed;
    public Transform Dino;



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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Dino"))
            DinoHit();
    }
    public void DinoHit()
    {
        Debug.Log("hit");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
