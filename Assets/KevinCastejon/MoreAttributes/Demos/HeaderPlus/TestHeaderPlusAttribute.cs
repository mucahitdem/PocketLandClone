using KevinCastejon.MoreAttributes;
using UnityEngine;

public class TestHeaderPlusAttribute : MonoBehaviour
{
    [SerializeField]
    private int _attackSpeed;

    [HeaderPlus("Assets/KevinCastejon/MoreAttributes/Demos/HeaderPlus/Icons/greencrossicon.png", "Health",
        (int) HeaderPlusColor.green)]
    [SerializeField]
    private int _currentHealth;

    [HeaderPlus("Assets/KevinCastejon/MoreAttributes/Demos/HeaderPlus/Icons/atk.png", "Attack",
        (int) HeaderPlusColor.red)]
    [SerializeField]
    private int _damagePoints;

    [SerializeField]
    private int _maxHealth;
}