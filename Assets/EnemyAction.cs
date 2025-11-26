using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    public float enemySpeed = 5f;
    private float currentEnemySpeed; 
    public float Direction = -1f;
    public float walkTimer = 0f;
    public float walkCooldown = 1.5f;
    public float stopCooldown = 5f;
    public float stopTimer = 0f;

    public float detectRange = 5f;

    public int maxShurikens = 1;
    public int currentShurikens = 0;
    public float shurikenTimer = 0f;
    public float shurikenCooldown = 1f;

    private bool facedDirectionThrow;

    public Transform player;
    private Animator anim;
    public GameObject shurikenPrefab;
    public SpriteRenderer enemySpriteRenderer;
    private LayerMask layerMask; //new line

    void Start()
    {
        currentShurikens = maxShurikens;
        anim = GetComponent<Animator>();
        currentEnemySpeed = enemySpeed;
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
        enemySpriteRenderer.flipX = false;
        layerMask = LayerMask.GetMask("Character"); //new line

    }

    
    void Update()
    {
        
        walkTimer += Time.deltaTime;
        transform.Translate(currentEnemySpeed * Time.deltaTime * Direction, 0, 0);
        anim.SetBool("Walk", true);
        if (walkTimer >= walkCooldown)
        {
            anim.SetBool("Walk", false);
            currentEnemySpeed = 0;
            if(stopTimer < stopCooldown)
            {
                stopTimer += Time.deltaTime;
                 
            }
            else
            {
                Direction *= -1f;
                walkTimer = 0f;
                currentEnemySpeed = enemySpeed;
                stopTimer = 0;
                
                
            }
            if (Direction < 0f)
            {
                enemySpriteRenderer.flipX = true;
            } else
            {
                enemySpriteRenderer.flipX = false;
            }
                
            
        }

        if (shurikenTimer > 0f)
        {
            shurikenTimer -= Time.deltaTime;
        }
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= detectRange && currentShurikens > 0 && shurikenTimer <= 0f)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            // Trying to have enemies shoot player if they face his direction
            
            var hits = Physics2D.RaycastAll(transform.position + Vector3.up * 1.3f, transform.right * Direction, detectRange, layerMask); //new line
            if (hits.Length > 0) //new line                                                               
            {
                GameObject s = Instantiate(shurikenPrefab, transform.position + Vector3.up * 1.3f, transform.rotation);
                s.GetComponent<Shuriken>().direction = Direction;
                currentShurikens--;
                shurikenTimer = shurikenCooldown;
                Debug.Log("Kill Him");
                Debug.Log("Enemy shuriken" + Direction);
                anim.SetTrigger("ShurikenThrow");
            }
                
           
            
           
            

        }

        if (currentShurikens < maxShurikens && shurikenTimer <= 0f)
        {
            currentShurikens++;
            shurikenTimer = shurikenCooldown;
            //anim.SetTrigger("ShurikenThrow");

        }




    }
    
    
}
