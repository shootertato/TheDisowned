using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBullet : MonoBehaviour {
    [SerializeField] private float speed;
    private void Update() {
        transform.position += new Vector3(-speed * transform.localScale.x * Time.deltaTime, 0f, 0f);    
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
