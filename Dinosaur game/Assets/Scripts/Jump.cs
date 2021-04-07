using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public int JumpHight;
    private bool ifJumpKeyPressed;
    public Rigidbody2D player;

    // Start is called before the first frame update
    // void Start()
    // {

    // }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            ifJumpKeyPressed = true;
            Debug.Log("Jumped");
        }



        if (ifJumpKeyPressed)
        {
            Debug.Log("Jumped2");
            player.AddForce(Vector2.up * JumpHight, ForceMode2D.Impulse);
            ifJumpKeyPressed = false;
        }
    }


}

