public class HealthSystem
{
    private int health;
    private int healthMax;

    public HealthSystem(int health)
    {
        this.health = health;
        this.healthMax = health;
    }

    public int getHealth()
    {
        return health;
    }

    public void takeDamage(int damage)
    {
        health = (health > 0 ? health -= damage : 0);
    }

    public float getHPPercentile()
    {
        return (float)health / healthMax;   
    }

    public void killChar()
    {
        health = 0;
    }
}