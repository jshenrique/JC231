using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;

    [Header("Config Player")]
    public float movementSpeed = 3f;

    private Vector3 direction;

    private Animator anim;
    private bool isWalk;

    // Atack
    public ParticleSystem fxAttack;
    private bool isAtack;
    public Transform hitBox;
    [Range(0.2f, 1f)]
    public float hitRange = 0.5f;
    public Collider[] hitInfo;
    public LayerMask hitMask; // oq posso atingir
    public int amountDmg;

    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        MoveCharacter();
        UpdateAnimator();

    }

    void Inputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Fire1") && isAtack == false)
        {
            Attack();
        }
    }

    void MoveCharacter()
    {
        direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
            isWalk = true;
        }
        else
        {
            isWalk = false;
        }

        controller.Move(direction * movementSpeed * Time.deltaTime);
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
        Invoke(nameof(ParticulaAttack), 0.3f);
        isAtack = true;

        hitInfo = Physics.OverlapSphere(hitBox.position, hitRange, hitMask);

        foreach (Collider c in hitInfo)
        {
            c.gameObject.SendMessage("GetHit", amountDmg, SendMessageOptions.DontRequireReceiver);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (hitBox != null)
        {
            Gizmos.DrawSphere(hitBox.position, hitRange);
        }
    }

    void AtackIsDone()
    {
        isAtack = false;
    }

    void ParticulaAttack()
    {
        fxAttack.Emit(1);
    }

    void UpdateAnimator()
    {
        anim.SetBool("isWalk", isWalk);
    }
}
