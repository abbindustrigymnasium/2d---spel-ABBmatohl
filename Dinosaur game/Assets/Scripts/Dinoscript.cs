using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinoscript : MonoBehaviour
{
    public int JumpHight;
    private bool ifJumpKeyPressed;
    public Rigidbody2D player;
    public LayerMask groundLayers;
    public Transform feet;



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



        if (ifJumpKeyPressed && IsGrounded())
        {
            Debug.Log("Jumped2");
            player.AddForce(Vector2.up * JumpHight, ForceMode2D.Impulse);
            ifJumpKeyPressed = false;
        }


    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);
        Debug.Log(groundLayers);
        Debug.Log(feet.position);
        Debug.Log(groundCheck);

        if (groundCheck != null)
        {
            Debug.Log("grounded" + groundCheck);
            return true;
        }
        return false;
    }






}

