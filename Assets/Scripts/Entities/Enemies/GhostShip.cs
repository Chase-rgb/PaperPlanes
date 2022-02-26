using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostShip : Entity
{
    private Camera cam;
    private float animationSpeed = 0.01f;
    // adjust lines 42, 56, 64 for animations

    // Start is called before the first frame update
    void Start()
    {
        
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        this.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entered ghost ship region");

            transform.parent = cam.transform;
            transform.position += new Vector3(5, -15, 0);
            this.GetComponent<Renderer>().enabled = true;
            StartCoroutine(animateIn());
        }
    }

    IEnumerator animateIn()
    {
        Debug.Log(transform.position.y);
        while (transform.position.y < 10) {
            transform.position += new Vector3(0, 0.1f, 0);
            yield return new WaitForSeconds(animationSpeed);
        }
        cutscene();
    }

    void cutscene() {
        Debug.Log("Cutscene.");
        StartCoroutine(animateToPosition());
    }

    IEnumerator animateToPosition()
    {
        while (transform.position.y < 25) {
            transform.position += new Vector3(0, 0.1f, 0);
            yield return new WaitForSeconds(animationSpeed);
        }

        transform.position += new Vector3(20, 0, 0);
        yield return new WaitForSeconds(animationSpeed*25);

        while (transform.position.y > 20) {
            transform.position += new Vector3(0, -0.1f, 0);
            yield return new WaitForSeconds(animationSpeed);
        }

        yield return new WaitForSeconds(animationSpeed*25);

        // start shooting
    }
}