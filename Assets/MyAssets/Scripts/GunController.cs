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
            // Så fort vi trycker ned spacetagenten så kastar vi iväg en kula
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }
        }

        private void Fire()
        {
            // Skapa en ny kopia av bullet objektet och placera denna
            // vid vår startBulletPoint 
            GameObject obj = Instantiate(bulletPrefab, startBulletPoint.position, startBulletPoint.rotation);

            // Denna rad ser till att beroende på i vilken riktning startBulletPoint pekar åt
            // så kommer vi också kasta vår projektil/bullet i just den riktningen
            Vector3 velocityDirection = startBulletPoint.rotation * Vector3.forward * bulletSpeed;

            // Låt vår bullet objekt utsättas för en kraft i just den riktningen
            // som ovan definierades i velocityDirection med den hastigheten
            obj.GetComponent<Rigidbody>().AddForce(velocityDirection);

            // Detta förstör åter vår bullet efter 3 sekunder
            Destroy(obj, 3);
        }
    }
}