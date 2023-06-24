using UnityEngine;

public class ShopController : MonoBehaviour
{
    public GameObject weaponPrefab;
    public Transform weaponSpawnPoint;

    private bool isWeaponEquipped = false;
    private GameObject currentWeapon;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Нажата клавиша "F"
        {
            if (isWeaponEquipped)
            {
                UnequipWeapon();
            }
            else
            {
                EquipWeapon();
            }
        }
    }

    private void EquipWeapon()
    {
        if (!isWeaponEquipped)
        {
            // Создаем оружие в точке спавна
            currentWeapon = Instantiate(weaponPrefab, weaponSpawnPoint.position, weaponSpawnPoint.rotation);
            currentWeapon.transform.parent = weaponSpawnPoint;
            isWeaponEquipped = true;
        }
    }

    private void UnequipWeapon()
    {
        if (isWeaponEquipped)
        {
            // Уничтожаем текущее оружие
            Destroy(currentWeapon);
            isWeaponEquipped = false;
        }
    }
}
