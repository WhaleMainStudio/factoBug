using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class turnManagerData
{
    public static List<piston> pistons = new List<piston>();
    public static List<spawnedCube> cubes = new List<spawnedCube>();
    
    public static List<tapisRoulant> tapis = new List<tapisRoulant>();

    public static Dictionary<spawnedCube, bool> cubesAction = new Dictionary<spawnedCube, bool>();

    public static Dictionary<piston, bool> pistonAction = new Dictionary<piston, bool>();

    
}
