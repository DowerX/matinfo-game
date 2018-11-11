using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    #region
    [Header("Loading:")]
    public Text percentige;
    private AsyncOperation operation;
    public Slider loadingBar;

    [Header("Disable after loading:")]
    public GameObject[] objects = new GameObject[3];

    [Header("Loading animation:")]
    public RawImage fade;

    [Header("Settings menu:")]
    public GameObject settings;
    private bool isSettings = false;

    #endregion

    public bool working = true;

    private void OnLevelWasLoaded(int level)
    {
        loadingBar.gameObject.SetActive(false);
    }

    public void Load(InputField input)
    {
        int _id;
        if (!int.TryParse(input.text, out _id))
            return;

        operation = SceneManager.LoadSceneAsync(_id);
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
        loadingBar.gameObject.SetActive(true);

    }

    public void LoadID(int _id)
    {
        operation = SceneManager.LoadSceneAsync(_id);
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }

        loadingBar.gameObject.SetActive(true);

    }

    public void SettingsMenu()
    {
        isSettings = !isSettings;
        settings.SetActive(isSettings);
    }

    private void Update()
    {
        //Update while loading
        if (operation != null)
        {
            if (working)
            {
                loadingBar.value = Mathf.Clamp01(operation.progress);
                percentige.text = (Mathf.Clamp01(operation.progress) * 100).ToString() + "%";
            }
        }

        if (Input.GetKeyDown("escape") && SceneManager.GetActiveScene().buildIndex != 0)
        {
            LoadID(0);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
