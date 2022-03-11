using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{

    [SerializeField] ParticleSystem DustParticles;

    private void OnCollisionExit2D(Collision2D collisionedone)
    {
        if(collisionedone.gameObject.tag == "Surface")
        {
            DustParticles.Stop();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Surface")
        {
            DustParticles.Play();
            FindObjectOfType<PlayerController>().AirControls();
        }
    }

}
