using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource audiosource;
    public AudioClip shurikenImpact;
    public AudioClip shurikenThrow;
    public AudioClip NinjaJump;
    public AudioClip gameMusic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (gameMusic !=null)
        {
            audiosource.clip = gameMusic;
            audiosource.Play();
            audiosource.loop = true;
        }
       
    }

    // Update is called once per frame
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        audiosource = GetComponent<AudioSource>();
    }
    public void PlaySounds(AudioClip clip)
    {
        audiosource.PlayOneShot(clip);
    }
}
