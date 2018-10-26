using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("Loading:")]
    public Text percentige;
    private AsyncOperation operation;
    public Slider loadingBar;

    [Header("Disable after loading:")]
    public GameObject[] objects;

    [Header("Loading animation:")]
    public RawImage fade;

    [Header("Settings menu:")]
    public GameObject settings;
    private bool isSettings = false;

    public bool working = true;


    public void GenerateAndLoad(int id)
    {
        operation = SceneManager.LoadSceneAsync(id);

        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }

        loadingBar.gameObject.SetActive(true);

        fade.GetComponent<Animator>().SetTrigger("fadeout");
    }

    private void OnLevelWasLoaded(int level)
    {
        fade.GetComponent<Animator>().SetTrigger("fadein");
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

        fade.GetComponent<Animator>().SetTrigger("fadeout");
    }

    public void LoadID(int _id)
    {
        operation = SceneManager.LoadSceneAsync(_id);
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
        loadingBar.gameObject.SetActive(true);

        fade.GetComponent<Animator>().SetTrigger("fadeout");
    }

    public void SettingsMenu()
    {
        isSettings = !isSettings;
        settings.SetActive(isSettings);
    }

    private void Update()
    {
        //Update while loading
        if(operation != null && working)
        {
            loadingBar.value = Mathf.Clamp01(operation.progress);
            percentige.text = (Mathf.Clamp01(operation.progress) * 100).ToString() + "%";
        }
    }
}
