using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SeriallizeField] private float speed = 3f;// скорость движения
    [SeriallizeField] private float lives = 5; // количество жизней
    [SeriallizeField] private float jumpForce = 15f; // сила прыжка

    private Rigitbody2D rb;
    
    

}
