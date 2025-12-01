using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class WinLoseController : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject winState;
    public GameObject loseState;
   // public MainMenuControl switchtoMenu;
    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    public void YouWin()
    {       
        Debug.Log("You Win");
        winScreen.SetActive(true);
        //Time.timeScale = 0;
    }
    public void YouLose()
    {
        Debug.Log("You Lose");
        loseScreen.SetActive(true);
        //Time.timeScale = 0;
    }
    public void OnPointerClick()
    {
       // switchtoMenu.mainMenu.SetActive(true);
        //if (OnPointerClick != null)
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //Time.timeScale = 1;

    }
}
