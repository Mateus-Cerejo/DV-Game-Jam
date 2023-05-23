using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer pointerArrow;
    [SerializeField] private float force = 200;
    [SerializeField] Image forceBar;

    [SerializeField]
    private PhysicsMaterial2D icePhysicMaterial;

    private PhysicsMaterial2D defaultPhysicMaterial;

    private Rigidbody2D rb;
    float mouseDistance;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        defaultPhysicMaterial = rb.sharedMaterial;
        mouseDistance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude < 0.15)
        {
            if (GetComponent<PlayerScore>().ReachedMaxStrokes() && !GetComponent<PlayerScore>().hasWon() && rb.velocity.magnitude > 0)
            {
                GetComponent<PlayerHealth>().takeDamage(int.MaxValue);
            }
            rb.velocity = Vector2.zero;

        }
    }

    private void OnMouseDrag()
    {
        if (rb.velocity.magnitude == 0)
        {
            Vector3 mousePositionSTWP = updateDirection();
            updateMouseDistance(mousePositionSTWP);
            pointerArrow.enabled = true;
            forceBar.fillAmount = mouseDistance;
        }
    }


    private void OnMouseUp()
    {
        if (rb.velocity.magnitude == 0)
        {
            GameObject.FindAnyObjectByType<PlayerStats>().LockStats();
            Vector3 mousePositionSTWP = updateDirection();
            updateMouseDistance(mousePositionSTWP);
            forceBar.fillAmount = 0;
            pointerArrow.enabled = false;
            rb.AddForce(transform.up * mouseDistance * force);
            GetComponent<PlayerScore>().IncStrokes();
        }
    }

    private void updateMouseDistance(Vector3 mousePositionSTWP)
    {
        mouseDistance = Vector2.Distance(transform.position, mousePositionSTWP) / 3f;
        mouseDistance = Mathf.Clamp01(mouseDistance);
    }

    private Vector3 updateDirection()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 mousePositionSTWP = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
           -(mousePositionSTWP.x - transform.position.x),
           -(mousePositionSTWP.y - transform.position.y)
        );

        transform.up = direction;

        return mousePositionSTWP;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Slippery")
        {
            rb.sharedMaterial = icePhysicMaterial;  
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Slippery")
        {
            rb.sharedMaterial = defaultPhysicMaterial;
        }
    }

    public void SetForce(float newForce) { force = newForce; }
    public void SetSize(float sizeFactor) { transform.localScale = new Vector3(sizeFactor, sizeFactor); }
}
