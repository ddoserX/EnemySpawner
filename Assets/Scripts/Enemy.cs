using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;

    private Vector3 _direction = Vector3.forward;

    private void Update() 
    {
        Move();
    }

    private void Move()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }
}
