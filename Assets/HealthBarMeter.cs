//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarMeter : MonoBehaviour
{
    public HealthController refcharacterHealth; 
    public Image healthBar;
    void Start()
    {
       //refcharacterHealth = GetComponent<HealthController>();
    }

    // Update is called once per frame
     void Update()
    {
        //fillAmount = currenHealth / maxhealth;
        if (refcharacterHealth != null) 
        {
            healthBar.fillAmount = refcharacterHealth.characterCurrentHealth / refcharacterHealth.characterHealth;
            //TakeDamage();
        }
        
    }
}
