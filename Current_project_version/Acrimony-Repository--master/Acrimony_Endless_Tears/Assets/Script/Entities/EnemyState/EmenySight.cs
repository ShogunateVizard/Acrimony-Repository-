using UnityEngine;
using System.Collections;

public class EmenySight : MonoBehaviour {
    [SerializeField]
    private Enemy enemy;


    //When Player enters view
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            enemy.Target = other.gameObject;
        }
    }

    //Exit the view range
    void OnTriggerExit2D(Collider2D other)
   {
        if (other.tag == "Player")
        {
            enemy.Target = null;
        }

    }
}
