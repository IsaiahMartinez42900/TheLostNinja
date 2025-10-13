using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditorInternal.ReorderableList;

public class NinjaAction : MonoBehaviour
{  
    private Rigidbody2D rb;
    public float characterRunSpeed = 7.5f;
    public float characterWalkSpeed = 5.0f;

    public float shurikenSpeed = 15.0f;
    private bool hasLaunched = false;
    private bool isCharacter = false;
    private bool isShuriken = false;

    public float jumpForce = 10f;
    private bool isGrounded;
    public float direction = 1;
    private float move;

    private float shurikenTimer = 0f;
    private float shurikenCooldown = 1.5f;
    public int maxShurikens = 4;
    private int currentShurikens;

    //private int shurikenCounter = 0;
   // private float cooldownTimer = 0f;
    //private bool isOnCooldown;
    

    private Animator anim;
    public GameObject shurikenPrefab;
    
    void Start()
    {
        currentShurikens = maxShurikens;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (this.CompareTag("Character"))
        {
            isCharacter = true;

        }
        else if (this.CompareTag("CharacterShuriken"))
        {
            isCharacter = false;
            isShuriken = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isCharacter)
        {

            //Character movement

            //float move = 0f;
            int direction = 1;
            if (Input.GetKey(KeyCode.D))
            {
                move = 1f;
                direction = 1;

            }
            else if (Input.GetKey(KeyCode.A))
            {
                move = -1f;
                direction = -1;

            }
            else
            {
                move = 0;
            }
            if (move != 0f)
            {

                transform.Translate(Vector2.right * move * characterWalkSpeed * Time.deltaTime);

                Vector3 scale = transform.localScale;
                scale.x = Mathf.Abs(scale.x) * direction;
                transform.localScale = scale;

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    transform.Translate(Vector2.right * move * characterRunSpeed * Time.deltaTime);
                    anim.SetBool("Run", true);
                    anim.SetBool("Walk", false);
                }
                else
                {
                    anim.SetBool("Walk", true);
                    anim.SetBool("Run", false);
                }
            }
            else
            {
                anim.SetBool("Walk", false);
                anim.SetBool("Run", false);

            }
        }

      // HELP NEEDED
       /* if (isOnCooldown)
        {
            shurikenTimer -= Time.deltaTime;
            if (shurikenTimer <= 0f)
            {
                isOnCooldown = false;
                currentShurikens = maxShurikens;
            }
        }*/
       if (currentShurikens < maxShurikens)
        {
            if (shurikenTimer < shurikenCooldown)
            {
                shurikenTimer += Time.deltaTime;

            }
            else
            {
                shurikenTimer = 0;
                currentShurikens++;
            }

        }
 
        if (Input.GetKeyDown(KeyCode.Space) && currentShurikens > 0) //&& !isOnCooldown)
            {
           // anim.SetTrigger("ShurikenThrow");
            anim.SetBool("ShurikenThrow", true);

            //hasLaunched = true;
            GameObject s = Instantiate(shurikenPrefab, transform.position, transform.rotation);
               s.GetComponent<Shuriken>().direction = direction;
           // shurikenTimer = shurikenCooldown;
    
            currentShurikens--;
             /*if (currentShurikens <= 3)
            {
                isOnCooldown = true;
                shurikenTimer = 3f;
            }   */     
            } 
        




        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            anim.SetBool("Jump", true);
            Debug.Log("jumped");

        }
    }



        void OnCollisionEnter2D(Collision2D collision)
        {


            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
                anim.SetBool("Jump", false);
            }
        }
    }

