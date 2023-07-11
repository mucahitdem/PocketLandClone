using KevinCastejon.MoreAttributes;
using UnityEngine;

public class TestReadOnlyAttribute : MonoBehaviour
{
    [ReadOnly]
    [SerializeField]
    private int _damages;

    [ReadOnly]
    [SerializeField]
    private int _healthPoints;
}