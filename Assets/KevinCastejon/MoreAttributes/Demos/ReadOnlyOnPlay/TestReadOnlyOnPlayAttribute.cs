using KevinCastejon.MoreAttributes;
using UnityEngine;

public class TestReadOnlyOnPlayAttribute : MonoBehaviour
{
    [ReadOnlyOnPlay(true)]
    [SerializeField]
    private int _damages;

    [ReadOnlyOnPlay]
    [SerializeField]
    private int _healthPoints;
}