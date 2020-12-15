using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject EnemyWhoMoves;
    public float Speed;
    private Vector2 _direction;
    private Vector2 targetPos;
    
    private void Move()
    {
        transform.Translate(_direction * Speed * Time.deltaTime);
        
    }
}
