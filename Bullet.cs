using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] private float speed;
    [SerializeField] private float dmg;

    private void Update() {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag==("Enemy")){
            other.GetComponent<EnemyController>().TakeDamage(dmg);
            Destroy(gameObject);
        }

        if(other.tag==("Player")){
            other.GetComponent<PlayerHealthController>().DealDamage();   
            Destroy(gameObject); 
        }

        if(other.tag==("Wall")){
            Destroy(gameObject);
        }
    }
}
