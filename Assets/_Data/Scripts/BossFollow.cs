using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BossFollow : MonoBehaviour
{
    [SerializeField] Transform Player;
    private float speed = 15f;
    private float disLimit = 0.5f;
    private float rotationSpeed = 2f;

    private Rigidbody2D rb2d;

    private float distance;
    private float velocityVsUp = 0f;
    private bool isCallPoliced = false;

    public bool isHasCollided { get; set; } = false;

    public float timeReturn;

    private void Awake()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
        this.speed = 15f;
        this.disLimit = 1f;

        this.timeReturn = GameManager.GetTimeOnReturn();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameManager.startGame) return;

        // Người chơi CHẾT thì boss sẽ dừng đuổi theo
        if (PlayerController.instance.playerStats.hp < 0) return;

        this.distance = (Player.transform.position - transform.position).magnitude;
        this.velocityVsUp = Player.GetComponent<Rigidbody2D>().velocity.magnitude;
        if (Time.time < timeReturn + 8f + 3f)
        {
            if (velocityVsUp < 5f)
            {
                this.disLimit = 1f;
            }
            else
            {
                this.disLimit = 3f;
            }
            if (Time.time > timeReturn + 6f + 3f && velocityVsUp > 5f && this.isCallPoliced)
            {
                this.disLimit = 10f;
            }
            if (!this.isCallPoliced)
            {
                StartCoroutine(CallPoliceForFiveSeconds());
            }


        }
        else
        {
            if (isHasCollided)
            {
                if (velocityVsUp < 5f)
                {
                    this.disLimit = 1f;
                }
                else
                {
                    this.disLimit = 3f;
                }
                if (velocityVsUp > 5f && this.isCallPoliced)
                {
                    this.disLimit = 10f;
                }
                if (!this.isCallPoliced)
                {
                    StartCoroutine(CallPoliceForFiveSeconds());
                }
            }
            if (velocityVsUp < 3f)
            {
                this.disLimit = 1f;
                if (!this.isCallPoliced)
                {
                    StartCoroutine(CallPoliceForFiveSeconds());
                }
            }
        }
        Invoke(nameof(Follow), 1f);
    }



    private IEnumerator CallPoliceForFiveSeconds()
    {
        ShowPolice();
        yield return new WaitForSeconds(5f);
        HidePolice();
    }
    public void ShowPolice()
    {
        this.isCallPoliced = true;
        if (distance <= 12f)
        {
            this.gameObject.transform.Find("Sprite").gameObject.SetActive(true);
        }
    }
    public void HidePolice()
    {
        if (distance >= 10f)
        {
            this.gameObject.transform.Find("Sprite").gameObject.SetActive(false);
        }
        this.isCallPoliced = false;
    }

    public void setDisLimit(float disLimit)
    {
        this.disLimit = disLimit;
    }

    void Follow()
    {
        Vector3 distance = Player.position - transform.position;

        if (distance.magnitude >= this.disLimit)
        {

            // Quay góc
            Vector3 fromVector = transform.position;
            Vector3 toVector = Player.position;

            Quaternion rotation = Quaternion.FromToRotation(Vector3.right, toVector - fromVector);

            float angle = rotation.eulerAngles.z; // Góc quay trên trục z

            Vector3 newRotation = new Vector3(0, 0, -(90 - angle));
            Quaternion targetQuaternion = Quaternion.Euler(newRotation);


            transform.rotation = Quaternion.Slerp(transform.rotation, targetQuaternion, this.rotationSpeed * Time.fixedDeltaTime);

            // Di chuyển

            Vector3 targetPoint = Player.position - distance.normalized * this.disLimit;

            gameObject.transform.position =
                Vector3.MoveTowards(gameObject.transform.position, targetPoint, this.speed * Time.fixedDeltaTime);

        }
    }
}
