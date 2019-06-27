using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCoaster : MonoBehaviour
{
    Camera _camera;
    private Vector3 _cameToObject;
   // float _forwardDot;
   // private float _perpDot;

   // public float _angle;

	public GameObject[] _drinks;
	GameObject[] _drinksToDisplay;


    private void Awake()//l'objet se réveille //les méthodes sont private par défaut.
    {
        _camera = Camera.main;

        CreateDrinks();
    }


    // Start is called before the first frame update
    void Start()//premiere frame de l'objet
    {
        
    }

    // Update is called once per frame
    void Update()//une fois par frame
    {
        //1
        /*
            //transform.position = Vector3.right * Time.time;
            Debug.Log(Time.time);
            //c-à-d transform.position = new Vector3(1,0,0);
            //.position modifie la position global !!
            transform.localPosition = Vector3.right * Time.time;
        */

        //2
        //GameObject.FindGameObjectsWithTag("MainCamera");
        //gameObject.name = "toto";
        //DisplayDrink(Mathf.FloorToInt(Time.time));
        

        //Debug.Log(GetIndexFromAngle(Time.time * 36));

         DisplayDrink(GetIndexFromAngle(GetAngleFromCamera()));
    

    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    int GetIndexFromAngle(float angle)
    {
        angle = angle % 360;

        return Mathf.FloorToInt(angle/360 * _drinksToDisplay.Length);
    }


	void CreateDrinks()
	{
        _drinksToDisplay = new GameObject[_drinks.Length];

        for (int i = 0; i < _drinks.Length; i++)
		{
			GameObject drinkGo = Instantiate(_drinks[i], transform.position /*+ transform.up * 1*/, Quaternion.identity);
            _drinksToDisplay[i] = drinkGo;
            drinkGo.transform.SetParent(transform);

           

        }
	}

    float GetAngleFromCamera()
    {

        //_cameToObject = (transform.position - _camera.transform.position);//must be normalized for dot product
        //_cameToObject = Vector3.ProjectOnPlane(_cameToObject, transform.up).normalized;//Flatening the _cameToObject Vector on the coaster plane
 
        _cameToObject = (transform.position - _camera.transform.position);

        float _forwardDot = Vector3.Dot(_cameToObject, transform.forward);//pour savoir comment c'est orienté. 2 vecteurs dans le sens opposés, la valeur est -1.

        float _perpDot = Vector3.Dot(_cameToObject, transform.right);


        return Mathf.Atan2(_perpDot, _forwardDot) * Mathf.Rad2Deg + 180; //Atan2 fait la projection et la normalisation déjà
        //adjust range from 0 to 360



    }

    void DisplayDrink(int index)
    {

        index = index % _drinksToDisplay.Length;

        for (int i = 0; i < _drinksToDisplay.Length; i++)
        {
            if (index == i)
            {
                _drinksToDisplay[i].SetActive(true);
            }
            else
            {
                _drinksToDisplay[i].SetActive(false);
            }
        }
        }
}

 

