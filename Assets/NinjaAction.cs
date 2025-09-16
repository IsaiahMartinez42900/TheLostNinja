using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditorInternal.ReorderableList;

public class NinjaAction : MonoBehaviour
{

    //public float speed = 15.5f;
    private Rigidbody2D rb;
    public float characterRunSpeed = 9.0f;
    public float characterWalkSpeed = 6.0f;
    public float shurikenSpeed = 15.0f;
    private bool hasLaunched = false;
    private bool isCharacter = false;
    private bool isShuriken = false;
    public float jumpForce = 10f;
    private bool isGrounded;
    public float direction = 1;

    private Animator anim;

     public GameObject shurikenPrefab;
    //public Transform shurikenSpawnPoint;
    //public int shurikenCount = 3;

    void Start()
    {
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

            float move = 0f;
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
        /*if (Input.GetKey(KeyCode.D))
        {

            transform.Translate(Vector2.right * characterSpeed * Time.deltaTime);
            // transform.localScale = new Vector3(1, 1, 1);
            int direction = 1;
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * direction;
            transform.localScale = scale;
            anim.SetBool("Walk", true);
        }
         else if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Run", true);
            anim.SetBool("Walk", false);
        }
        else
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
        }

         if (Input.GetKey(KeyCode.A))
        {

            transform.Translate(Vector2.left * characterSpeed * Time.deltaTime);
            //transform.localScale = new Vector3(-1, 1, 1);
            int direction = -1;
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * direction;
            transform.localScale = scale;
            anim.SetBool("Walk", true);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Run", true);
            anim.SetBool("Walk", false);
        }
        else
        {
             //anim.SetBool("Walk", true);
            anim.SetBool("Run", false);
            anim.SetBool("Walk", false);
        }*/





        if (isShuriken)
        {
            // Shuriken movement
            if (Input.GetKeyDown(KeyCode.Space) && !hasLaunched) //&& shurikenCount > 0)
            {

                hasLaunched = true;
               GameObject shuriken = Instantiate(shurikenPrefab, transform.position, transform.rotation);
                Rigidbody2D rb = shuriken.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                   // transform.Translate(Vector2.right * shurikenSpeed * Time.deltaTime);
                    rb.AddForce(transform.right * shurikenSpeed, ForceMode2D.Impulse);
                }
               // shurikenCount--;
               // Instantiate(bullet, spawnPoint.position, Quaternion.identity);

            }
           // if (hasLaunched)
           // {

                //Rigidbody2D rb = shurikenPrefab.GetComponent<Rigidbody2D>();
               // if (rb != null)
               // { 
                //transform.Translate(Vector2.right * shurikenSpeed * Time.deltaTime);
               // }

            //}

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

            string myTag = this.tag;

            if ((myTag == "CharacterShuriken" && collision.gameObject.CompareTag("EnemyNinja")))
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);

            }
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
                anim.SetBool("Jump", false);
            }
        }
    }

