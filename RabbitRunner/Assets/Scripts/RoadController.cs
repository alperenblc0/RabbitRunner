using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    public GameObject[] Prefabs;
    private Transform Player;

    private List<GameObject> ActivePrefabs;


    public float BackArea = 100.0f;
    public int PrefabsOnScreen = 4;
    public int LastPrefab = 0;
    public float SpawnPrefab = -60.0f;
    public float PrefabLength = 69.0f;


    private void Start()
    {
        ActivePrefabs = new List<GameObject>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < PrefabsOnScreen; i++)
        {
            if (i < 4)
                Spawn(0);
            else
                Spawn();
        }
    }


    private void Update()
    {
        if (Player.position.z - BackArea > (SpawnPrefab - PrefabsOnScreen * PrefabLength))
        {
            Spawn();
            DeletePrefab();
        }
    }


    private void Spawn(int prefabIndex = -1)
    {
        GameObject myPrefab;
        if (prefabIndex == -1)

            myPrefab = Instantiate(Prefabs[RandomPrefabs()] as GameObject);
        else
            myPrefab = Instantiate(Prefabs[prefabIndex] as GameObject);

        myPrefab.transform.SetParent(transform);
        myPrefab.transform.position = Vector3.forward * SpawnPrefab;
        SpawnPrefab += PrefabLength;
        ActivePrefabs.Add(myPrefab);
    }

    private void DeletePrefab()
    {
        Destroy(ActivePrefabs[0]);
        ActivePrefabs.RemoveAt(0);
    }


    private int RandomPrefabs()
    {
        if (Prefabs.Length <= 1)
            return 0;
        int randomIndex = LastPrefab;
        while (randomIndex == LastPrefab)
        {
            randomIndex = Random.Range(0, Prefabs.Length);
        }

        LastPrefab = randomIndex;
        return randomIndex;
    }
    /* int nextStep = 0;
	 public GameObject[] PrefabsRoad;

	 private void Update()
	 {
		 nextStep =69;
		 Instantiate(PrefabsRoad[Random.Range(0,PrefabsRoad.Length)],new Vector3(0,0,transform.position.z+nextStep),Quaternion.identity);
	 }
	*/
    /* private void OnTriggerEnter(Collider other)
     {
         transform.position += new Vector3(0, 0, transform.GetChild(0).GetComponent<Renderer>().bounds.size.z*4);

     }
    */
}
