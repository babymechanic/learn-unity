using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float reloadDelay = 2.0f;
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private AudioClip crashSFX; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Ground")) return;
        crashEffect.Play();
        GetComponent<AudioSource>().PlayOneShot(crashSFX);
        Invoke(nameof(ReloadScene), reloadDelay);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
