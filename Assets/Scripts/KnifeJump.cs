using UnityEngine;

public class KnifeJump : MonoBehaviour
{
    public float distanceTraveled
    {
        get
        {
            return transform.position.x;
        }
    }
    [SerializeField] private int _speedKnife;
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _cameraOffset;
    [SerializeField] private Vector3 _jumpForce;
    private int scoreGame = 0;
    [SerializeField] private UiChanges UiCanvas;
    private Vector3 _freezVelocity;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddJumpForce();
        }
        if (UiCanvas.GameStageChange() != GameStage.gameStage) return;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(1, 0,0), _speedKnife * Time.deltaTime);
        Camera.main.transform.position = new Vector3(transform.position.x+ _cameraOffset, 0f, -1f);

        if (transform.rotation.z>-135) transform.Rotate(new Vector3(0,0,-100) * Time.deltaTime);
    }

    public void AddJumpForce()
    {
        if (UiCanvas.GameStageChange() != GameStage.gameStage) return;
        Debug.Log("jump force");
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(_jumpForce, ForceMode2D.Impulse);
        Vector3 direction = new Vector3(0, 0 , 22);
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }

    public void PauseUnpause()
    {
        if (UiCanvas.GameStageChange() == GameStage.gameStage)
        {
            _rigidbody.velocity = _freezVelocity;
            _rigidbody.constraints = RigidbodyConstraints2D.None;
        }
        else if (UiCanvas.GameStageChange() == GameStage.pauseStage)
        {
            _freezVelocity = _rigidbody.velocity;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PassageTower")
        {
            scoreGame++;
            UiCanvas.SetTextScore(scoreGame);
        }
        else
        {
            UiCanvas.DeathStageView();
            _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
    }
}