using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipperyMovement : MonoBehaviour
{
    [SerializeField]
    private PhysicsMaterial2D slipperyMaterial;

    private PhysicsMaterial2D playerPhysicsMat;
    private Rigidbody2D playerRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerRigidBody = collision.gameObject.GetComponent<Rigidbody2D>();
            playerPhysicsMat = playerRigidBody.sharedMaterial;

            playerRigidBody.sharedMaterial = slipperyMaterial;
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerRigidBody.sharedMaterial = playerPhysicsMat;
        }
        
    }
}
