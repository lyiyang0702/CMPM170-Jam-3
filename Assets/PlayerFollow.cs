using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    Rigidbody2D rb;
    Rigidbody2D targetRb;
    GameObject target;
    [SerializeField]
    float speed;
    Vector3 directionToTarget;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        target = PlayerManager.instance.CurrentPlayer;
        targetRb = target.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (target)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;

            if (targetRb.velocity == Vector2.zero)
            {
                rb.velocity = Vector2.zero;
                return;
            }
            rb.velocity = new Vector2(directionToTarget.x, directionToTarget.y) * speed;

        }

    }

    private void LateUpdate()
    {

    }
}
