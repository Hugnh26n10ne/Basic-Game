using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]private float speedEnemy;
    // Start is called before the first frame update
    void Start()
    {
        this.speedEnemy = 6f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Người chơi chết thì sẽ không cho enemy di chuyển nữa

        if (PlayerController.instance.damageReceiver.IsDead()) return;

        if (gameObject.GetComponent<EnemyController>().hasCollision) return;
        Vector3 newPos = Vector3.down * this.speedEnemy + gameObject.transform.position;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, newPos , Time.fixedDeltaTime * this.speedEnemy);
    }
}
