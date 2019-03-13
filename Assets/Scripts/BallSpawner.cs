using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class to spawn balls within certain area given z and x bounds as well as a starting Y position.
/// </summary>
public class BallSpawner : MonoBehaviour
{
    public int NumBallsToSpawn = 10;
    public float XBoundsRangeMin;
    public float XBoundsRangeMax;
    public float ZBoundsRangeMin;
    public float ZBoundsRangeMax;
    public float StartingYPosition;

    public GameObject BallPrefab;

    private void Start()
    {
        for (var i = 0; i< NumBallsToSpawn; i++)
            SpawnNewBall();
    }

    public void SpawnNewBall()
    {
        var newBall = GameObject.Instantiate(BallPrefab);
        newBall.transform.parent = transform;
        newBall.transform.position = new Vector3(Random.Range(XBoundsRangeMin, XBoundsRangeMax), StartingYPosition, Random.Range(ZBoundsRangeMin, ZBoundsRangeMax));
    }
}
