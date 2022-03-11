using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float Delay = 1f;

    // for triggering particle effects ! = ParticleSystem!
    [SerializeField] ParticleSystem finisheffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            finisheffect.Play();
            // audio yu tanımlamadan oynatmak / tanımlamadık çünkü zaten unity seçmeye izin veriuot direk!
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", Delay);

            
        }
    }

    public void ReloadScene()
    {
        // oyuna ekli olan sahnelerden ilk olanı yani indexi 0 olanı getirecek!
        SceneManager.LoadScene(1);
    }
}
