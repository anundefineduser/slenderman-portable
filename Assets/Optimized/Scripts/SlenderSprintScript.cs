using UnityEngine;
using System.Collections;

public class SlenderSprintScript : MonoBehaviour
{
    [SerializeField] private CharacterMotor motor;
    [SerializeField] private CharacterController cc;
    [SerializeField] private new Transform transform;

    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float crouchSpeed = 1f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float jogSpeed = 3.5f;

    private float dist;

    private void Start()
    {
        dist = cc.height / 2f;
    }

    private void FixedUpdate()
    {
        float maxForwardSpeed = walkSpeed;
        if (Input.GetButton("Jog/Sprint") && motor.grounded) // view.stamina > 10f
            maxForwardSpeed = jogSpeed; // ((view.scared <= 0) ? jogSpeed : runSpeed);
        motor.movement.maxForwardSpeed = maxForwardSpeed;

        Vector3 localScale = transform.localScale;
        float y = localScale.y;
        Vector3 position = transform.position;
        localScale.y = Mathf.Lerp(transform.localScale.y, 1f, 5f * Time.deltaTime);
        transform.localScale = localScale;
        position.y += dist * (localScale.y - y);
        transform.position = position;
    }
}
