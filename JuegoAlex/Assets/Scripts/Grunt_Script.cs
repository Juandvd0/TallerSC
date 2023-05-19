using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt_Script : MonoBehaviour
{
    public GameObject Alex;
    public GameObject BulletPrefabEnemy;

    private float LastShoot;
    private float LastMove;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     /**
     Random random = new Random();
      int num = random.Next(0, 101);

        if ( num <= 50 && Time.time > LastShoot + 1.5f) // Si el temporizador alcanza cero, cambiar la dirección y reiniciar el temporizador
        {
            Vector3 movement = new Vector3(transform.position.x - 1.0f, transform.position.y, transform.position.z);
            transform.Translate(movement);
            LastMove = Time.time;
        }
        else if(num > 50 && Time.time > LastShoot + 1.5f ) 
        {
            Vector3 movement = new Vector3(transform.position.x + 1.0f, transform.position.y, transform.position.z);
            transform.Translate(movement);
            LastMove = Time.time;
        }
        
        **/
        Vector3 direction = Alex.transform.position - transform.position;
        if(direction.x >= 0.0f) transform.localScale = new Vector3(6.5f,6.5f,1.0f);
        else transform.localScale = new Vector3(-6.5f,6.5f,1.0f);
        float distance = Mathf.Abs(Alex.transform.position.x - transform.position.x);
        if (distance < 4.0f && Time.time > LastShoot + 1.5f){
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot(){
        Debug.Log("Shoot");
        Vector3 direction;
        if(transform.localScale.x > 1.0f) direction = Vector2.right;
        else direction = Vector2.left;
        GameObject bullet = Instantiate(BulletPrefabEnemy, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<Bullet_Grunt_Script>().setDirection(direction);
    }
}
