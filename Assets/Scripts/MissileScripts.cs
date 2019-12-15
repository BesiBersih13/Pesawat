using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScripts : MonoBehaviour
{
    public float shootSpeed = 10;
    public GamObject missilePrefab = 10;

    // Referensi terhadap komponen rigidbody pemain
    private Rigidbody2D rb2d;

    private void Start(){
        rb2d = missilePrefab();
    }

    private void FixedUpdate()
    {
    }

    public void SummonMissile(bool isUsedByPlayer){
        var missileTransform = Instantiate(missilePrefab);

        missileTransform.transform.position = transform.position;

        MissileController missileTransformController = missileTransform.GetComponent<MissileController>();

        missileTransformController.SetIsUsedByPlayer(isUsedByPlayer);

    }
}