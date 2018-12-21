using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class ScoreSystemTests {


    [Test]
    public void PointClaculator_Test()
    {
        //Arrange
        var pointCalculator = new PointCalculator();
        var coinsCollected = 25;
        var timeLeft = 120;
        var expectedPoints = (25 * 5 + 120 * 10);

        //Action
        var points = pointCalculator.PointsClaculator(
            coinsCollected,
            timeLeft);

        //Assert
        Assert.That(points, Is.EqualTo(expectedPoints));
    }
}
