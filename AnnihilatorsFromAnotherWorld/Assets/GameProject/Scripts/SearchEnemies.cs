using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SearchEnemies : MonoBehaviour
{
    [SerializeField] private UnityEvent _winWithoutEnemies;

    private WaitForSeconds _wait = new WaitForSeconds(5f);
    private GameObject _object;

    private void Start()
    {
        StartCoroutine(CheckEnemies());
    }

    private IEnumerator CheckEnemies()
    {
        while (true)
        {
            _object = GameObject.FindGameObjectWithTag("Enemy");

            if (_object == null)
            {
                _winWithoutEnemies.Invoke();
            }

            yield return _wait;
        }
        
    }
}
