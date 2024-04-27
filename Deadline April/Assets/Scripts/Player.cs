using System;
using System.Collections;
using System.Collections.Generic;
// using UnityEditor.ShortcutManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed= 2f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 moveInput;
    [SerializeField] private Animator anim;
    [SerializeField] private Camera mainCamera;
    public GameObject bulletPrefabs;
    public Transform firePoint;
    public float fireRate= 0.2f;
    private float nextFireTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput= new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        UpdateAnimation();
        if(Input.GetMouseButtonDown(0) && Time.time >= nextFireTime){
            Shoot();
            nextFireTime= Time.time +fireRate;
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefabs,firePoint.position,firePoint.rotation);
        AudioManager.instance.PlayShootClip();
    }

    private void UpdateAnimation()
    {
        if(moveInput.magnitude>0){
            anim.SetBool("IsRunning",true);
        }else{
            anim.SetBool("IsRunning",false);
        }
    }

    void FixedUpdate(){
        rb.velocity= moveInput.normalized*moveSpeed;
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        Vector2 mousePosition= mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection= mousePosition - rb.position;
        float angle= Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
