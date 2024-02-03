using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxEffectMultiplier;
    [SerializeField] private bool infiniteHozirontal;
    [SerializeField] private bool infiniteVertical;

    [SerializeField] private List<Sprite> clouds;

    private float directionCloud;

    // Start is called before the first frame update
    void Start()
    {
        int indexCloud = Random.Range(0,clouds.Count);  
        GetComponent<SpriteRenderer>().sprite = this.clouds[indexCloud];
        this.directionCloud = Random.value;

    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Camera.main.transform.position.y - transform.position.y) > 25) return;
        Vector2 cloudPos = transform.position;
        if (this.directionCloud > 0.5f)
        {
            cloudPos.x += Time.deltaTime * 1.2f;
        }
        else
        {
            cloudPos.x -= Time.deltaTime * 1.2f;
        }
        

        transform.position = cloudPos;
    }
}
