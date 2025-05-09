namespace CarRace.Utils;

public static class MathUtils
{
    public static int AngleFromDegrees(float degrees)
    {
        return (int)(degrees * (int)(180 / Math.PI));
    }
}