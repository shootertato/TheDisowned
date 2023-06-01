using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBullet : MonoBehaviour {
     private  GameObject player;
    private Rigidbody2D rb;
    public float force;
    [SerializeField] private float speed;
    [SerializeField] private float dmg;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 dir = player.transform.position - transform.position;
        dir.z = 0f;
        rb.velocity = new Vector2(dir.x, dir.y).normalized * force;

        float rotation = Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
    private void OnTriggerEnter2D(Collider2D other) {

        if(other.tag==("Player")){
            other.GetComponent<PlayerHealthController>().DealDamage();   
            Destroy(gameObject); 
        }

        if(other.tag==("Wall")){
            Destroy(gameObject);
        }
    }
}
