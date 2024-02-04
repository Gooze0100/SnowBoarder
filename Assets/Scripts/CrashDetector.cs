using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CrashDetector : MonoBehaviour
{
    [SerializeField] float invokeDelayTime = 0.5f;
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;

            //PlayerController script is the same component as rigidbody, so you can detect it and if it has public methods or variables you can access it 
            FindObjectOfType<PlayerController>().DisableControls();
            finishEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", invokeDelayTime);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
