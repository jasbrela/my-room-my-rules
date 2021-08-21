using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private Transform startPos;
    private Vector3 _destination;
    private Vector2 _velocity = Vector2.zero;

    private void Awake()
    {
        #region RESET
        Vector3 pos = startPos.position;
        transform.position = pos;
        _destination = pos;
        #endregion
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _destination = new Vector3(_destination.x, transform.position.y, transform.position.z);
        }
        
        transform.position = Vector2.SmoothDamp(transform.position, _destination,
            ref _velocity, (100 - speed) * 0.01f, maxSpeed, Time.deltaTime);
        
        // maybe add a "check if player clicked two times" to increase max speed and set running anim
    }
}
