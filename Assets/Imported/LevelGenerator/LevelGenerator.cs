using UnityEngine;
using System.IO;

public class LevelGenerator : MonoBehaviour {

	private Texture2D map;

    [Header("Path to file:")]
    public string path;
    private byte[] file;
    public Transform holder;
    //public List<GameObject> spawned = new List<GameObject>();

	public ColorToPrefab[] colorMappings;

    public void Work(string _path)
    {
        path = _path;
        map = LoadPNG();
        GenerateLevel();
    }

	void GenerateLevel ()
	{
		for (int x = 0; x < map.width; x++)
		{
			for (int z = 0; z < map.height; z++)
			{
				GenerateTile(x, z);
			}
		}
	}

	void GenerateTile (int x, int z)
	{
		Color pixelColor = map.GetPixel(x, z);

		if (pixelColor.a == 0)
		{
			// The pixel is transparrent. Let's ignore it!
			return;
		}

		foreach (ColorToPrefab colorMapping in colorMappings)
		{
			if (colorMapping.color.Equals(pixelColor))
			{
				Vector3 position = new Vector3(x,colorMapping.height,z);
				Instantiate(colorMapping.prefab, position, Quaternion.identity, holder);
			}
		}
	}

    public void DestroyAll()
    {
        foreach(Transform child in holder)
        {
            if(child.tag != "Player")
                Destroy(child.gameObject);
        }
    }

    Texture2D LoadPNG()
    {
        file = File.ReadAllBytes(path);
        Texture2D _image = new Texture2D(2, 2);
        _image.LoadImage(file);
        return _image;
    }
	
}
