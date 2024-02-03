using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBrokenController : MonoBehaviour
{
    [SerializeField] private List<GameObject> carBrokenObject;
    private GameObject carBrokenCurrent;
    // Start is called before the first frame update
    void Start()
    {
        this.carBrokenCurrent = this.carBrokenObject[Random.Range(0, this.carBrokenObject.Count)];
    }

    public GameObject GetCarBrokenCurrent()
    {
        return this.carBrokenCurrent;
    }
}
