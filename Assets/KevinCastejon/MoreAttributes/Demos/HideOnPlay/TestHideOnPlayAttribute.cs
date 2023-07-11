using KevinCastejon.MoreAttributes;
using UnityEngine;

public class TestHideOnPlayAttribute : MonoBehaviour
{
    [HideOnPlay(true)]
    [SerializeField]
    private int _damages;

    [HideOnPlay]
    [SerializeField]
    private int _healthPoints;
}