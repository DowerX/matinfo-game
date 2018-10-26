using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;

    private void Update()
    {
        transform.LookAt(target);
    }
}
