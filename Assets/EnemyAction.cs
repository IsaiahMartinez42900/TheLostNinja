using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    public float enemySpeed = 5f;
    private float currentEnemySpeed; //New Line
    public float Direction = -1f;
    public float walkTimer = 0f;
    public float walkCooldown = 1.5f;
    public float stopCooldown = 5f;
    public float stopTimer = 0f;

    public float detectRange = 5f;
    public Transform player;
    private Animator anim;
    public GameObject shurikenPrefab;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentEnemySpeed = enemySpeed;
       
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
                
            
        }
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance < detectRange)
        {
            //GameObject s = Instantiate(shurikenPrefab, transform.position, transform.rotation);
            //s.GetComponent<Shuriken>().direction = direction;
            Debug.Log("Kill Him");

        }
        
            
        

    }
    
    
}
