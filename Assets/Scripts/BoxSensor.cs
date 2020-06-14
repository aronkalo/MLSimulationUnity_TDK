using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class BoxSensor : MonoBehaviour
    {
        public float XBound;

        public float YBound;

        public float ZBound;

        public Transform attachedTransform;

        private Vector3 halfSize;
        public void Start()
        {
            halfSize = new Vector3(XBound / 2, YBound / 2, ZBound / 2);

        }

        public void FixedUpdate()
        {
            RaycastHit hitInfo;
            Physics.BoxCast(attachedTransform.position + halfSize,  halfSize, attachedTransform.forward, out hitInfo);
        }
    }
}
