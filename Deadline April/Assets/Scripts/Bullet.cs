using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed=10f;
    public float lifeTime =2f;
    [SerializeField] private Rigidbody2D rb;
    public GameObject Effect;

    // Start is called before the first frame update
    void Start()
    {
        
        rb.velocity= transform.right * speed;
        Destroy(gameObject, lifeTime);
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Enemy"){
            
            Instantiate(Effect,transform.position,quaternion.identity);
        }
    }

    
}
