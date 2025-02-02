using UnityEngine;

public class parent_positioner : MonoBehaviour
{
    public GameObject parent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        transform.position = parent.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}