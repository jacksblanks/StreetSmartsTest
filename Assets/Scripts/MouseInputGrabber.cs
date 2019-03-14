using UnityEngine;

/// <summary>
/// Controls input for mouse input and grabbing balls
/// </summary>
public class MouseInputGrabber : MonoBehaviour
{
    public float FollowSpeed = 1;
    public float HoldingYPosition = 0.5f;

    private Transform _trackedObject;

    private const int GroundLayerMask = 1 << 8;

    private void Update()
    {
        CheckForMouseInput();
        UpdateTrackedObject();
    }

    private void CheckForMouseInput()
    {
        if (Input.GetMouseButtonDown(0) && _trackedObject == null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Ball"))
                    _trackedObject = hit.transform;
            }
        }

        if (Input.GetMouseButtonUp(0))
            _trackedObject = null;

    }

    private void UpdateTrackedObject()
    {
        if (_trackedObject != null)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
            RaycastHit hit;
            
            if (Physics.Raycast (ray, out hit, Mathf.Infinity, GroundLayerMask))
            {
                var targetPos = new Vector3(hit.point.x, HoldingYPosition, hit.point.z);
                _trackedObject.position = Vector3.Lerp(_trackedObject.position, targetPos, FollowSpeed*Time.deltaTime);
            }
        }
    }
}
