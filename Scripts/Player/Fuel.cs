using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel{

    private int fuelCount;

    public Fuel()
    {
        fuelCount = 100;
        return;
    }

    public Fuel(int fuelStart)
    {
        fuelCount = fuelStart;
        return;
    }

    public void setFuel(int number)
    {
        fuelCount = number;
        return;
    }

    public int getFuel()
    {
        return fuelCount;
    }

    public void decreaseFuel()
    {
        --fuelCount;
        if(fuelCount < 0)
        {
            fuelCount = 0;
        }
        return;
    }

    public void decreaseFuel(int increment)
    {
        fuelCount = fuelCount - increment;
        if(fuelCount < 0)
        {
            fuelCount = 0;  
        }
        return;
    }
}
