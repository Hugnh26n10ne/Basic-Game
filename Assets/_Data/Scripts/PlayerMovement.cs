using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    [Header("Car settings")]
    [SerializeField] protected float accelerationFactor = 5f;
    [SerializeField] protected float turnFactor = 3.5f;
    [SerializeField] protected float driftFactor = 0.95f;
    [SerializeField] protected float maxSpeed = 10f; // trạng thái bình tường đạt tốc độ tối đa


    // local variables
    private float accelerationInput = 0;
    private float steeringInput = 0;
    private float rotationAngle = 0;
    private float velocityVsUp = 0;


    // Components
    Rigidbody2D rb2d;

    private bool isNitroActive = false;
    private bool isAutoPlay = false;
    private float nitroMaxSpeed = 20f; // trạng thái nitro tốc độ tối đa
    private float currentNitroSpeed = 0f;
    protected float spawnDelay = 0.1f;
    protected float spawnTimer = 0f;


    // Stun status
    private bool isStunned = false;


    private NitroBar nitroBar;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        nitroBar = GameObject.Find("NitroBar").GetComponent<NitroBar>();
    }


    //Frame-rate independent for physics calculations
    private void FixedUpdate()
    {
        if (!GameManager.startGame) return;

        ApplyEngineForce();

        KillOrthogonalVelocity();

        ApplySteering();

        ApplyBraking();

        SuddenAcceleratiton();
    }

    public void ApplyEngineForce()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !Input.GetKey(KeyCode.Space) && !isAutoPlay)
        {
            isNitroActive = false;
            ActiveSpeed(isNitroActive);
        }
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && isAutoPlay)
        {
            ActiveSpeed(isAutoPlay);
        }


        //Tính toán vận tốc khi chúng ta đi tiến
        velocityVsUp = Vector2.Dot(transform.up, rb2d.velocity);

        if(velocityVsUp < 0 && accelerationInput > 0f)
        {
            rb2d.velocity *= Vector2.Lerp(rb2d.velocity, (rb2d.velocity) / (maxSpeed), Time.fixedDeltaTime * 3);
        }

        // Giới hạn tốc độ không vượt quá tốc độ tối đa và khi đó còn di chuyển "tiến"
        if (velocityVsUp > maxSpeed && accelerationInput > 0f)
            return;
        // Giới hạn tốc độ lùi và khi đó còn di chuyển "lùi"
        if (velocityVsUp < -maxSpeed * 0.5f && accelerationInput < 0)
            return;
        // Giới hạn chúng ta không thể đi quá tốc độ
        if (rb2d.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0)
            return;
        // Khi chúng ta dừng di chuyển thì sẽ giảm tốc độ đến khi dừng
        if (accelerationInput == 0)
        {
            if (velocityVsUp >= maxSpeed * 0.3)
            {
                rb2d.drag = Mathf.Lerp(rb2d.drag, (float)maxSpeed / 2, Time.fixedDeltaTime / (maxSpeed / 2));
            }
            else
            {
                rb2d.drag = Mathf.Lerp(rb2d.drag, 3.0f, Time.fixedDeltaTime * 3);
            }
        }
        else
        {
            rb2d.drag = 0;
        }

        // Tạo lực đẩy cho động cơ
        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;

        //Tác dụng lực đẩy vào xe -> Xe di chuyển
        rb2d.AddForce(engineForceVector, ForceMode2D.Force);
    }

    public void ApplySteering()
    {

        // Giới hạn khả năng quay của xe
        float minSpeedBeforeAllowTurningFactor = (rb2d.velocity.magnitude / 12);
        minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);

        // Cập nhật góc quay
        rotationAngle -= steeringInput * turnFactor * minSpeedBeforeAllowTurningFactor;

        // Áp dụng góc quay cho xe băng cách di chuyển góc quay
        rb2d.MoveRotation(rotationAngle);
    }

    public void ApplyBraking()
    {
        if (Input.GetKey(KeyCode.J) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)))
        {
            driftFactor = 0.95f;
            turnFactor = 3.5f;
        }
        else if (Input.GetKey(KeyCode.J) && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)))
        {
            driftFactor = 0.95f;
            turnFactor = 3.5f;
        }
        else if (Input.GetKey(KeyCode.J))
        {
            rb2d.velocity *= 0.95f;
            rb2d.drag = Mathf.Lerp(rb2d.drag, 3.0f, Time.fixedDeltaTime * 3);
        }

    }

    public void SuddenAcceleratiton()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && Input.GetKey(KeyCode.Space) && PlayerStats.Instance.mana > 0)
        {

            isNitroActive = true;
            this.currentNitroSpeed = Mathf.Min(this.currentNitroSpeed, (float)maxSpeed);
            float MaxSpeed = isNitroActive ? nitroMaxSpeed : maxSpeed;
            if (rb2d.velocity.magnitude < MaxSpeed)
            {
                ActiveSpeed(isNitroActive);
            }

        }
    }

    public void PlayerAuto(bool isAutoPlay, double currentPower)
    {

        if (velocityVsUp < nitroMaxSpeed)
        {
            StartCoroutine(ActiveSpeedAuto(isAutoPlay, currentPower));
        }

        if (PlayerStats.Instance.mana <= currentPower)
        {
            isAutoPlay = false;
        }
    }

    private IEnumerator ActiveSpeedAuto(bool isAutoPlay, double currentNitro)
    {
        while (isAutoPlay)
        {
            yield return new WaitForSeconds(spawnDelay);

            if (isAutoPlay && PlayerStats.Instance.mana >= currentNitro && rb2d.velocity.magnitude <= nitroMaxSpeed)
            {
                this.currentNitroSpeed = rb2d.velocity.magnitude;

                if (PlayerController.instance.playerMovement.GetStunStatus()) yield break;

                rb2d.velocity *= Mathf.Lerp(1f, ((float)nitroMaxSpeed / (float)currentNitroSpeed) * 3, Time.fixedDeltaTime * 3);

                float manaConsumption = rb2d.velocity.magnitude * Time.fixedDeltaTime * 3;

                if (PlayerStats.Instance.mana <= 0) yield break;

                PlayerStats.Instance.mana -= manaConsumption;

                this.nitroBar.SetNitro((float)PlayerStats.Instance.mana);
            }
            else
            {
                isAutoPlay = false;
                rb2d.velocity = Vector2.Lerp(rb2d.velocity, rb2d.velocity.normalized * maxSpeed, Time.fixedDeltaTime * 3);
            }
        }
    }


    public void ActiveSpeed(bool isPower)
    {
        if (isPower)
        {
            // Lấy giá trị tốc độ hiện tại
            this.currentNitroSpeed = rb2d.velocity.magnitude;

            if (PlayerController.instance.playerMovement.GetStunStatus()) return;
            // Tăng tốc độ dần lên max nitro
            rb2d.velocity *= Mathf.Lerp(1f, (float)nitroMaxSpeed / (float)currentNitroSpeed, Time.fixedDeltaTime * 3);

            // Giảm mana dựa trên tốc độ mới của xe
            float manaConsumption = rb2d.velocity.magnitude * Time.fixedDeltaTime;

            PlayerStats.Instance.mana -= manaConsumption;
            // Đảm bảo mana không âm
            PlayerStats.Instance.mana = Math.Max(PlayerStats.Instance.mana, 0.0);

            this.nitroBar.SetNitro(PlayerStats.Instance.mana);
        }
        else
        {
            // Ngừng sử dụng nitro và giảm tốc độ dần về mức trước khi kích hoạt nitro
            rb2d.velocity = Vector2.Lerp(rb2d.velocity, rb2d.velocity.normalized * maxSpeed, Time.fixedDeltaTime * 3);
        }
    }

    public void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb2d.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(rb2d.velocity, transform.right);

        rb2d.velocity = forwardVelocity + rightVelocity * driftFactor;
    }


    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }

    private float GetLateralVelocity()
    {
        return Vector2.Dot(transform.right, rb2d.velocity);
    }

    public float GetVelocityMagnitude()
    {
        return rb2d.velocity.magnitude;
    }
    public bool IstireScreeching(out float lateralVelocity, out bool isBreaking)
    {
        lateralVelocity = GetLateralVelocity();
        isBreaking = false;

        if (accelerationInput < 0 && velocityVsUp > 0)
        {
            isBreaking = true;
            return true;
        }
        if (Mathf.Abs(GetLateralVelocity()) > 4.0f)
        {
            return true;
        }

        return false;
    }

    public bool IsGoStraight(out bool isStraighting)
    {
        isStraighting = false;

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && Input.GetKey(KeyCode.J))
        {
            isStraighting = true;
            return true;
        }
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && Input.GetKey(KeyCode.Space) && PlayerStats.Instance.mana > 0)
        {
            isStraighting = true;
            return true;
        }

        isStraighting = false;
        return false;
    }

    public virtual void Stun()
    {
        if (rb2d != null)
        {
            // Kiểm tra xem giá trị isNaN có phải ko
            if (!float.IsNaN(rb2d.velocity.x) && !float.IsNaN(rb2d.velocity.y))
            {
                rb2d.velocity = Vector2.zero;
                //rb2d.Sleep();
            }
            else
            {
                Debug.LogWarning("Invalid velocity values detected. Stun not applied.");
            }

            this.isStunned = true;
            rb2d.isKinematic = true;
        }
        else
        {
            Debug.LogWarning("Rigidbody2D component is missing. Stun not applied.");
        }
    }

    public virtual void DisStun()
    {
        rb2d.isKinematic = false;
        //rb2d.WakeUp();
        rb2d.velocity = Vector2.zero;
        this.isStunned = false;

    }

    public bool GetStunStatus()
    {
        return isStunned;
    }

}
