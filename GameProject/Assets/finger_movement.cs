using Unity.VisualScripting;
using UnityEngine;

public class CircleFollowTouch : MonoBehaviour
{
    public GameObject parent;
    public GameObject background;
    public Camera mainCamera;
    private bool interacted = false;

    private float Pythag(Vector2 position_one, Vector2 position_two)
    {
        Vector2 magnitude_vector = new Vector2(Mathf.Abs(position_two.x - position_one.x), Mathf.Abs(position_two.y - position_one.y));
        return magnitude_vector.magnitude;
    }

    private void Set_Sprite_Position_From_Input_Position(Vector2 input_position)
    {
        Vector2 touch_position = mainCamera.ScreenToWorldPoint(new Vector2(input_position.x, input_position.y));
        Vector2 parent_position = new Vector2(parent.transform.position.x, parent.transform.position.y);
        float radius = background.transform.localScale.x / 2;
        float distance_from_centre = Pythag(touch_position, parent_position);

        if (distance_from_centre < radius)
        {
            interacted = true;
        }

        if (interacted)
        {
            if (distance_from_centre > radius)
            {
                touch_position = touch_position.normalized * 5 / 2;
            }
        }
        else
        {
            touch_position = parent_position;
        }

        transform.position = new Vector3(touch_position.x, touch_position.y, transform.position.z);
    }

    private void Start()
    {
        transform.position = parent.transform.position;
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
        else
        {
            transform.position = parent.transform.position;
            interacted = false;
        }
    }
}