using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private float currentSpeed = 0f;
    [SerializeField] int health = 100;
    [SerializeField] GameObject deathAnimation;
    private GameSys sys;
    public void SetMovementSpeed(float speed){
        currentSpeed = speed;
    }
    void Awake(){
        sys = GameObject.Find("GameSys").GetComponent<GameSys>();
    }
    public void ToggleCollider(){
        var collider = gameObject.GetComponent<PolygonCollider2D>();
        collider.enabled = !collider.enabled;
    }
    private void Die(){ 
        if(deathAnimation) sys.SpawnVFX(deathAnimation, transform);
        Destroy(gameObject);
    }
    public void ProcessHit(int damage){
        health -= damage;
        if(health <= 0){
            Die();
        }
    }
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }
}
