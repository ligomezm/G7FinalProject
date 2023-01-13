using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{

    public LinearIndicator linearIndicator;

    public float maxValue = 100;
    public float minValue = 0;
    public float currentValue = 100;
    //private bool foundLinearIndicator = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable()
    {
        SetLinearIndicator();
    }
    public void SetLinearIndicator()
    {
        if (linearIndicator == null)
        {
            linearIndicator = FindObjectOfType<LinearIndicator>();
            Debug.Log(linearIndicator);
        }
            //Setup the linear indicator by code or do it in inspector
            linearIndicator.SetupIndicator(minValue, maxValue);

            //linearIndicator.SetOrientation(LinearIndicator.Orientation.Horizontal);
            //linearIndicator.reverse = false;
            linearIndicator.SetValue(currentValue);
    }
    //void TryGetLinearIndicator()
    //{
    //    try
    //    {
    //        linearIndicator = FindObjectOfType<LinearIndicator>();
    //    }
    //    catch (System.Exception)
    //    {
    //        foundLinearIndicator = true;
    //        throw;
    //    }
    //}

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (Input.GetKey(KeyCode.D))
        //{
        //    currentValue += 50 * Time.deltaTime;
        //    currentValue = Mathf.Clamp(currentValue, minValue, maxValue);

        //    linearIndicator.SetValue(currentValue);//Use the function SetValue to give the indicator the value to display
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    currentValue -= 50 * Time.deltaTime;
        //    currentValue = Mathf.Clamp(currentValue, minValue, maxValue);

        //    linearIndicator.SetValue(currentValue);
        //}
    }


    public void TakeDamage(float damage)
    {
        currentValue -= damage;

        if (currentValue <= 0)
        {
            //Set Game Over Canvas, sound, stop controller, etc. or Back to the museum

        }
    }

    public void IncreaseLife(float health)
    {
        currentValue += health;
    }

    public void UpdateLifeBar()
    {
        linearIndicator.SetValue(currentValue);
    }
}
