using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerElectricReceiver : MonoBehaviour
{
    [SerializeField] private GameObject textPrefabs;

    private PlayerMovement playerMovement;
    private NitroBar nitroBar;
    private double electricBeforeAddPower = 0.0;

    private void Awake()
    {
        this.playerMovement = GetComponentInParent<PlayerMovement>();
        this.nitroBar = GameObject.Find("NitroBar").GetComponent<NitroBar>();
    }

    public virtual void Receive(double electric)
    {
        if (PlayerController.instance.playerStats.hp < 0) return;
        // lưu năng lượng trước khi tự động tăng tốc
        this.electricBeforeAddPower = PlayerStats.Instance.mana;
        this.electricBeforeAddPower = Math.Round(this.electricBeforeAddPower, 2);
        // Cộng thêm lượng mana để tăng tốc
        PlayerStats.Instance.mana += electric;
        // Giữ mana tối đa 100
        PlayerStats.Instance.mana = Math.Clamp(PlayerStats.Instance.mana, 0, 100 + electric);
        PlayerStats.Instance.mana = Math.Round(PlayerStats.Instance.mana, 2);

        var textElectric = Instantiate(textPrefabs, transform.position, Quaternion.identity, transform);
        textElectric.GetComponent<TextMesh>().text = $"+{electric:F2} 🛢";
        textElectric.GetComponent<TextMesh>().color = new Color(0.03207541f, 0.7135026f, 1, 1);

        // Nếu tăng tốc
        this.playerMovement.PlayerAuto(true, this.electricBeforeAddPower);

        this.nitroBar.SetNitro(PlayerStats.Instance.mana);
    }
}
