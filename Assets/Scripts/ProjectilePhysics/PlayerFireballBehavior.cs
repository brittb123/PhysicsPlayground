using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireballBehavior : MonoBehaviour
{

    private Transform target;
    public Rigidbody projectille;


    public float airTime;
    public float ShootCooldown;

    private Vector3 _displacement = new Vector3();
    private Vector3 _acceleration = new Vector3();
    private Vector3 _initialVel = new Vector3();
    private Vector3 _finalVel = new Vector3();
  
    private float _shootCooldown;

    private void Awake()
    {
        _shootCooldown = ShootCooldown;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && _shootCooldown <= 0)
        {
            LanuchProjectile();
            _shootCooldown = ShootCooldown;
        }
        else
            _shootCooldown -= Time.deltaTime;
    }

    public void LanuchProjectile()
    {

        Ray castPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(castPoint, out hit))
        {
            _displacement = hit.point - transform.position;
        }

       
        _acceleration = Physics.gravity;
        _initialVel = FindInitialVelocity(_displacement, _acceleration, airTime);
        _finalVel = FindFinalVelocity(_initialVel, _acceleration, airTime);

        Rigidbody projectileInstance = Instantiate(projectille, transform.position, transform.rotation);
        projectileInstance.AddForce(_initialVel, ForceMode.VelocityChange);
    }

    private Vector3 FindFinalVelocity(Vector3 intialVel, Vector3 acceleration, float time)
    {
        //v = v0 + at
        Vector3 finalVelocity;

        finalVelocity = intialVel + acceleration * time;

        return finalVelocity;
    }

    private Vector3 FindDisplacement(Vector3 initialVelocity, Vector3 acceleration, float time)
    {
        //deltaX = v0t + (1/2)(a*t^2)
        Vector3 displacement = initialVelocity * time + (1 / 2) * acceleration * time * time;

        return displacement;
    }

    private Vector3 FindInitialVelocity(Vector3 displacement, Vector3 acceleration, float time)
    {
        //deltaX - (1/2)*a*t^2 = v0*t
        //v0 = deltaX/t - (1/2)*a*2
        Vector3 initialVelocity = displacement / time - 0.5f * acceleration * time;

        return initialVelocity;
    }
}
