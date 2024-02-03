using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyBoardHandler : MonoBehaviour
{
    public Button btnA;
    public Button btnW;
    public Button btnS;
    public Button btnD;
    public Button btnJ;
    public Button btnSpace;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            PressButton(btnA);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            ReleaseButton(btnA);
        }



        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            PressButton(btnW);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            ReleaseButton(btnW);
        }


        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            PressButton(btnS);
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            ReleaseButton(btnS);
        }


        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            PressButton(btnD);
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            ReleaseButton(btnD);
        }

        if (Input.GetKey(KeyCode.J))
        {
            PressButton(btnJ);
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            ReleaseButton(btnJ);
        }


        if (Input.GetKey(KeyCode.Space))
        {
            PressButton(btnSpace);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ReleaseButton(btnSpace);
        }


    }

    private void PressButton(Button btn)
    {
        if (EventSystem.current != null)
        {
            ExecuteEvents.Execute(btn.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
        }
    }

    private void ReleaseButton(Button btn)
    {
        if (EventSystem.current != null)
        {
            ExecuteEvents.Execute(btn.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerUpHandler);
        }
    }
}
