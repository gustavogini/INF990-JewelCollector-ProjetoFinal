using System;
using System.Collections.Generic;
/// <summary>
/// Classe responsável pelas exceções tanto nos casos de o robô tentar sair do mapa, posição ocupada e sem energia.
/// </summary>
public class OutOfMapException : Exception
{
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="OutOfMapException"/>.
    /// </summary>
    public OutOfMapException() : base("Position is out of map") { }
}

/// <summary>
/// Classe que representa uma exceção para o caso de a posição estar ocupada.
/// </summary>
public class OccupiedPositionException : Exception
{
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="OccupiedPositionException"/>.
    /// </summary>
    public OccupiedPositionException() : base("Position is occupied") { }
}

/// <summary>
/// Classe que representa uma exceção para o caso de o robô ficar sem energia.
/// </summary>
public class RanOutOfEnergyException : Exception
{
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="RanOutOfEnergyException"/>.
    /// </summary>
    public RanOutOfEnergyException() : base("Robot ran out of energy") { }
}
