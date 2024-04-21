using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
public class EndManager : MonoBehaviour
{
    [SerializeField]
    public float playerHP = 100f;
    [SerializeField]
    public int enemyCount = 5;
    [SerializeField]
    public TextMeshProUGUI text;
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
            AudioManager.instance.Play("YouDied");
            Debug.Log("You died");            
             Debug.Log(Time.time);
            //StartCoroutine(Delay());

        }
        else if (enemyCount <= 0)
        {
            text.text = "You Won";
            AudioManager.instance.Play("YouWon");
            Debug.Log("You Won");
            Debug.Log(Time.time);
            //StartCoroutine(Delay());   

        }
    }

    IEnumerator Delay() {
        //Debug.Log(Time.time);
        yield return new WaitForSeconds(5);
        //Debug.Log(Time.time);
        Debug.Log(Time.time);
        SceneManager.LoadScene("MainMenu");                    
    }
}
