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
    private float lastJump;

    AudioSource jumpSound;

    public AudioSource loseSound;


    // Start is called before the first frame update
    void Start()
    {
        jumpSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s"))
        {
            ifCrouchKeyPressed = true;      //om s trycks ner är isCrouchKeyPressed true


        }
        else if (IsGrounded())
        {
            ifCrouchKeyPressed = false;     //Är man groundne blir crouchkeypressed false


        }

        if (Input.GetKeyDown(KeyCode.W))        //Om w trycks så blir IsCrouching false och ifJumpKeyPressed true
        {
            ifJumpKeyPressed = true;
            Debug.Log("Jumped");
            animator.SetBool("IsCrouching", false);

        }


    }
    void FixedUpdate()
    {





        if (ifJumpKeyPressed && IsGrounded())   //om w klickas och man är grounden så hoppar man,lastJump blir tiden som är och animationen byts
        {
            Debug.Log("Jumped");
            animator.SetBool("IsJumping", true);
            player.AddForce(Vector2.up * JumpHight, ForceMode2D.Impulse);
            ifJumpKeyPressed = false;
            jumpSound.Play();
            lastJump = Time.time;


        }



        if (ifCrouchKeyPressed)     //är det true så ökar gravitationen, hitboxen ändras och animationen ändras
        {

            player.gravityScale = CrouchForce;
            animator.SetBool("IsCrouching", true);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        }
        else if (!ifCrouchKeyPressed)   //är det false så blir gravitationen normal, animationen ändras och hitboxen ändras 
        {

            player.gravityScale = 3.0f;
            animator.SetBool("IsCrouching", false);
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

        }


    }

    public bool IsGrounded()
    {

        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);    //den är grounded ifall dinosauriens fötter träffar marken


        if (groundCheck != null && Time.time - 0.1f > lastJump) //om groundcheck stämmer och det gått 0.1s sen förra hoppet så är ändras animationen
        {
            animator.SetBool("IsJumping", false);

            Debug.Log("grounded" + groundCheck);
            return true;

        }
        return false;
    }

    void OnCollisionEnter2D(Collision2D col)    //Om dino springer in i ett hinder startas DinoHit funktionen
    {
        if (col.gameObject.tag.Equals("death"))
            DinoHit();
    }
    public void DinoHit()       //startar dinohit så fryser spelet och gameroverscenen kommer fram
    {
        Debug.Log("hit");
        Time.timeScale = 0;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameOverScene.SetActive(true);
        loseSound.Play();

    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);       //Startar om scenen
    }




}

