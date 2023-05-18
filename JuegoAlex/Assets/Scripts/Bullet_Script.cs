using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private Vector2 Direction;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>(); 
        Animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }
    public void setDirection(Vector2 direction){
        Direction = direction;
    }
    public void DestroyBullet(){
        Destroy(gameObject);
    }
}
