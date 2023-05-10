using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody rb;
    public float ImpulseForce = 3f;

    private bool IgnoreNextcollision;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)

        {
            if (IgnoreNextcollision)
            {
                return;
            }

            DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
            if (deathPart)
            {
                GameManager.singleton.RestartLevel();
            }

        
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up*ImpulseForce, ForceMode.Impulse);

        IgnoreNextcollision = true;
        Invoke("AllowNextCollision", 0.2f);
    }

    private void AllowNextCollision()
    {
        IgnoreNextcollision = false;
    }

    public void ResetBall()
    {
        transform.position = startPosition;
    }
}
