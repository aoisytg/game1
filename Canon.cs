using UnityEngine;

public class CanonController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
