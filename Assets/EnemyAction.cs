using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    public float enemySpeed = 5f;
    public float Direction = -1f;
    public float walkTimer = 0f;
    public float walkCooldown = 1.5f;
    //public float stopCooldown = 1f;
    //public float stopTimer = 0f;
    private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
       
    }

    
    void Update()
    {
        
        walkTimer += Time.deltaTime;
        transform.Translate(enemySpeed * Time.deltaTime * Direction, 0, 0);
        if(walkTimer >= walkCooldown)
        {
            Direction *= -1f;
            walkTimer = 0f;    
            
        }
        //Trying to make a stop delay after moving to one side
        /*if(walkTimer == 0f)
        {
            stopTimer += Time.deltaTime;
        }
        if(stopTimer >= stopCooldown)
        {
            walkTimer = 0f;
        }
        */
    }
    
    
}
