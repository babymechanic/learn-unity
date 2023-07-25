using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] private ParticleSystem dustTrailEffect;

    private void OnCollisionEnter2D(Collision2D other)
    {
        dustTrailEffect.Play();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Invoke(nameof(StopTrailEffect), 1.0f);
    }

    private void StopTrailEffect()
    {
        dustTrailEffect.Stop();
    }
}
