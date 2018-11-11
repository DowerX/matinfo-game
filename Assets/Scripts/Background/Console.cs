using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;

public class Console : MonoBehaviour {

    //Variables
    #region
    public GameObject canvas;
    public InputField inputField;
    public Text output;

    [Header("Keys:")]
    public string openKey;
    public string enter;

    private bool isActive = false;

    private string[] outputList = new string[5];
    private string outp;

    [Header("Specific:")]
    public GameObject[] prefabs;

    [Space]
    [Space]
    public FPScounter fps;
    public SoundManager sound;
    #endregion

    private void Start()
    {
        canvas.SetActive(isActive);
        outputList.Initialize();

        //Clear log
        output.text = "";
    }

    void Update () {
        if (Input.GetKeyDown(openKey))
        {
            ChangeActive();
        }

        if (isActive)
        {
            ConsoleSelect();
        }
	}

    private void ChangeActive()
    {
        isActive = !isActive;
        canvas.SetActive(isActive);
    }

    private void ConsoleSelect()
    {
        if (Input.GetKeyDown(enter))
        {
            Log("> " + inputField.text);
            string[] _input = inputField.text.Split((" ").ToCharArray());

            if (_input[0] == "map")
            {
                FindObjectOfType<Menu>().LoadID(int.Parse(_input[1]));
                string log = "Loading map by id: " + _input[1];
                Log(log);
                ChangeActive();
                return;
            }

            if (_input[0] == "quit")
            {
                Application.Quit();
            }

            if (_input[0] == "pp")
            {
                if(_input[1] == "true")
                {
                    FindObjectOfType<PostProcessingBehaviour>().enabled = true;
                    string log = "PP: on";
                    Log(log);
                }
                else
                {
                    FindObjectOfType<PostProcessingBehaviour>().enabled = false;
                    string log = "PP: off";
                    Log(log);
                }
                ChangeActive();
                return;
            }

            if (_input[0] == "spawn")
            {
                Spawner(int.Parse(_input[1]), float.Parse(_input[2]), float.Parse(_input[3]), float.Parse(_input[4]));
                ChangeActive();
                return;
            }

            if(_input[0] == "input_type")
            {
                FindObjectOfType<Car>().keyboard = !FindObjectOfType<Car>().keyboard;
                string log = "Changed input type.";
                Log(log);
                ChangeActive();
                return;
            }

            if(_input[0] == "echo")
            {
                Log(_input[1]);
                //ChangeActive();
                return;
            }

            if(_input[0] == "fps_counter")
            {
                fps.enabled = !fps.enabled;
                Log("Changed FPS counter state.");
                ChangeActive();
                return;
            }

            if (_input[0] == "help")
            {
                Log("Commands: help, spawn [ID] [X] [Y] [Z], input_type, pp [STATE], map [ID], echo [STRING], fps_counter, quit, generate [PATH], destroy_generated, destroy_tag [TAG], settings.");
                return;
            }

            if (_input[0] == "volume")
            {
                sound.ChangeVolume(int.Parse(_input[1]), _input[2]);
                Log("Changed volume to " + _input[1]);
                return;
            }

            if (_input[0] == "generate")
            {
                FindObjectOfType<LevelGenerator>().Work(_input[1]);
                Log("Generating map from " + _input[1]);
                return;
            }

            if (_input[0] == "destroy_generated")
            {
                FindObjectOfType<LevelGenerator>().DestroyAll();
                Log("Destroying generated map");
                return;
            }

            if (_input[0] == "destroy_tag")
            {
                Destroy(GameObject.FindWithTag(_input[1]));
                Log("Destroying GameObjects with tag " + _input[1]);
                return;
            }

            if(_input[0] == "settings")
            {
                Log("Opening settings.");
                FindObjectOfType<Menu>().SettingsMenu();
            }

            if (_input[0] == "info")
            {
                Log("Version 1.0");
                Log("Made by BENEDEK László");
                FindObjectOfType<Menu>().SettingsMenu();
            }
        }
    }

    private void Log(string _log)
    {
        Debug.Log(_log);
        outputList[4] = _log + "\n";
        outputList[0] = outputList[1];
        outputList[1] = outputList[2];
        outputList[2] = outputList[3];
        outputList[3] = outputList[4];
        output.text = outputList[0] + outputList[1] + outputList[2] + outputList[3];
    }

    private void Spawner(int _id, float x, float y, float z)
    {
        Instantiate(prefabs[_id],new Vector3(x,y,z), Quaternion.identity);
        string log = "Spawned prefab of id " + _id + ". Position: " + x + y + z;
        Log(log);
    }
}
