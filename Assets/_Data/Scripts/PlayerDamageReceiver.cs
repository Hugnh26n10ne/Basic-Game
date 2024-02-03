using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    protected PlayerController playerController;

    [SerializeField] private GameObject textPrefabs;
    private void Awake()
    {
        this.playerController = GetComponent<PlayerController>();
    }
    public override void Receive(float damage)
    {
        base.Receive(damage);
        var textDamage = Instantiate(textPrefabs, transform.position, Quaternion.identity, transform);
        textDamage.GetComponent<TextMesh>().text = @$"-{damage.ToString("F2")} ❤️";
        textDamage.GetComponent<TextMesh>().color = Color.red;

        if(this.IsDead()) this.playerController.playerStatus.Dead();
    }
}
