using UnityEngine;

public class BackToSpawn : MonoBehaviour
{
    public GameObject player;
    public AudioSource footSteps;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");

        footSteps = GetComponent<AudioSource>();

        footSteps.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = Vector3.zero;
    }
}
