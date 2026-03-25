using UnityEngine;
using UnityEngine.UI;

public class ObjectDurabilityView : MonoBehaviour
{
    [SerializeField] private Slider _durabilitySlider;

    public void Display(float maxDurability, float currentDurability)
    {
        float progress = currentDurability / maxDurability;

        _durabilitySlider.value = progress;
    }
}
