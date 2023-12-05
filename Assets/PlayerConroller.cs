using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerConroller : MonoBehaviour
{
    public Animator anim;
    private Rigidbody rb;
    public LayerMask layerMask;
    public bool grounded;
    // Start is called before the first frame update
    void Start()
    {
     this.rb=GetComponent<Rigidbody>();   
    }

    private void Update()
    {
        Grounded();
        Jump();
        Move();
    }
    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& this.grounded) 
        {
            this.rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }  
    }
    private void Grounded()
    {
        if(Physics.CheckSphere(this.transform.position+Vector3.down,0.2f,layerMask))
        {
            this.grounded = true;
        }
        else
        {
            this.grounded=false;
        }
        this.anim.SetBool("jump",!this.grounded);
    }
    private void Move()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movment = this.transform.forward*verticalAxis+this.transform.right * horizontalAxis;
        movment.Normalize();

        this.transform.position += movment*0.004f;

        this.anim.SetFloat("vertical", verticalAxis);
        this.anim.SetFloat("horizontal", horizontalAxis);
    }
}
