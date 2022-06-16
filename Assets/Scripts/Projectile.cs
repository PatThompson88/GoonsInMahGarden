using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public float spin = 540f;
    public int damage = 100;
    private void Awake(){
        
    }
    public int DealDamage(){
        return damage;
    }
    public void Hit(){
        //Destroy Animation
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D other){
        Attacker attacker = other.gameObject.GetComponent<Attacker>();
        if (!attacker){ return; }
        attacker.ProcessHit(damage);
        Hit();
    }
    void Update()
    {
        var rotationOffset = new Vector3(0, 0, ((transform.rotation.z + spin) * Time.deltaTime));
        transform.Rotate(rotationOffset);
    }

}
