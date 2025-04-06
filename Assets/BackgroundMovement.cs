using System;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    private float startPosition,length;
    public GameObject camera;
    public float parallaxEffect;

    void Start()
    {
            startPosition=transform.position.x;
            length=GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float distance = camera.transform.position.x * parallaxEffect;
        float movement=camera.transform.position.x * (1-parallaxEffect);
        transform.position = new Vector3(startPosition + distance, transform.position.y, transform.position.z);
        if (movement > startPosition + length)
        {
            startPosition += length;
        }
        else if (movement < startPosition - length)
        {
            startPosition -= length;
        }
    }
}
