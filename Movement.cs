using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float AngleSpeed = 0.75f;
    public float angle;
    private Animator anim;
     

    public float speed = 6f;
    
    public float turnSmoothTme = 0.1f;
    float turnSmoothVelocity;
    public Vector3 direction;

    void start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        var direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
           this.direction = Vector3.Lerp(direction, this.direction, AngleSpeed);
            transform.LookAt(transform.position + this.direction);

            transform.position += this.direction * speed * Time.deltaTime;
        }
    }
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.y = Terrain.activeTerrain.SampleHeight(transform.position);
        transform.position = pos;
    }
}