using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    [Header("Rendering:")]
    public InputField inputW;
    public InputField inputH;
    public bool fullscreen;
    public InputField gQuality;

    private void Start()
    {
        inputH.text = Screen.height.ToString();
        inputW.text = Screen.width.ToString();
        gQuality.text = QualitySettings.GetQualityLevel().ToString();
    }

    public void ChangeSettings()
    {
        Screen.SetResolution(int.Parse(inputW.text), int.Parse(inputH.text), fullscreen);
        QualitySettings.SetQualityLevel(int.Parse(gQuality.text));
        FindObjectOfType<Menu>().SettingsMenu();
    }

    public void ChangeFullscreen()
    {
        fullscreen = !fullscreen;
    }
}
