using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class playerController : MonoBehaviour
{
    public Animator anim;
    private Rigidbody rb;
    public LayerMask layerMask;
    public bool grounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Grounded();
        Jump();
        Move();
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            grounded = false; 
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z); 
            rb.AddForce(Vector3.up * 6f, ForceMode.Impulse); // Adjust force if needed
        }
    }


    private void Grounded()
    {
        if (Physics.CheckSphere(this.transform.position + Vector3.down, 0.2f, layerMask))
        {
            this.grounded = true;
        }
        else 
        {
            this.grounded = false;
        }

        this.anim.SetBool("jump", !this.grounded);
    }
    private void Move()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = (transform.forward * verticalAxis) + (transform.right * horizontalAxis);
        movement.Normalize();

        this.transform.position += movement * 0.04f;

        this.anim.SetFloat("vertical", verticalAxis);
        this.anim.SetFloat("Horizontal", horizontalAxis);
    }
}
