namespace AE.Domains.Ships.Queries;

public static class PrimitiveExtensions
{
    public static double RoundOffToTwoDecimalPoints(this double input)
    {
        return Math.Round(input, 2, MidpointRounding.AwayFromZero);
    }
}