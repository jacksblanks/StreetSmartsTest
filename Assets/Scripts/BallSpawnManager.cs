using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to spawn balls within certain area given z and x bounds as well as a starting Y position.
/// </summary>
public class BallSpawnManager : MonoBehaviour
{
    public int NumBallsToSpawn = 10;
    public float XBoundsRangeMin;
    public float XBoundsRangeMax;
    public float ZBoundsRangeMin;
    public float ZBoundsRangeMax;
    public float StartingYPosition;

    public GameObject BallPrefab;

    private readonly List<Vector3> _ballPositions = new List<Vector3>();
    private int _ballCount;
    private float _minBallSeparation = 1f;
    private float _minBallCollectionSeparation = 2f;

    private Vector3 RandomBallPosition => new Vector3(Random.Range(XBoundsRangeMin, XBoundsRangeMax), StartingYPosition,
        Random.Range(ZBoundsRangeMin, ZBoundsRangeMax));

    private void Awake()
    {
        for (var i = 0; i< NumBallsToSpawn; i++)
            SpawnNewBall();
    }

    private void SpawnNewBall()
    {
        var newBall = GameObject.Instantiate(BallPrefab);
        newBall.name = $"Ball {_ballCount++}";
        newBall.transform.parent = transform;
        
        var newPos =  RandomBallPosition;
        while (!BallProximityCheck(newPos))
            newPos = RandomBallPosition;
       
        _ballPositions.Add(newPos);
        newBall.transform.position = newPos;
    }

    // Tried using physics.OverlapSphere or SphereCast to do this, wasn't reliable for some reason...
    // Might be because the collision detection doesn't work when there all instantiated at the same time?
    private bool BallProximityCheck(Vector3 checkPosition)
    {
        if (Vector3.Distance(checkPosition, Vector3.zero) < _minBallCollectionSeparation)
            return false;

        if (_ballPositions.Count == 0)
            return true;

        foreach (var ballPosition in _ballPositions)
        {
            if (Vector3.Distance(checkPosition, ballPosition) < _minBallSeparation)
                return false;
        }

        return true;
    }
}
