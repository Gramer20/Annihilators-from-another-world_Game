using TMPro;
using UnityEngine;

public class ObjectDurabilityTextView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textView;

    public void Display(float maxDurability, float currentDurability)
    {
        float progress = currentDurability / maxDurability;

        _textView.text = $"{progress * 100} %";
    }
}
