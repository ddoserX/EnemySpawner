using System.Collections;
using System.Collections.Generic;
//using System;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _entity;
    [SerializeField] private float _timeSpawn = 2.0f;
    [SerializeField] private int _maxEntitiesCount = 10;

    private Transform[] _points;
    private List<GameObject> _entities;
    private float _timePassed;

    private void Start() 
    {
        _entities = new List<GameObject>(_maxEntitiesCount);
        _points = new Transform[transform.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = transform.GetChild(i);
        }
    }

    private void Update() 
    {
        _timePassed += Time.deltaTime;

        if (_timePassed >= _timeSpawn && _entities.Count <= _maxEntitiesCount)
        {
            int randomPoint = Random.Range(0, _points.Length - 1);

            GameObject gameObject = Instantiate(_entity, _points[randomPoint].position, Quaternion.identity);
            gameObject.transform.position += new Vector3(0, gameObject.transform.localScale.y / 2, 0);
            
            _entities.Add(gameObject);
            _timePassed = 0.0f;
        }
    }
}
