using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player_Controler : MonoBehaviour
{
    float hp = 10;
    public float bulletspeed = 20;
    public float playerspeed = 2;
    public GameObject bulletPrefab;
    Vector2 movementVector;
    Transform bulletSpawn;
    public GameObject hpBar;
    Scrollbar hpScrollbar;
    // Start is called before the first frame update
    void Start()
    {
        movementVector = Vector2.zero;
        bulletSpawn = transform.Find("BulletSpawn");
        hpScrollbar = hpBar.GetComponent<Scrollbar>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate((Vector3.up * movementVector.x));
        // transform.position = new Vector3(transform.position.x + movementVector.x * Time.deltaTime,
        //    0,
        //  transform.position.z + movementVector.y *Time.deltaTime);
        transform.Translate(  Vector3.forward * movementVector.y * Time.deltaTime * playerspeed);
    }
   void OnMove(InputValue inputValue)
    {
        movementVector = inputValue.Get<Vector2>();
        Debug.Log(movementVector.ToString());
    }
    void OnFire()
    {
      GameObject bullet =   Instantiate(bulletPrefab, bulletSpawn );
        bullet.transform.parent = null;
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletspeed, ForceMode.VelocityChange);
        Destroy(bullet,5);
    }
    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.CompareTag("Enemy")){
            hp--;
            if (hp <= 0) Die();
            hpScrollbar.size = hp / 10;
            Vector3 pushVector = collision.gameObject.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(pushVector.normalized * 5, ForceMode.Impulse);


        }
    }
  void Die()
    {
        transform.Translate(Vector3.up);
        transform.Rotate(Vector3.right);
    }
}
