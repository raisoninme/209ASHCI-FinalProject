using UnityEngine;

public class FixedToView : MonoBehaviour
{
    void Update()
    {
        Quaternion headRotation = Camera.main.transform.rotation;

        Vector3 eulerAngles = headRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0f, eulerAngles.y, 0f);

        foreach (Transform child in transform)
        {
            child.LookAt(Camera.main.transform);
            // child.Rotate(0, 180, 0);
        }
    }
}
