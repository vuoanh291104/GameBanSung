using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed =0.5f;
    private Transform PlayerTranform;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject= GameObject.FindGameObjectWithTag("Player");
        if(playerObject==null){
            playerObject= FindObjectOfType<GameObject>();
        }
        if(playerObject !=null){
            PlayerTranform= playerObject.transform;
        }else{
            Debug.Log("no player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerTranform!= null){
            Vector3 direction=(PlayerTranform.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
        
    }
}
