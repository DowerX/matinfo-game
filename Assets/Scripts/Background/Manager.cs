using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    [Header("Level generation path:")]
    public InputField inputField;

    [Header("Car prefab id:")]
    public int car = 0;
    public GameObject[] cars;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level == 1)
        {
            FindObjectOfType<LevelGenerator>().Work(inputField.text);
            //GetComponent<Menu>().working = false;
        } else
        {
            Instantiate(cars[car], GameObject.FindGameObjectWithTag("Spawn").transform.position, GameObject.FindGameObjectWithTag("Spawn").transform.rotation);
        }

        if(level == 7)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        } else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
