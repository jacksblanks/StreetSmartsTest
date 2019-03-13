using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
