using UnityEngine;

public class FinishLine : MonoBehaviour {
    private StartLine startLine;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            startLine = FindObjectOfType<StartLine>();

            startLine.counting = false;

            startLine.Draw();
            startLine.time = 0f;
        }
    }
}
