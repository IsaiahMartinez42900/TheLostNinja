using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public float characterCurrentHealth;
    public float characterHealth = 100f;
    private Animator anim;
    private NinjaAction ninjaMovement; //Reference to Ninja Movement script
    public bool PlayerLives = true;
    public WinLoseController WinLoseCheck;
    //public Image healthBar;

    void Start()
    {
        characterCurrentHealth = characterHealth;
        anim = GetComponent<Animator>();
        ninjaMovement = GetComponent<NinjaAction>();
        
    }

  
    public void TakeDamage(float damageAmount = 25f)
    {
        characterCurrentHealth -= damageAmount;
        
        anim.SetTrigger("NinjaHurt");
        if (characterCurrentHealth <= 0)
        {
            PlayerLives = false;
            WinLoseCheck.YouLose();

            if (ninjaMovement != null)
            {
                ninjaMovement.enabled = false;
            }
            BoxCollider2D ninjaCol = GetComponent<BoxCollider2D>();
            if (ninjaCol != null)
            {
                ninjaCol.enabled = false; 
            }
            Rigidbody2D blueninjaGrav = GetComponent<Rigidbody2D>();
            if (blueninjaGrav != null)
            {
                blueninjaGrav.simulated = false;
            }

            // Death animation
            anim.SetTrigger("NinjaDeath");
            Debug.Log("You lose");
        }
    }

    

}
