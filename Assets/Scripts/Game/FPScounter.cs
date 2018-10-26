using UnityEngine;
using UnityEngine.UI;

public class FPScounter : MonoBehaviour {

    private Text fps;
    private int framerate;

    private void Start()
    {
        fps = GetComponent<Text>();
    }

    private void Update()
    {
        framerate = (int)Mathf.Ceil(1 / Time.deltaTime);
        fps.text = framerate.ToString();
    }

    private void OnDisable()
    {
        fps.text = "";
    }
}
