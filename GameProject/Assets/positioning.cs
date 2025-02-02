using UnityEngine;

public class positioning : MonoBehaviour
{
    public int x_position;
    public int y_position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        transform.position = new Vector3(x_position, y_position);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}