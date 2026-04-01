using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;

    public void Display(int score)
    {
        _view.text = string.Format("{0:0000}", score);
    }
}
