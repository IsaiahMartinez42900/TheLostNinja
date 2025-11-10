//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    private float speed = 20.5f;
    public float direction;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.instance.PlaySounds(AudioManager.instance.shurikenThrow);
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = direction * speed * Time.deltaTime;
        transform.Translate(xMove, 0, 0);
        //transform.rotation = Quaternion.Euler(45, 0, 0);
        //transform.eulerAngles = new Vector3(45, 0, 0);
        transform.Rotate(30,0 * Time.deltaTime, 0);
        


}
    void OnCollisionEnter2D(Collision2D collision)
    {


        if ((collision.gameObject.CompareTag("EnemyNinja")))
        {
            //audiosource.PlayOneShot(shurikenImpact);
            Destroy(gameObject); //Destroys shuriken
            Destroy(collision.gameObject); //Destroys enemyninja
            AudioManager.instance.PlaySounds(AudioManager.instance.shurikenImpact);



        }
        if ((collision.gameObject.CompareTag("Character")))
        {
           // audiosource.PlayOneShot(shurikenImpact);
            Destroy(gameObject); //Destroys shuriken
            AudioManager.instance.PlaySounds(AudioManager.instance.shurikenImpact);
        }

    }

}
