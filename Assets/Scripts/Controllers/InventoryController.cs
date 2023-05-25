using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance;
    private List<Weapon> weapons;
    private int indexWeapon;
    private float scroll;

    private void Awake()
    {
        Instance = this;
        weapons = new List<Weapon>();
        indexWeapon = 0;
    }

    public void AddWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
        for (int i = 0; i < weapons.Count; ++i)
        {
            weapons[i].gameObject.SetActive(i.Equals(weapons.Count - 1));
        }
    }

    private void GetNextWeapon()
    {
        indexWeapon++;
        if (indexWeapon >= weapons.Count)
        {
            indexWeapon = 0;
        }
    }

    private void GetPrevieWeapon()
    {
        indexWeapon--;
        if (indexWeapon < 0)
        {
            indexWeapon = weapons.Count - 1;
        }
    }

    private void ChangeWeapon()
    {
        weapons[indexWeapon].gameObject.SetActive(false);
        if (scroll > 0)
        {
            GetNextWeapon();
        }
        else
        {
            GetPrevieWeapon();
        }
       
        if (weapons.Count > 0)
        {
            weapons[indexWeapon].gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        scroll = Input.mouseScrollDelta.y;
        if (scroll != 0)
        {
            ChangeWeapon();
        }
    }
}
