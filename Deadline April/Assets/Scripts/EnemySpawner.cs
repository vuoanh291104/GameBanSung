using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefabs;
    public float spwanRate= 1.5f;
    public float spwanRadius= 5f;
    private float spwanTimer= 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spwanTimer+= Time.deltaTime;
        if(spwanTimer >= spwanRate){
            spwanEnemy();
            spwanTimer=0;
        }
    }
    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spwanRadius);
    }
    void spwanEnemy(){
        Vector2 randomPosition= (Vector2)transform.position + Random.insideUnitCircle.normalized* spwanRadius;
        Instantiate(enemyPrefabs,randomPosition,Quaternion.identity);
    }
}
