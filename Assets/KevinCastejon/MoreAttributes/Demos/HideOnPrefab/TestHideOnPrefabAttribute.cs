using KevinCastejon.MoreAttributes;
using UnityEngine;

public class TestHideOnPrefabAttribute : MonoBehaviour
{
    [HideOnPrefab(true)]
    [SerializeField]
    private int _damages;

    [HideOnPrefab]
    [SerializeField]
    private int _healthPoints;
}