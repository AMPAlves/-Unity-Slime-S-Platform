public class PointSystem
{
    private int points;
    private int maxPoints;

    public PointSystem(int maxPoints)
    {
        this.maxPoints = maxPoints;
    }

    public int getPoints()
    {
        return points;
    }

    public void addPoints()
    {
        points++;
    }

    public int getMaxPoints()
    {
        return maxPoints;
    }
}