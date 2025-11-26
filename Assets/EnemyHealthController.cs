using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public float EnemycharacterCurrentHealth;
    public float EnemycharacterHealth = 100f;
    private Animator anim;
    private EnemyAction movement;
    public static int currentEnemies = 3; //37 is right number
    
    public WinLoseController checkWinLose; 

    void Start()
    {
        EnemycharacterCurrentHealth = EnemycharacterHealth;
        anim = GetComponent<Animator>();
        movement = GetComponent<EnemyAction>();
       
        


    }


    public void TakeDamage(float damageAmount = 35f)
    {
        EnemycharacterCurrentHealth -= damageAmount;
        anim.SetTrigger("WhiteNinjaHurt");
        anim.SetTrigger("RedNinjaHurt");
        
        if (EnemycharacterCurrentHealth <= 0)
        {
            currentEnemies--;
            
            if (currentEnemies <= 0)
            {
                Debug.Log("AllDead");
                checkWinLose.YouWin();
            }
            if (movement != null)
            {
                movement.enabled = false;
                BoxCollider2D col = GetComponent<BoxCollider2D>();
                if (col != null)
                {
                    col.enabled = false;
                }
                Rigidbody2D ninjaGrav = GetComponent<Rigidbody2D>();
                if (ninjaGrav != null)
                {
                    ninjaGrav.simulated = false;
                }
                
            }
            // Death animation
            
            anim.SetTrigger("RedNinjaDeath");
            anim.SetTrigger("WhiteNinjaDeath");
            Debug.Log("EnemyDeath");
        }
    }



}

