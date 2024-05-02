using KnightsChallenge.Server.Entities;

namespace KnightsChallenge.Server.Application
{
    public interface IKnightsApp
    {
        int CalculateAttack(Knight knight);
        int CalculateExp(DateTime birthday);
    }
}
