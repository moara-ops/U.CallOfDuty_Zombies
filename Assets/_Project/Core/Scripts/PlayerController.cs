using System;
using UnityEngine;
using Unity.XR.CoreUtils;

namespace COD.Core
{
   public class PlayerController : MonoBehaviour
   {
      [SerializeField] private Player player;

      private XROrigin _xrOrigin;
      private Rigidbody _rigidbody;
      private CapsuleCollider _capsuleCollider;
      
      private void Awake()
      {
         _rigidbody = GetComponent<Rigidbody>();
         _capsuleCollider = GetComponentInChildren<CapsuleCollider>();
      }

      private void Update()
      {
         UpdateColliderToPlayer();
      }

      private void UpdateColliderToPlayer()
      {
         Vector3 center = _xrOrigin.CameraInOriginSpacePos;
         _capsuleCollider.height = Mathf.Clamp(_xrOrigin.CameraInOriginSpaceHeight, 1f, 2.5f);
         _capsuleCollider.center = new Vector3(center.x, _capsuleCollider.height / 2, center.z);
      }
   }
}
