using UnityEngine;
using System.Collections;

interface IShipControl
{
    void ShipControlActive(bool _active);

    GameObject playerShip { get;}

}

