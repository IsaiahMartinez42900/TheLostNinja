using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public float EnemycharacterCurrentHealth;
    public float EnemycharacterHealth = 100f;
    private Animator anim;
    private EnemyAction movement;
    private static int currentEnemies = 37; //37 is right number

    public Transform destination;
    private float winX = 557.73f; //150.56f;
    private bool hasWon = false;
    public WinLoseController checkWinLose;
    //public WinLoseController winlosecontroller;

    void Start()
    {
        EnemycharacterCurrentHealth = EnemycharacterHealth;
        anim = GetComponent<Animator>();
        movement = GetComponent<EnemyAction>();
       
        


    }
    void Update()
    {
        checkwinningCondition();
    }


    public void TakeDamage(float damageAmount = 35f)
    {
        EnemycharacterCurrentHealth -= damageAmount;
        anim.SetTrigger("WhiteNinjaHurt");
        anim.SetTrigger("RedNinjaHurt");
        
        if (EnemycharacterCurrentHealth <= 0)
        {
            currentEnemies--;
            
            
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
    public void checkwinningCondition()
    {
        if (hasWon) return;
        bool allenemiesDead = currentEnemies <= 0;
        bool reachedDestination = destination.position.x >= winX;
        if (allenemiesDead && reachedDestination)
        {
            hasWon = true;
            checkWinLose.YouWin();
        }

        
    }


}

