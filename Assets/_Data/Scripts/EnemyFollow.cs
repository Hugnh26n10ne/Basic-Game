using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] Transform Player;
    protected float speed = 7f;
    protected float disLimit = 0.5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Invoke(nameof(Follow),2f);
        speed = Random.Range(4f, 9f);
    }

    void Follow()
    {
        Vector3 distance = Player.position - transform.position;

        if (distance.magnitude >= this.disLimit)
        {
            Vector3 targetPoint = Player.position - distance.normalized * this.disLimit;

            gameObject.transform.position =
                Vector3.MoveTowards(gameObject.transform.position, targetPoint, this.speed * Time.deltaTime);
        }
    }
}
