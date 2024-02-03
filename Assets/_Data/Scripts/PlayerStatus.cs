using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject gameOver;
    public GameObject gamePlay;
    public GameObject StunEffect;
    public GameObject coolDownStun;
    public GameObject effectGameobject;
    public bool hasCollided { get; set; } = false;
    private void Awake()
    {
        this.playerController = GetComponent<PlayerController>();
        this.gameOver = GameObject.Find("DefeatManager");
        this.gamePlay = GameObject.Find("PlayManager");
        this.StunEffect = GameObject.Find("StunEffect");
        this.StunEffect.SetActive(false);
    }
    private void Start()
    {
        gameOver.SetActive(false);
        gamePlay.SetActive(true);
    }

    public virtual void Dead()
    {
        gamePlay.SetActive(false);
        gameOver.SetActive(true);

    }

    public virtual void Stun(float stunDuration)
    {
        var coolDownClone = Instantiate(coolDownStun, effectGameobject.transform.position, effectGameobject.transform.localRotation, effectGameobject.transform);
        coolDownClone.GetComponent<CoolDownStunHandler>().SetTimeDelay(stunDuration);

        this.StunEffect.SetActive(true);
        playerController.playerMovement.Stun();
        StartCoroutine(UnStunAfterDelay(stunDuration));
    }
    private IEnumerator UnStunAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);
        playerController.playerMovement.DisStun();
        this.StunEffect.SetActive(false);
    }
}
