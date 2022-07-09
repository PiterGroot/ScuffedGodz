using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour
{
    private Transform rotationPoint;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 6;
    [SerializeField] private float shootInterval = 5;
    // Start is called before the first frame update
    void Start()
    {
        rotationPoint = gameObject.transform.GetChild(0);
        Invoke(nameof(ShootBullet), Random.Range(1.5f, 3f));
    }

    private void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, rotationPoint.position, Quaternion.identity);
        Rigidbody2D rb2d = bullet.GetComponent<Rigidbody2D>();
        rb2d.AddForce(rotationPoint.right * bulletSpeed, ForceMode2D.Impulse);
        Invoke(nameof(ShootBullet), shootInterval);
    }
}
