using UnityEngine;
using UnityEngine.SocialPlatforms;

public class EnemyTerritory : MonoBehaviour
{
    public BoxCollider Territory;
    GameObject _player;
    bool _playerInTerritory;

    public GameObject Enemy;
    BasicEnemy _basicenemy;

    // Use this for initialization
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _basicenemy = Enemy.GetComponent<BasicEnemy>();
        _playerInTerritory = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerInTerritory == true)
        {
            _basicenemy.MoveToPlayer();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _playerInTerritory = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            _playerInTerritory = false;
        }
    }
}

public class BasicEnemy : MonoBehaviour
{
    public Transform Target;
    public float Speed = 3f;
    public float Attack1Range = 1f;
    public int Attack1Damage = 1;
    public float TimeBetweenAttacks;


    // Use this for initialization
    void Start()
    {
        Rest();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveToPlayer()
    {
        //rotate to look at player
        transform.LookAt(Target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        //move towards player
        if (Vector3.Distance(transform.position, Target.position) > Attack1Range)
        {
            transform.Translate(new Vector3(Speed * Time.deltaTime, 0, 0));
        }
    }

    public void Rest()
    {

    }
}