/// <summary>
/// Classe responsável pelo itens do mapa, em específico os obstáculos.
/// </summary>
public abstract class Obstacle : ItemMap
{
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Obstacle"/>.
    /// </summary>
    /// <param name="Symbol">O símbolo associado ao obstáculo.</param>
    public Obstacle(string Symbol) : base(Symbol) { }
}