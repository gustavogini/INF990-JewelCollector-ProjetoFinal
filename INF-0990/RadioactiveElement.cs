/// <summary>
/// Classe que representa um elemento radioativo no mapa.
/// </summary>
public class RadioactiveElement : ItemMap, Rechargeable, IInteractable
{
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="RadioactiveElement"/>.
    /// </summary>
    public RadioactiveElement() : base("!! ") { }

    /// <summary>
    /// Interage com o robô, descarregando sua energia.
    /// </summary>
    /// <param name="robot">O robô que interage com o elemento.</param>
    public void Interact(Robot robot)
    {
        Recharge(robot);
    }

    /// <summary>
    /// Descarrega a energia do robô.
    /// </summary>
    /// <param name="robot">O robô a ser descarregado.</param>
    public void Recharge(Robot robot)
    {
        // Reduz a energia do robô em 30 unidades
        robot.Energy -= 30;

    }

}
