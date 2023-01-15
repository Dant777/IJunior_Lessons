using System.Collections;
using UnityEngine;

public class CriminalRespawner : MonoBehaviour
{
    [SerializeField] private Transform _respawnContainer;
    [SerializeField] private Criminal _template;
    [SerializeField] private float _respawnTime = 2f;

    private Transform[] _respawnPoints;
    private WaitForSeconds _waitForSeconds;

    private void OnEnable()
    {
        _waitForSeconds = new WaitForSeconds(_respawnTime);
    }

    private void Start()
    {
        _respawnPoints = new Transform[_respawnContainer.childCount];

        for (int i = 0; i < _respawnContainer.childCount; i++)
        {
            _respawnPoints[i] = _respawnContainer.GetChild(i);
        }

        var timeStopJob = StartCoroutine(RespawnObject());
    }

    private IEnumerator RespawnObject()
    {
        bool enable = true;

        while (enable == true)
        {
            yield return _waitForSeconds;
            int index = Random.Range(0, _respawnContainer.childCount);
            var point = _respawnPoints[index];
            Debug.Log($" респ, index {point.name}");
            Criminal newGameObject = Instantiate(_template, point.position, point.rotation);
        }
    }
}
