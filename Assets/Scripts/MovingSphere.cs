using Unity.VisualScripting;
using UnityEngine;

public class MovingSphere : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
    float maxSpeed = 10f;

    [SerializeField, Range(0f, 100f)]
    float maxAcceleration = 10f;

    Vector3 velocity;

    [SerializeField]
    Rect allowedArea = new Rect(-5, -5, 10f, 10f);

    void Update()
    {
        Vector2 playerInput;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);
        Vector3 acceleration = 
            new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;
        Vector3 desiredVelocity =
            new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;
        float maxSpeedChange = maxAcceleration * Time.deltaTime;
        velocity.x =
            Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.z =
            Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);
        Vector3 displacement = velocity * Time.deltaTime;
        transform.localPosition += displacement;
    }
}
