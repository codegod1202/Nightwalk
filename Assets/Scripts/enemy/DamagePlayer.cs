using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float damage = 30f;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    public AudioClip audioClip;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 3f)
        {
            // Decrement the number every 2 seconds
            audioSource.PlayOneShot(audioClip);
            if (Time.time % 2f < Time.deltaTime)
            {
                AudioManager.instance.Play("Grunt");
                player.GetComponent<EndManager>().playerHP -= damage;
            }
        }
    }
}
