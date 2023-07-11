using KevinCastejon.MoreAttributes;
using UnityEngine;

public class TestReadOnlyOnPrefabAttribute : MonoBehaviour
{
    [ReadOnlyOnPrefab(true)]
    [SerializeField]
    private int _damages;

    [ReadOnlyOnPrefab]
    [SerializeField]
    private int _healthPoints;
}