using UnityEngine;
using UnityEngine.PostProcessing;

public class PPswitcher : MonoBehaviour {

	void Start () {
        GetComponent<PostProcessingBehaviour>().enabled = false;
	}
	
	void Update () {
        if (Input.GetKeyDown("p"))
        {
            GetComponent<PostProcessingBehaviour>().enabled = !GetComponent<PostProcessingBehaviour>().enabled;
        }
	}
}
