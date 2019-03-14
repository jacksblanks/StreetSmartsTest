using UnityEngine;

/// <summary>
/// Class for ball collector, destroys balls and broadcasts event.
/// </summary>
public class BallCollector : MonoBehaviour
{
    public delegate void BallCollected();
    public static event BallCollected OnBallCollected;
        
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
            OnBallCollected?.Invoke();
        }
    }
}
