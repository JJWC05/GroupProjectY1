using UnityEngine;

public class CircleFollowTouch : MonoBehaviour
{
    public Camera mainCamera;  // Assign the main camera in the Inspector

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);  // Get the first touch

            // Convert screen touch position to world position
            Vector3 touchPosition = mainCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, mainCamera.nearClipPlane));

            // Set the circle position, ensuring Z remains unchanged
            transform.position = new Vector3(touchPosition.x, touchPosition.y, transform.position.z);
        }
    }
}