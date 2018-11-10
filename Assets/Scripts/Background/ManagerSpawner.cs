using UnityEngine;

public class ManagerSpawner : MonoBehaviour {
    private Manager manager;
    public GameObject prefab;

	void Start () {
        manager = FindObjectOfType<Manager>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (manager)
            return;

        Instantiate(prefab, Vector3.zero, Quaternion.identity);
    }
	
}
