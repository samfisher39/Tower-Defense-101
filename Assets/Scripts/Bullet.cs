﻿using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    [Header("Attributes")]

    public float bulletSpeed = 30f;
    public float bulletDamage = 10f;

    public void Seek(Transform _target)
    {
        target = _target;
    }

	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distancePerFrame = bulletSpeed * Time.deltaTime;

        if (dir.magnitude <= distancePerFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distancePerFrame, Space.World);

	}

    void HitTarget()
    {
        Debug.Log("Hit!");
        Destroy(gameObject);
    }
}
