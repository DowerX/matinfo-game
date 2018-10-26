using UnityEngine;
using UnityEngine.UI;

public class StartLine : MonoBehaviour {

    public bool counting = false;
    public float time = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
            counting = true;
    }

    private void Update()
    {
        if (counting)
            time += Time.deltaTime;
    }

    public void Draw()
    {
        GameObject.Find("Timer").GetComponent<Text>().text = time.ToString() + " s";
    }
}
