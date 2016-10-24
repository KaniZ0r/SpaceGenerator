using UnityEngine;
using System.Collections;

public class GrassGenerator : MonoBehaviour {

    public GameObject Grass;

	// Use this for initialization
	void Start () {
        SpawnGrass();
	}
	
    void SpawnGrass()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Instantiate(Grass, new Vector3(transform.position.x + i, transform.position.y, transform.position.z + j), Quaternion.Euler(new Vector3(-90, 0, 0)));
            }
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
