using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 moving;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moving = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Camera.main.transform.position = player.transform.position + moving;
    }
}