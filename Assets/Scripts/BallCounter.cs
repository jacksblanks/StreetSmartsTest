using UnityEngine;

public class BallCounter : MonoBehaviour
{
    private int _ballsCollected;

    public delegate void BallCounterUpdated(int ballsCollected);
    public static event BallCounterUpdated OnBallCounterUpdated;


    private void OnEnable()
    {
        BallCollector.OnBallCollected += IncrementBallsCollected;
    }

    private void OnDisable()
    {
        BallCollector.OnBallCollected += IncrementBallsCollected;
    }

    private void IncrementBallsCollected()
    {
        _ballsCollected += 1;
        OnBallCounterUpdated?.Invoke(_ballsCollected);
    }
}
