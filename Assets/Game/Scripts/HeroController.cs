using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour
{
    public static HeroController Instance;

    public float MoveSpeed = 4f;

    public float JumpPower = 500f;

    public Vector3 DefaultPosition;

    public bool isDead = false;
    public bool IsDead
    {
        get { return isDead; }
        set
        {
            if (isDead != value)
            {
                isDead = value;
                if (value)
                {
                    UIManager.Instance.PushUIPanel("UILose");
                    SoundManager.Instance.PlayAudio("Audio_ao");
                }
            }
        }
    }


    private Rigidbody2D Rigidbody2D;
    private HeroAnim HeroAnim;

    void Awake() { Instance = this; }

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        HeroAnim = GetComponent<HeroAnim>();

        DefaultPosition = transform.position;
    }

    void Update()
    {
        if (IsDead)
        {
            HeroAnim.DieState();
            Rigidbody2D.velocity = new Vector2(0f, Rigidbody2D.velocity.y);
            return;
        }

        if (transform.localPosition.y < -500)
        {
            IsDead = true;
        }
    }

    void FixedUpdate()
    {
        if (IsDead) return;

        float h = Input.GetAxis("Horizontal");
        if (Mathf.Abs(h - 0) > 0.01f)
        {
            Rigidbody2D.velocity = new Vector2(h * MoveSpeed, Rigidbody2D.velocity.y);

            HeroAnim.RunState(h < 0);
        }
        else
        {
            HeroAnim.IdleState();
            Rigidbody2D.velocity = new Vector2(0f, Rigidbody2D.velocity.y);
        }

        if (Rigidbody2D.velocity.y == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Rigidbody2D.AddForce(Vector2.up * JumpPower);
                HeroAnim.JumpStart(h < 0);
            }
            else
                HeroAnim.JumpOver();
        }

    }


    public void ResetPlayer()
    {
        transform.position = DefaultPosition;
        IsDead = false;
        HeroAnim.IdleState();
    }
}
