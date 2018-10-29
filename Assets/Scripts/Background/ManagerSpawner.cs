using UnityEngine;

public class ManagerSpawner : MonoBehaviour {
    private Manager manager;
    public GameObject prefab;

	void Start () {
        manager = FindObjectOfType<Manager>();
        if (manager)
            return;

        Instantiate(prefab, Vector3.zero, Quaternion.identity);
    }
	
}
