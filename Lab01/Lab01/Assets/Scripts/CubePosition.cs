using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class CubePosition : MonoBehaviour
    {
        public float speed;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float posX = transform.position.x;
            float posY = transform.position.y;
            float posZ = transform.position.z;

            transform.position = new Vector3(posX + speed, posY, posZ);
        }
    }
}