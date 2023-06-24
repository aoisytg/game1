using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject weaponPrefab;
    public GameObject bulletPrefab;

    private GameObject currentWeapon;
    private Transform weaponTransform;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ЛКМ - выстрел
        {
            Shoot();
        }

        if (currentWeapon != null) // Если есть оружие, отслеживаем мышь
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePosition - weaponTransform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            weaponTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void Shoot()
    {
        if (currentWeapon != null)
        {
            // Создаем пулю в позиции ствола
            Instantiate(bulletPrefab, weaponTransform.position, weaponTransform.rotation);
        }
    }

    public void EquipWeapon()
    {
        if (currentWeapon == null)
        {
            // Создаем оружие в позиции персонажа
            currentWeapon = Instantiate(weaponPrefab, transform.position, Quaternion.identity);
            weaponTransform = currentWeapon.transform;
        }
    }
}
