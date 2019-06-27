using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalRotation : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _cameToObject;
    float _forwardDot;
    private float _perpDot;

    public float _angle { get; private set; }

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

        _cameToObject = (transform.position - _camera.transform.position).normalized;//must be normalized for dot product(produit scalaire)

        _forwardDot = Vector3.Dot(_cameToObject, transform.forward);//pour savoir comment c'est orienté. 2 vecteurs dans le sens opposés, la valeur est -1.


        _perpDot = Vector3.Dot(_cameToObject, transform.forward);

        _angle = _perpDot >= 0? Mathf.Acos(_forwardDot): 180 - Mathf.Acos(_forwardDot)*Mathf.Rad2Deg;


        Debug.Log(_forwardDot);






       
   

    }
    private void Awake()//l'objet se réveille //les méthodes sont private par défaut.
    {
        _camera = Camera.main;
    }
}
