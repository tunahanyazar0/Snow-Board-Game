using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDeetect : MonoBehaviour
{
    [SerializeField] float Delay = 0.5f;
    [SerializeField] ParticleSystem crasheffect;
    [SerializeField] AudioClip audioclip;

    bool didPlayed = false;

    private void OnTriggerEnter2D(Collider2D collisionedone)
    {
        if(collisionedone.tag == "Surface")
        {
            // öldükten sonra yapılacak ilk iş playercontroller scriptinde
            // hareket edilebilir özelliğini false yapmalk!
            FindObjectOfType<PlayerController>().disableControls();

            if (!didPlayed)
            {
                crasheffect.Play();
                GetComponent<AudioSource>().PlayOneShot(audioclip);
                didPlayed = true;
            }
            Invoke("ReloadScene", Delay);
        }

        if(collisionedone.tag == "Trap")
        {
            FindObjectOfType<PlayerController>().disableControls();

            if (!didPlayed)
            {
                crasheffect.Play();
                GetComponent<AudioSource>().PlayOneShot(audioclip);
                didPlayed = true;
            }
            Invoke("ReloadScene", 0.2f);
        }
        
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
