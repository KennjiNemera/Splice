using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        //Store camera's temporary position in a Vector because it cant be modified directly
        Vector3 temp = transform.position;

        //set temp camera values to the values received from the Player Game Object
        temp.x = playerTransform.position.x;
        temp.y = playerTransform.position.y;

        transform.position = temp;

    }
}
