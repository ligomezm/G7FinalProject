using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScriptLinearIndicator : MonoBehaviour
{
    //This script is an example on how to use the linear indicator asset

    public LinearIndicator linearIndicator;

    public float minValue, maxValue;
    public float currentValue;

    void Start()
    {
        //Setup the linear indicator by code or do it in inspector
        linearIndicator.SetupIndicator(minValue,maxValue);


        //linearIndicator.SetOrientation(LinearIndicator.Orientation.Horizontal);
        //linearIndicator.reverse = false;
        linearIndicator.SetValue(currentValue);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            currentValue += 50*Time.deltaTime;
            currentValue = Mathf.Clamp(currentValue, minValue, maxValue);

            linearIndicator.SetValue(currentValue);//Use the function SetValue to give the indicator the value to display
        }
        if (Input.GetKey(KeyCode.A))
        {
            currentValue -= 50 * Time.deltaTime;
            currentValue = Mathf.Clamp(currentValue, minValue, maxValue);

            linearIndicator.SetValue(currentValue);
        }
    }
}
