/// <summary>
/// Interface que representa um objeto colecionável.
/// </summary>

public interface ICollectible
{
    /// <summary>
    /// Método responsável por coletar o objeto colecionável com o robô especificado.
    /// </summary>
    /// <param name="robot">O robô que está coletando o objeto.</param>
    void Collect(Robot robot);
}