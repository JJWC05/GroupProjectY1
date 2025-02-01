using UnityEngine;

public class CircleFollowTouch : MonoBehaviour
{
    public Camera mainCamera;

    private void Set_Sprite_Position_From_Input_Position(Vector2 input_position)
    {
        Vector3 touchPosition = mainCamera.ScreenToWorldPoint(new Vector3(input_position.x, input_position.y, 0));

        transform.position = new Vector3(touchPosition.x, touchPosition.y, transform.position.z);
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            UnityEngine.Touch touch = Input.GetTouch(0);

            Set_Sprite_Position_From_Input_Position(touch.position);
        }
        else if (Input.GetMouseButton(0))
        {
            Set_Sprite_Position_From_Input_Position(Input.mousePosition);
        }
    }
}