using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float reloadDelay = 2.0f;
    [SerializeField] private ParticleSystem finishEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        finishEffect.Play();
        Invoke(nameof(ReloadScene), reloadDelay);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
