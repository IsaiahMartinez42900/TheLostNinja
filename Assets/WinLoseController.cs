using UnityEngine;
using UnityEngine.Rendering;

public class WinLoseController : MonoBehaviour
{
    
    void Start()
    {
       
    }

    // Update is called once per frame
    public void YouWin()
    {
        
        Debug.Log("You Win");
    }
    public void YouLose()
    {
        Debug.Log("You Lose");
    }
}
