using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCalculator {


    public int PointsClaculator(
       int coinsCollected,
       int timeLeft)
    {
        int points = 0;

        points += coinsCollected * 5;
        points += timeLeft * 10;

        return points;
    }
}
