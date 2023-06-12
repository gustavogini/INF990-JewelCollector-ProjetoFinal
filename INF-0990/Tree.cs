/// <summary>
/// Classe responsável pelo item do mapa árvore
/// </summary>
public class Tree : Obstacle, IInteractable, Rechargeable
{
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Tree"/>.
    /// </summary>
    public Tree() : base("$$ ") { }

    /// <summary>
    /// Interage com o robô, recarregando sua energia.
    /// </summary>
    /// <param name="robot">O robô que interage com a árvore.</param>
    public void Interact(Robot robot)
    {
        Recharge(robot);
    }

    // public void Collect(Robot robot)
    // {
    //     robot.AddToBag(new JewelGreen());
    // }

    /// <summary>
    /// Recarrega a energia do robô.
    /// </summary>
    /// <param name="robot">O robô a ser recarregado.</param>
    public void Recharge(Robot robot)
    {
        robot.Energy++;
        robot.Energy++;
        robot.Energy++;
    }
}