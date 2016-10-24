using UnityEngine;
using System.Collections;

public class forestGenerator : MonoBehaviour
{

    public float size;
    public float radius;
    public float spawnCount;
    public float objCount;
    public float dencity;
    public Vector3 position;
    public System.Collections.Generic.List<ForestObject> ForestObjects;
    private System.Collections.Generic.List<Vector3> spList = new System.Collections.Generic.List<Vector3>();

    // Use this for initialization
    void Start()
    {
        float scaleFactor = Random.Range(0, 100);
        transform.localScale = new Vector3(transform.localScale.x + scaleFactor, transform.localScale.y + scaleFactor, transform.localScale.z + scaleFactor);
        if (dencity > 1)
        {
            dencity = 1;
        }
        if (dencity < 0)
        {
            dencity = 0;
        }
        radius = (50 + scaleFactor) / 2;
        size = 4 * Mathf.PI * radius * radius;
        SplitByDencity();
        Create();
        transform.position = new Vector3(Random.Range(-1000, 1000), Random.Range(-1000, 1000),Random.Range(-1000, 1000));
    }

    void SplitByDencity()
    {
        float dencities = 0;
        foreach (ForestObject f in ForestObjects)
        {
            dencities += f.dencity;
        }
        foreach (ForestObject f in ForestObjects)
        {
            f.dencityPercentage = f.dencity / dencities;
        }
    }

    void Create()
    {
        objCount = size * dencity / 25;
        int count = 0;
        while (spList.Count < objCount)
        {
            GetSpawnPoints();
        }
        foreach (ForestObject f in ForestObjects)
        {
            for (int i = 0; i < objCount * f.dencityPercentage - 1; i++)
            {
                if (spList.Count < count)
                {
                    GetSpawnPoints();
                }
                GameObject t = (GameObject)Instantiate(f.obj, transform.position + spList[count], Quaternion.identity);
                t.transform.LookAt(transform.position);
                t.transform.Rotate(new Vector3(t.transform.rotation.x - 90, t.transform.rotation.y, t.transform.rotation.z) + f.rotation);
                t.transform.parent = transform;
                count++;
            }
        }
        /*
        GameObject t = (GameObject)Instantiate(Tree1.obj, spawnPoint, Quaternion.identity);
        t.transform.LookAt(transform.position);
        t.transform.Rotate(new Vector3(t.transform.rotation.x - 90, t.transform.rotation.y, t.transform.rotation.z) + Tree1.rotation);

        float objCount = size * FObj.dencity * 0.03f;
        float spawnCount = 0;
        while (spawnCount < objCount)
        {
            Spawn(FObj);
            spawnCount++;
        }
        */
    }

    void GetSpawnPoints()
    {
        Vector3 pos = Random.onUnitSphere;
        RaycastHit hit;
            if (Physics.Raycast(pos * radius * 2, (pos - pos * radius).normalized * radius * 2, out hit))
            {
                position = hit.point - transform.position - pos / 2;
            }
        if (!spList.Contains(position))
        {
            spList.Add(position);
        }
    }

    /**
    void Spawn(ForestObject FObj)
    {
        Vector3 spawnPosition = Random.onUnitSphere;
        RaycastHit hit;
        if (Physics.Raycast(spawnPosition * radius, (spawnPosition - spawnPosition * radius).normalized * radius, out hit))
        {
           position = hit.point - spawnPosition / 2;
        }
        GameObject t = (GameObject)Instantiate(FObj.obj, position, Quaternion.identity);
        t.transform.LookAt(transform.position);
        t.transform.Rotate(new Vector3(t.transform.rotation.x - 90, t.transform.rotation.y, t.transform.rotation.z) + FObj.rotation);
    }
    **/

    [System.Serializable]
    public class ForestObject
    {
        public GameObject obj;
        public float dencity;
        public float dencityPercentage;
        public float height;
        public Vector3 rotation;
    }

}
