using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Projectile projectile;
    [SerializeField] GameObject projectileLauncher;
    private GameSys sys;
    public void Fire(){
        // do things;
        sys.LaunchProjectile(projectile, projectileLauncher.transform.position, Vector2.right * 3f);
    }
    void Awake()
    {
        sys = GameObject.Find("GameSys").GetComponent<GameSys>();
    }
}
