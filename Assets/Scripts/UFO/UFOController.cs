using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AncientAliens.UFO
{
    [RequireComponent(typeof(SimpleMove), typeof(TractorBeam))]
    public class UFOController : MonoBehaviour
    {
        Controls controls;
        SimpleMove simpleMove;
        TractorBeam tractorBeam;

        private void Awake()
        {
            controls = new Controls();
            simpleMove = GetComponent<SimpleMove>();
            tractorBeam = GetComponent<TractorBeam>();
        }

        private void OnEnable()
        {
            controls.Enable();
            controls.Player.Action.performed += (ctx) => {
                if (tractorBeam.HasTileObject())
                {
                    var result = tractorBeam.DropTileObject();
                    //if (result) print("Dropped obj");

                }
                else
                {
                    var result = tractorBeam.PickUpTileObject();
                    //if (result) print("Picked up obj");

                }
            };
        }

        private void OnDisable()
        {
            controls.Disable();
         
        }

        private void Update()
        {
            var moveInput = controls.Player.Move.ReadValue<Vector2>();
            var dir = new Vector3(moveInput.x, 0, moveInput.y);
            simpleMove.MoveToDirection(dir);
        }


    }
}