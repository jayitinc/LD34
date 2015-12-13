using UnityEngine;
using System.Collections;

public class Resources
{
    public float rock;
    public float water;
    public float oxygen;
    public float iron;

    public Resources(float rock, float water, float oxygen, float iron)
    {
        this.rock = rock;
        this.water = water;
        this.oxygen = oxygen;
        this.iron = iron;
    }

    public static Resources operator+(Resources r1, Resources r2)
    {
        r1.rock += r2.rock;
        r1.water += r2.water;
        r1.oxygen += r2.oxygen;
        r1.iron += r2.iron;

        return r1;
    }

    public static Resources operator-(Resources r1, Resources r2)
    {
        r1.rock -= r2.rock;
        r1.water -= r2.water;
        r1.oxygen -= r2.oxygen;
        r1.iron -= r2.iron;

        return r1;
    }
}