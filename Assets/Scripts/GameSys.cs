using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameSys : MonoBehaviour
{
    private Economy econ;
    public void LaunchProjectile(Projectile prj, Vector2 startPoint, Vector2 velocity){
        var prjObj = Instantiate(
            prj,
            startPoint,
            Quaternion.identity
        );
        prjObj.GetComponent<Rigidbody2D>().velocity = velocity;
    }
    public void SpawnObject(GameObject obj, Vector2 startPoint, int delay){
        var newObj = Instantiate(
            obj,
            startPoint,
            Quaternion.identity
        );
    }
    public void SpawnDefender(GameObject dfndr, GameObject square){
        // only one defender per square
        GameObject defenderInstance = Instantiate(dfndr, square.transform.position, Quaternion.identity) as GameObject;
        defenderInstance.transform.SetParent(square.transform, true);
    }
    public void SpawnVFX(GameObject vfx, Transform t, float duration = 2f){
        GameObject vfxInstance = Instantiate(vfx, t.position, Quaternion.identity) as GameObject;
        Destroy(vfxInstance, duration);
    }
    private void Update() {
        
    }
    private void Awake() {
        econ = GetComponent<Economy>();
    }
}