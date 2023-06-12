/// <summary>
/// Classe responsável pelos itens Jewels e espaços vazios.
/// </summary>
public abstract class ItemMap
{
    private string Symbol;
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="ItemMap"/>.
    /// </summary>
    /// <param name="Symbol">O símbolo associado ao item do mapa.</param>
    public ItemMap(string Symbol)
    {
        this.Symbol = Symbol;
    }
    /// <summary>
    /// Sobrescreve o método ToString para retornar o símbolo do item do mapa.
    /// </summary>
    /// <returns>O símbolo do item do mapa.</returns>
    public sealed override string ToString()
    {
        return Symbol;
    }
}