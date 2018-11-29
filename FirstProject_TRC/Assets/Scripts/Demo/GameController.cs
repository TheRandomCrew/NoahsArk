using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject Meteorite;
    public Vector3 spawnValues;
    public float[] TimeSpawnRange;
    public float TimeForStartMeteorite;

    private void Start()
    {
        StartCoroutine(SpawnMeteorite());
    }

    IEnumerator SpawnMeteorite()
    {
        yield return new WaitForSeconds(TimeForStartMeteorite);
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Instantiate(Meteorite, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(TimeSpawnRange[0], TimeSpawnRange[0]));
        }      

    }
}
