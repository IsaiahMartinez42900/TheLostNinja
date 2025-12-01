using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    public Camera maincamera;
    public float yOffset;
    public Transform playersPositioning;
    private float followAfterStart = -14.59f;
    private float stopFollowing = 547.77f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maincamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Position(Vector2.right * CameraSpeed * Time.deltaTime);
        if (playersPositioning.position.x >= followAfterStart && playersPositioning.position.x <= stopFollowing)
        {
            maincamera.transform.position = new Vector3(transform.position.x, maincamera.transform.position.y, maincamera.transform.position.z);
            

        }
        if (playersPositioning.position.x > stopFollowing)
        {
            maincamera.transform.position = new Vector3(stopFollowing, maincamera.transform.position.y, maincamera.transform.position.z);
            
        }

    }
}
