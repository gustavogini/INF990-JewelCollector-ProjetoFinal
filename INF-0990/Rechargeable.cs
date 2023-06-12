/// <summary>
/// Responsável por recarregar a energia do robo.
/// </summary>
public interface Rechargeable
{
    /// <summary>
    /// Recarrega o objeto especificado.
    /// </summary>
    /// <param name="r">O objeto a ser recarregado.</param>
    public void Recharge(Robot r);
}