using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    

    [SerializeField]
    private GameObject SlimePrefab;

    [SerializeField]
    private float slimeInterval = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        if (SlimePrefab.activeSelf == true){
            StartCoroutine(spawnEnemy(slimeInterval, SlimePrefab));
        }
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy){
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
