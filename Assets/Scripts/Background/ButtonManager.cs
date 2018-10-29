using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

    public void Garage()
    {
        FindObjectOfType<Menu>().LoadID(7);
    }

    public void Generate(InputField _inputField)
    {
        FindObjectOfType<Menu>().Load(_inputField);
    }

    public void Settings()
    {
        FindObjectOfType<Menu>().SettingsMenu();
    }
}
