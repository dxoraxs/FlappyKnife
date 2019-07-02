using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _towersPrefabs;
    [SerializeField] private int _numberOfObjects, _topBarrier, _botBarrier;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private KnifeJump player;
    [SerializeField] private int _recycleOffset, _offsetTower;
    [SerializeField] private DataMemory _dataSO;
    [SerializeField] private bool _spawnNewRandomNumber;

    private Vector3 _nextPosition;
    private Queue<GameObject> _objectQueue;
    private int _randomNumberTower;
    
    void Start()
    {
        if (_spawnNewRandomNumber) _dataSO.NumberBackground = Random.Range(0, _towersPrefabs.Length);
        _randomNumberTower = _dataSO.NumberBackground;

        _objectQueue = new Queue<GameObject>(_numberOfObjects);
        _nextPosition = _startPosition;
        for (int i = 0; i < _numberOfObjects; i++)
        {
            GameObject o = Instantiate(_towersPrefabs[_randomNumberTower], transform);
            Recycle(o);
        }
    }

    void Update()
    {
        if (player == null) return;
        if (_objectQueue.Peek().transform.localPosition.x + _recycleOffset < player.distanceTraveled)
        {
            Recycle();
        }
    }

    private void Recycle(GameObject o = null)
    {
        if (o == null) o = _objectQueue.Dequeue();
        o.transform.localPosition = _nextPosition;
        _nextPosition.x += _offsetTower;
        _nextPosition.y = 0 + Random.Range(_topBarrier, _botBarrier);
        _objectQueue.Enqueue(o);
    }
}