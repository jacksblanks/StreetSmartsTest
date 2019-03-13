using UnityEngine;

public class MouseInputGrabber : MonoBehaviour
{
    public float FollowSpeed = 1;
    public float HoldingYPosition = 0.5f;

    private Transform trackedObject;

    private void Update()
    {
        CheckForMouseInput();
        UpdateTrackedObject();
    }

    private void CheckForMouseInput()
    {
        if (Input.GetMouseButtonDown(0) && trackedObject == null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Ball"))
                    trackedObject = hit.transform;
            }
        }

        if (Input.GetMouseButtonUp(0))
            trackedObject = null;

    }

    private void UpdateTrackedObject()
    {
        if (trackedObject != null)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
            RaycastHit hit = new RaycastHit();
 
            if (Physics.Raycast (ray, out hit) && hit.collider.gameObject.name == "Plane")
            {
                var targetPos = new Vector3(hit.point.x, HoldingYPosition, hit.point.z);
                trackedObject.position = Vector3.Lerp(trackedObject.position, targetPos, FollowSpeed*Time.deltaTime);
            }
        }
    }
}
