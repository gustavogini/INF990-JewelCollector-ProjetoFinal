/// <summary>
/// Classe reponsável pela Jóia Azul, pontuação e recarregar energia
/// </summary>
public class JewelBlue : Jewel, IInteractable, ICollectible, Rechargeable
{
    /// <summary>
    /// Recarrega a energia do robô.
    /// </summary>
    /// <param name="r">O robô a ser recarregado.</param>
    public void Recharge(Robot r)
    {
        r.Energy++;
        r.Energy++;
        r.Energy++;
    }
    public JewelBlue() : base("JB ", 10) { }

    /// <summary>
    /// Interage com o robô.
    /// </summary>
    /// <param name="robot">O robô que está interagindo com a joia.</param>
    public void Interact(Robot robot)
    {
        Collect(robot);
    }

    /// <summary>
    /// Coleta a joia com o robô.
    /// </summary>
    /// <param name="robot">O robô que está coletando a joia.</param>
    public void Collect(Robot robot)
    {
        robot.AddToBag(this);
    }
}
