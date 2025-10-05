using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    public Camera maincamera;
    public float yOffset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maincamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Position(Vector2.right * CameraSpeed * Time.deltaTime);
        maincamera.transform.position = new Vector3(transform.position.x, maincamera.transform.position.y, maincamera.transform.position.z);
    }
}
