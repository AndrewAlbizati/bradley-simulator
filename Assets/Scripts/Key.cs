using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject player;
    public GameObject keybindLabel;
    public GameObject gameControllerObject;

    private GameController gameController;

    private bool isVisible = false;
    private string text;

    // Start is called before the first frame update
    void Start()
    {
        gameController = gameControllerObject.GetComponent<GameController>();

        text = "Press " + gameController.actionKey.ToString() + " to pickup key";

        if (PlayerPrefs.HasKey("keyPickedUp"))
        {
            gameObject.SetActive(false);
            return;
        }
        else if (gameController.GetTaskIndex() >= 7)
        {
            isVisible = true;
        }

        gameObject.GetComponent<MeshRenderer>().enabled = isVisible;
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isVisible)
        {
            if (gameController.GetTaskIndex() < 7)
            {
                return;
            }
            isVisible = true;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        if (!player.GetComponent<PlayerMovement>().IsRiding() && !gameController.IsPaused())
        {
            float playerX = player.transform.position.x;
            float playerZ = player.transform.position.z;
            float keyX = transform.position.x;
            float keyZ = transform.position.z;

            float distance = Mathf.Sqrt(Mathf.Pow(keyX - playerX, 2) + Mathf.Pow(keyZ - playerZ, 2));

        
            TMP_Text mText = keybindLabel.GetComponent<TMP_Text>();
            mText.SetText(text);

            if (distance < 5 && gameController.GetTaskIndex() >= 7)
            {
                keybindLabel.SetActive(true);
                if (Input.GetKeyDown(gameController.actionKey))
                {
                    gameController.IncrementTaskIndex();

                    PlayerPrefs.SetInt("keyPickedUp", 1);
                    keybindLabel.SetActive(false);
                    gameObject.SetActive(false);
                    return;
                }
                return;
            }
        }

        if (keybindLabel.GetComponent<TMP_Text>().text == text)
        {
            keybindLabel.SetActive(false);
        }
    }
}
