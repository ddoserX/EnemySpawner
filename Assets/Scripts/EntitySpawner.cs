using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _entity;
    [SerializeField] private float _timeSpawn = 2.0f;
    [SerializeField] private int _maxEntitiesCount = 10;
    
    private SpawnPoint[] _points;
    private List<Enemy> _entities;
    private float _timePassed;

    private void Start() 
    {
        _entities = new List<Enemy>(_maxEntitiesCount);
        _points = new SpawnPoint[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _points[i] = transform.GetChild(i).GetComponent<SpawnPoint>();
        }
    }

    private void Update() 
    {
        _timePassed += Time.deltaTime;

        if (_timePassed >= _timeSpawn && _entities.Count <= _maxEntitiesCount)
        {
            Vector3 pointPosition = GetRandomPointPosition();

            Enemy instanceObject = Instantiate(_entity, pointPosition, Quaternion.identity);
            instanceObject.transform.position += new Vector3(0, instanceObject.transform.localScale.y / 2, 0);
            
            _entities.Add(instanceObject);
            _timePassed = 0.0f;
        }
    }

    private Vector3 GetRandomPointPosition()
    {
        int randomPoint = Random.Range(0, _points.Length - 1);

        if (_points[randomPoint].HaveCollide)
        {
            return GetRandomPointPosition();
        }
        else
        {
            return _points[randomPoint].transform.position;
        }
    }
}
