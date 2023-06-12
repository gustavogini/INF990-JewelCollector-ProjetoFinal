/// <summary>
/// Interface pública responsável pela interação do robo com o mapa.
/// </summary>

public interface IInteractable
{
    /// <summary>
    /// Método responsável por interagir com o objeto usando o robô especificado.
    /// </summary>
    /// <param name="robot">O robô que está interagindo com o objeto.</param>
    void Interact(Robot robot);
}