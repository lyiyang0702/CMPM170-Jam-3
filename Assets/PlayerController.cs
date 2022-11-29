using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform target;
    public float runSpeed;
    private Rigidbody2D _rb;
    //Get the value for the animator. 
    [SerializeField]
    private Animator animator;
    Vector2 _offset;
    void Start()
    {
        target = PlayerManager.instance.Players[0].transform;
        //_rb = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        target = PlayerManager.instance.CurrentPlayer.transform;
        _offset = transform.position - target.position;


    }



}
