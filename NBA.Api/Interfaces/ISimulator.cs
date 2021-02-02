using NBA.Model;

namespace NBA.Api.Interfaces
{
    public interface ISimulator
    {
        QuarterPredictions QuarterSimulator(Team HomeTeam, Team AwayTeam, int QuarterNo, int GameNo);
        GamePredictions FullMatchSimulator(Team HomeTeam, Team AwayTeam, int GameNo);
        GamePredictions FullMatchSimulator1920(Team HomeTeam, Team AwayTeam, int GameNo, double Coefficient1, double Coefficient2, double Coefficient3, double Coefficient4, double Coefficient5, double Coefficient6, double Coefficient7);
        QuarterPredictions QuarterSimulator1920(Team HomeTeam, Team AwayTeam, int QuarterNo, int GameNo, double Coefficient1, double Coefficient2, double Coefficient3, double Coefficient4, double Coefficient5, double Coefficient6, double Coefficient7);
    }
}
