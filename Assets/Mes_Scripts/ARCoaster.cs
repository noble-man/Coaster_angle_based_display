using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCoaster : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _cameToObject;
    float _forwardDot;
    private float _perpDot;

    public float _angle;

	public GameObject[] _drinks;
	GameObject[] _drinksToDisplay;


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

        //_cameToObject = (transform.position - _camera.transform.position);//must be normalized for dot product
        //_cameToObject = Vector3.ProjectOnPlane(_cameToObject, transform.up).normalized;//Flatening the _cameToObject Vector on the coaster plane

        _cameToObject = (transform.position - _camera.transform.position);

        _forwardDot = Vector3.Dot(_cameToObject, transform.forward);//pour savoir comment c'est orienté. 2 vecteurs dans le sens opposés, la valeur est -1.

        _perpDot = Vector3.Dot(_cameToObject, transform.forward);


        _angle = Mathf.Atan2(_perpDot, _forwardDot) * Mathf.Rad2Deg; //Atan2 fait la projection et la normalisation déjà
        

        Debug.Log(_forwardDot);



    }


	void CreateDrinks()
	{
		for (int i = 0; i < _drinks.Length; i++)
		{
			Instantiate(_drinks[i], transform.position /*+ transform.up * 1*/, Quaternion.identity);
		}
	}

    private void Awake()//l'objet se réveille //les méthodes sont private par défaut.
    {
        _camera = Camera.main;
		CreateDrinks();
    }
}
