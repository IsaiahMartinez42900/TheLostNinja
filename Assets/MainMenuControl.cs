using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuControl : MonoBehaviour
{
    public GameObject mainMenu;
    //public SpriteRenderer Spriterenderer;
    //private Color white;
    void Start()
    {
        mainMenu.SetActive(true);
        Time.timeScale = 0;

    }

   public void OnPointerClick()
    {
        mainMenu.SetActive(false);
        Debug.Log("click");
        Time.timeScale = 1;

    }
   
}
