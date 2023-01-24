using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeBar : MonoBehaviour
{

    public LinearIndicator linearIndicator;

    public float maxValue = 100;
    public float minValue = 0;
    public float currentValue = 100;
    bool flag = true;
    bool activeAndEnabled = false;
    public DungeonManager dungeonManager;

    //private bool foundLinearIndicator = false;

    // Start is called before the first frame update
    void Start()
    {
        SetLinearIndicator();
    }
    // void Update()
    // {
    //     if (this.isActiveAndEnabled && !activeAndEnabled)
    //     {
    //         GetReferences();
    //         activeAndEnabled = true;
    //     }
    //     return;
    // }
    void Awake()
    {
        
    }
    void OnEnable()
    {
     
        //SetLinearIndicator();
        //ManageScenes.OnSceneLoaded += GetReferences;
        // Debug.Log("Object and behavior have been enabled");
    }
    void OnDisable()
    {
        //ManageScenes.OnSceneLoaded -= GetReferences;
    }

    
    public void GetReferences()
    {
        //Debug.Log("Getting references");
        linearIndicator = FindObjectOfType<LinearIndicator>();
        //Debug.Log("Linear indicator: " + linearIndicator);
        //Setup the linear indicator by code or do it in inspector
        linearIndicator.SetupIndicator(minValue, maxValue);

        //linearIndicator.SetOrientation(LinearIndicator.Orientation.Horizontal);
        //linearIndicator.reverse = false;
        linearIndicator.SetValue(currentValue);
    }
    public void SetLinearIndicator()
    {
        
        //GetReferences();
        // if (linearIndicator == null)
        // {
        //     linearIndicator = FindObjectOfType<LinearIndicator>();
        //     Debug.Log(linearIndicator);
        // }
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
        //ChekLife();
    }

    public void IncreaseLife(float health)
    {
        currentValue += health;
    }

    public void UpdateLifeBar()
    {
        linearIndicator.SetValue(currentValue);
    }

    public void  ChekLife()
    {
        if (currentValue <= 0 && flag)
        {
            try
            {
                dungeonManager.EmptyDungeonsList();
                flag = false;
                ManageScenes.GetInstance().ReloadScene("Level2");
            }
            catch (System.Exception) { }

            //Set Game Over Canvas, sound, stop controller, etc.or Back to the museum
            // Scene scene = SceneManager.GetActiveScene();
            // SceneManager.LoadScene("MainMenu");
            //ManageScenes.GetInstance().ReloadScene("Level2");
        }
        else
        {
            flag = true;
        }
    }
}
