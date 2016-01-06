using UnityEngine;
using System.Collections;

public class DianaController : MonoBehaviour {

    public Texture text;
    public float timer;
    private float timerPrivate;
    private int count = 0;
	// Use this for initialization
	void Start () {
        Random rnd = new Random();
        float x = Random.Range(0, Screen.width - 20);
        float y = Random.Range(0, Screen.height - 20);
        print(this.transform.position.x);
        print(this.transform.position.y);
        this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        timerPrivate = timer;
    }

    // Update is called once per frame
    void Update()
    {
        timerPrivate -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Vector2D
            var hitCollider = Physics2D.OverlapPoint(mousePosition); //Collider2D

            if (hitCollider)
            { // mayor X = 7.88, menor y = 4.91; menor x = 7.97 mayor y = -4.97
                Random rnd = new Random();
                float x = Random.Range(-7.5f, 7.5f);
                float y = Random.Range(-4.6f, 4.6f);
                transform.position = new Vector3(x, y, transform.position.z);
                count++;
            }
        }
        if(timerPrivate <= 0)
        {
            Debug.Log("Finished");
            DoPost();
            timerPrivate = timer;
            count = 0;

        }
    }

    void DoPost()
    {
        string url = "http://localhost:21808/api/Rankings";
        WWWForm form = new WWWForm();
        form.AddField("ID", 1);
        form.AddField("Name", "Unity");
        form.AddField("Points", count);
        form.AddField("Key", "XLUGZKPU8OHU8AUOLDP8");
        WWW www = new WWW(url, form);
        StartCoroutine(WaitForRequest(www));
    }
    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.data);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }
}
