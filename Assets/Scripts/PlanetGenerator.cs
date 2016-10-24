using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlanetGenerator : MonoBehaviour {

    public System.Collections.Generic.List<GameObject> Planets = new System.Collections.Generic.List<GameObject>();
    public int planetCount;
    public Text generatingText;
    public GameObject CanvasBG;
    private int currentCount;
    // Use this for initialization
    void Start () {
        currentCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        generatingText.text = "Generating planets " + currentCount + " / " + planetCount;
        if (currentCount < planetCount)
        {
            int r = Random.Range(0, Planets.Count);
            GameObject planet = Planets[r];
            GameObject p = (GameObject)Instantiate(planet, transform.position, Quaternion.identity);
            currentCount++;
        }
        else
        {
            if (CanvasBG)
            {
                CanvasBG.SetActive(false);
                generatingText.gameObject.SetActive(false);
            }
        }
	}
}
