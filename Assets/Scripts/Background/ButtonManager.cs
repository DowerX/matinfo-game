using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

    public void Garage()
    {
        FindObjectOfType<Menu>().LoadID(6);
    }

    public void Generate()
    {
        FindObjectOfType<Manager>().path = GameObject.Find("GeneratedPlayInput").GetComponent<InputField>().text;
        FindObjectOfType<Menu>().LoadID(1);
    }

    public void Settings()
    {
        FindObjectOfType<Menu>().SettingsMenu();
    }
}
