/*public class ItemDrop : MonoBehaviour {
    public GameObjectpp[] items = new GameObject[3];

    Transform trans;
    GameObject obj;

    void Start() {
        trans = GetComponent<Transform>();
        obj = GetComponent<GameObject>();
    }

    void Update() {

    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Alien") {
            Vector2 v = new Vector2(0f, -1f);
            trans.position = other.transform.position + v;
            StartCoroutine("dropTheItems");
        }
    }

    IEnumerator dropTheItems() {
        int maxItems = 10;
        yield return new WaitForSecond(0.3f);
        for (int = 0, i < maxItems; i++) {
            int rand = Random.Range(0,3);
            yield return new WaitForSecond(0.3f);
            Instantiate(items[rand], trans.position, Quaternion.identity);
        }

        Destroy(this.gameObject);
    }
}*/