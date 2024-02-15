namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ResultAll;

public abstract record JourneyResult
{
    private JourneyResult() { }
    public sealed record IsShipLost() : JourneyResult;
    public sealed record IsCrewDead() : JourneyResult;
    public sealed record IsShipDead() : JourneyResult;
    public sealed record IsSuccessfulJourney() : JourneyResult;
}
