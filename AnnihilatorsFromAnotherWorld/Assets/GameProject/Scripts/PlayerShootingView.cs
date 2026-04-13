using TMPro;
using UnityEngine;

public class PlayerShootingView : MonoBehaviour
{
    [SerializeField] private TMP_Text _shootingText;

    public void Display(int currentCountShot, int maxCountShot)
    {
        _shootingText.text = $"{currentCountShot}/{maxCountShot}";
    }
}
