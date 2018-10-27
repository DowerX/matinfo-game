using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    [Header("Level generation path:")]
    public InputField inputField;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level == 1)
        {
            FindObjectOfType<LevelGenerator>().Work(inputField.text);
            GetComponent<Menu>().working = false;
        }
    }
}
