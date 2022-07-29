using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaliforniaPortal : MonoBehaviour
{
    public GameObject player;
    public string newGameScene;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            float playerX = player.transform.position.x;
            float playerZ = player.transform.position.z;
            float portalX = transform.position.x;
            float portalZ = transform.position.z;

            float distance = Mathf.Sqrt(Mathf.Pow(portalX - playerX, 2) + Mathf.Pow(portalZ - playerZ, 2));


            // Detect if player is inside of portal
            if (distance < 1)
            {
                SceneManager.LoadScene(newGameScene);
            }
        }
    }
}
