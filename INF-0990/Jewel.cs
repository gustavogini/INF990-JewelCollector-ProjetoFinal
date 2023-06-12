/// <summary>
/// Classe responsável pelas Jóias e contabilizar pontuação.
/// </summary>
public abstract class Jewel : ItemMap
{
    /// <summary>
    /// Obtém ou define os pontos associados à joia.
    /// </summary>
    public int Points { get; private set; }
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Jewel"/>.
    /// </summary>
    /// <param name="Symbol">O símbolo associado à joia.</param>
    /// <param name="Points">Os pontos associados à joia.</param>
    public Jewel(string Symbol, int Points) : base(Symbol)
    {
        this.Points = Points;
    }
}