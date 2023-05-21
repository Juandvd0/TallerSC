using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alex_movement : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private float LastShoot;
    private float vidasPersonaje;
    private float sliderVidas = 100;
    public Slider barra;
    private bool velocidadDuplicada = false;

    void Start()
    {
       Rigidbody2D = GetComponent<Rigidbody2D>(); 
        Animator = GetComponent<Animator>();
        //sliderVidas.maxValue = vidasPersonaje;
        //sliderVidas.value = sliderVidas.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        if(Horizontal<0.0f ) transform.localScale = new Vector3(-6.5f,6.5f,1.0f);
        else if(Horizontal > 0.0f) transform.localScale = new Vector3(6.5f,6.5f,1.0f);
        Animator.SetBool("Running", Horizontal != 0.0f );

        if(Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.5f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }
 
    private void Shoot(){

        Vector3 direction;
        if(transform.localScale.x > 1.0f) direction = Vector2.right;
        else direction = Vector2.left;
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.5f, Quaternion.identity);
        bullet.GetComponent<Bullet_Script>().setDirection(direction);
    }
    
     private void FixedUpdate()
    {
        if (velocidadDuplicada)
        {
            Rigidbody2D.velocity = new Vector2(Horizontal * Speed * 2, Rigidbody2D.velocity.y);
        }
        else
        {
            Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
        }
    }

    public void Hit(){
        sliderVidas = sliderVidas - 20;
        //sliderVidas.value = vida;
        barra.value = 
            sliderVidas;
        if (sliderVidas == 0) Destroy(gameObject);
    }

    public void IncreaseHealth(){
    if (sliderVidas < 100)
    {
        sliderVidas += 20;
        if (sliderVidas > 100)
        {
            sliderVidas = 100;
        }
        barra.value = sliderVidas;
    }
    }

    public void DuplicateSpeed()
    {
        StartCoroutine(DuplicateSpeedCoroutine(3.0f));
    }

    private IEnumerator DuplicateSpeedCoroutine(float duration)
    {
        Speed *= 1.3f;
        velocidadDuplicada = true;

        yield return new WaitForSeconds(duration);

        Speed /= 1.3f;
        velocidadDuplicada = false;
    }

}
