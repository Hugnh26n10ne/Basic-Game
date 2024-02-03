using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerNitroReceiver : ParameterReceivers
{
    [SerializeField] private NitroBar nitroBar;
    [SerializeField] private GameObject textPrefabs;

    private void Start()
    {
        this.nitroBar = GameObject.Find("NitroBar").GetComponent<NitroBar>();
    }
    public override void Receive(float nitro)
    {
        if (PlayerStats.Instance.mana > 100) return;
        PlayerStats.Instance.mana += nitro;
        PlayerStats.Instance.mana = Math.Clamp(PlayerStats.Instance.mana, 0, 100);
        PlayerStats.Instance.mana = Math.Round(PlayerStats.Instance.mana, 2);

        var textNitro = Instantiate(textPrefabs, transform.position, Quaternion.identity, transform);
        textNitro.GetComponent<TextMesh>().text = $"+{nitro:F2} 🛢";
        textNitro.GetComponent<TextMesh>().color = new Color(0.03207541f, 0.7135026f, 1, 1);

        this.nitroBar.SetNitro(PlayerStats.Instance.mana);
    }
}
