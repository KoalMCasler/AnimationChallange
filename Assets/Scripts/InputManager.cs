using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Animator cubeAnim;
    [SerializeField]
    private Animator boxAnim;
    public string cubeAnimBoolString;
    public string boxAnimOpenString;
    public string boxAnimCloseString;
    public bool boxIsOpen;
    public bool boxInputEnabled;
    void Start()
    {
        cubeAnim = GameObject.FindWithTag("RotatorCube").GetComponent<Animator>();
        boxAnim = GameObject.FindWithTag("Box").GetComponent<Animator>();
        boxIsOpen = false;
        boxInputEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        CubeInput();
    }
    void FixedUpdate()
    {
        BoxInput();
    }
    void CubeInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(cubeAnim.GetBool(cubeAnimBoolString) == true)
            {
                cubeAnim.SetBool(cubeAnimBoolString,false);
            }
            else
            {
                cubeAnim.SetBool(cubeAnimBoolString,true);
            }
        }
    }
    void BoxInput()
    {
        if(Input.GetButtonDown("OpenBox") && boxInputEnabled)
        {
            boxInputEnabled = false;
            if(boxIsOpen == false)
            {
                boxIsOpen = true;
                boxAnim.SetTrigger(boxAnimOpenString);
                Invoke("ResetInput", 2);
            }
            else
            {
                boxIsOpen = false;
                boxAnim.SetTrigger(boxAnimCloseString);
                Invoke("ResetInput", 2);
            }
        }
    }
    void ResetInput()
    {
        boxInputEnabled = true;
    }
}
