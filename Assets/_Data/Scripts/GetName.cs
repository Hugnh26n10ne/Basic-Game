using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetName : MonoBehaviour
{

    // Update is called once per frame
    void LateUpdate()
    {
        GetNames();
    }

    public void GetNames()
    {
        GameObject.Find("Name").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("user_name");
    }

}
