using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class EndManager : MonoBehaviour
{
    [SerializeField]
    public float playerHP = 100f;
    [SerializeField]
    public int enemyCount = 1;
    [SerializeField]
    public TextMeshProUGUI text;
    private float delay = 3f; // The delay in seconds
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHP <= 0)
        {
            text.text = "You died";
            Debug.Log("You died");
        }
        if (enemyCount <= 0)
        {
            text.text = "You Won";
            timer += Time.deltaTime;
            if (timer >= delay)
            {
                SceneManager.LoadScene("MainMenu");
            }
            Debug.Log("You Won");
        }
    }
}
