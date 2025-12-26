using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1f;
    public float amplitude = 1f;

    private float initialXPosition;

    void Start()
    {
        initialXPosition = transform.position.x;
    }

    void Update()
    {
        float xOffset = amplitude * Mathf.Sin(Time.time * speed);

        transform.position = new Vector3(initialXPosition + xOffset, transform.position.y, transform.position.z);
    }
}
