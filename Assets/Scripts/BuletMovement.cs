using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuletMovement : MonoBehaviour
{
    public float rangeBulletImpact = 10f;

    private Transform target;

    public GameObject enemy;

    public float speed = 70f;
    public GameObject impackEffect;

    public int bulletDamage;


    //public GameObject balloon;



    public void seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
            GameObject effectInstance = (GameObject)Instantiate(impackEffect, transform.position, transform.rotation);
            Destroy(effectInstance, 2f);
           

            Destroy(gameObject);
            target.GetComponent<EnemieMovement>().health -= bulletDamage; //pass target not as Transform but as EnemieMovement (target.transform would still work)
    }


    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, rangeBulletImpact);
    //}


}
