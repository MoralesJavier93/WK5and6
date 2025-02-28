using UnityEngine;

public class characterMovements : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float jumpForce = 1;
    [SerializeField] float gravity = 1;

    CharacterController controller;

    Vector3 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        movement.x = xInput * speed * Time.deltaTime;
        movement.y = yInput * speed * Time.deltaTime;
    }
}
