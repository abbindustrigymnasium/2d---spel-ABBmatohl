using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Dinoscript : MonoBehaviour
{
    public int JumpHight;
    public int CrouchForce;
    private bool ifJumpKeyPressed;
    private bool ifCrouchKeyPressed;
    public Rigidbody2D player;
    public LayerMask groundLayers;
    public Transform feet;
    public Animator animator;
    public GameObject GameOverScene;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s"))
        {
            ifCrouchKeyPressed = true;
            Debug.Log("6");

        }
        else if (IsGrounded())
        {
            ifCrouchKeyPressed = false;
            Debug.Log("3");

        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ifJumpKeyPressed = true;
            Debug.Log("Jumped");
            animator.SetBool("IsCrouching", false);

        }


    }
    void FixedUpdate()
    {





        if (ifJumpKeyPressed && IsGrounded())
        {
            Debug.Log("Jumped");

            player.AddForce(Vector2.up * JumpHight, ForceMode2D.Impulse);
            ifJumpKeyPressed = false;


        }



        if (ifCrouchKeyPressed)
        {

            player.gravityScale = CrouchForce;
            animator.SetBool("IsCrouching", true);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        }
        else if (!ifCrouchKeyPressed)
        {

            player.gravityScale = 3.0f;
            animator.SetBool("IsCrouching", false);
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

        }


    }

    public bool IsGrounded()
    {

        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);


        if (groundCheck != null)
        {
            Debug.Log("grounded" + groundCheck);
            return true;
        }
        return false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("death"))
            DinoHit();
    }
    public void DinoHit()
    {
        Debug.Log("hit");
        Time.timeScale = 0;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameOverScene.SetActive(true);
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }




}

