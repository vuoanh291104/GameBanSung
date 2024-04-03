using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefabs;
    public float spwanRate= 2f;
    public float spwanRadius= 5f;
    private float spwanTimer= 0f;
    private float times=0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.instance.GameOver()){
            spwanTimer+= Time.deltaTime;
            times +=Time.deltaTime;
            if(spwanTimer >= spwanRate){
                if(times <10f){
                    spwanEnemy();
                }
                else{
                    spamEnermy();
                }
                spwanTimer=0;
               
            }
            

            
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
    void spamEnermy(){
        for(int i=0; i<2; i++){
            Vector2 randomPosition= (Vector2)transform.position + Random.insideUnitCircle.normalized* spwanRadius;
            Instantiate(enemyPrefabs,randomPosition,Quaternion.identity);
        }
    }
}
