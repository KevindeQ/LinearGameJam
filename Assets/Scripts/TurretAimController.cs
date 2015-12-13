using UnityEngine;
using System.Collections;

public class TurretAimController : MonoBehaviour
{
    public GameObject Player;

    public GameObject Bullet;
    Vector3 BulletSpawnLocation;

    void Start()
    {
        BulletSpawnLocation = transform.position + new Vector3(0.6f, 1.27f, 0.0f);
        Instantiate(Bullet, BulletSpawnLocation, Quaternion.identity);
    }

	void Update ()
    {
	    
	}
}
