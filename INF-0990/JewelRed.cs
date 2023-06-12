using System.Diagnostics;
/// <summary>
/// Classe reponsável pela Jóia Vermelha e pontuação.
/// </summary>
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class JewelRed : Jewel, IInteractable, ICollectible
{
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="JewelRed"/>.
    /// </summary>
    public JewelRed() : base("JR ", 100) { }

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

    /// <summary>
    /// Obtém a representação de depuração da joia.
    /// </summary>
    /// <returns>A representação em string da joia.</returns>
    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}