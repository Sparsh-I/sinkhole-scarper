using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassagewayController : MonoBehaviour
{
    private bool enterAllowed;
    private string levelName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<RoomDoorInside>())
        {
            levelName = "MC Living Room";
            enterAllowed = true;
        }

        if (collision.GetComponent<RoomDoorOutside>())
        {
            levelName = "MC Room";
            enterAllowed = true;
        }

        if (collision.GetComponent<MainDoorInside>())
        {
            levelName = "Village";
            enterAllowed = true;
        }

        if (collision.GetComponent<MCHouse>())
        {
            levelName = "MC Living Room";
            enterAllowed = true;
        }

        if (collision.GetComponent<CaveTwoEntrance>()) 
        {
            levelName = "Cave Two";
            enterAllowed = true;
        }

        if (collision.GetComponent<MineOneEntrance>())
        {
            levelName = "Mine One";
            enterAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enterAllowed = false;   
    }

    // Update is called once per frame
    private void Update()
    {
        if (enterAllowed && Input.GetKey(KeyCode.W))
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
