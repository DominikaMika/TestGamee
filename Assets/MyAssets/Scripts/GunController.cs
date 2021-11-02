using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAssets
{

    public class GunController : MonoBehaviour
    {
        [SerializeField]
        private GameObject bulletPrefab;

        [SerializeField]
        private Transform startBulletPoint;

        [SerializeField]
        private float bulletSpeed;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // S� fort vi trycker ned spacetagenten s� kastar vi iv�g en kula
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }
        }

        private void Fire()
        {
            // Skapa en ny kopia av bullet objektet och placera denna
            // vid v�r startBulletPoint 
            GameObject obj = Instantiate(bulletPrefab, startBulletPoint.position, startBulletPoint.rotation);

            // Denna rad ser till att beroende p� i vilken riktning startBulletPoint pekar �t
            // s� kommer vi ocks� kasta v�r projektil/bullet i just den riktningen
            Vector3 velocityDirection = startBulletPoint.rotation * Vector3.forward * bulletSpeed;

            // L�t v�r bullet objekt uts�ttas f�r en kraft i just den riktningen
            // som ovan definierades i velocityDirection med den hastigheten
            obj.GetComponent<Rigidbody>().AddForce(velocityDirection);

            // Detta f�rst�r �ter v�r bullet efter 3 sekunder
            Destroy(obj, 3);
        }
    }
}