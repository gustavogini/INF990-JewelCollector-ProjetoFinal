using System;
using System.Collections.Generic;
/// <summary>
/// Classe responsável pelos delegates e eventos de movimentação do robo.
/// </summary>
public class JewelCollector
{
    // Delegates de movimentação
    delegate void MoveNorth();
    delegate void MoveSouth();
    delegate void MoveEast();
    delegate void MoveWest();
    delegate void GetItem();
    delegate void InteractWithRadioactive();

    // Eventos de movimentação
    static event MoveNorth OnMoveNorth;
    static event MoveSouth OnMoveSouth;
    static event MoveEast OnMoveEast;
    static event MoveWest OnMoveWest;
    static event GetItem OnGetItem;
    static event InteractWithRadioactive OnInteractWithRadioactive;

    /// <summary>
    /// Método principal do programa.
    /// </summary>
    static void Main()
    {
        int w = 10;
        int h = 10;
        int level = 1;

        while (true)
        {
            // Criação do mapa e robô
            Map map = new Map(w, h, level);
            Robot robot = new Robot(map);
            Console.WriteLine($"Level: {level}");

            try
            {
                bool result = Run(robot);
                if (result)
                {
                    w++;
                    h++;
                    level++;
                }
                else
                {
                    break;
                }
            }
            catch (RanOutOfEnergyException)
            {
                Console.WriteLine("Robot ran out of energy!");
            }
        }
    }

    /// <summary>
    /// Executa o loop principal do jogo.
    /// </summary>
    /// <param name="robot">O robô do jogo.</param>
    /// <returns>True se o jogo foi concluído, False se o robô ficou sem energia.</returns>
    private static bool Run(Robot robot)
    {
        // Associa os métodos do robô aos eventos de movimentação
        OnMoveNorth += robot.MoveNorth;
        OnMoveSouth += robot.MoveSouth;
        OnMoveEast += robot.MoveEast;
        OnMoveWest += robot.MoveWest;
        OnGetItem += robot.Get;
        OnInteractWithRadioactive += robot.InteractWithRadioactive;

        do
        {
            // Verifica se o robô tem energia suficiente para continuar
            if (!robot.HasEnergy()) throw new RanOutOfEnergyException();
            // Imprime o estado atual do robô
            robot.Print();
            Console.WriteLine("\n Enter the command: ");
            ConsoleKeyInfo command = Console.ReadKey(true);

            // Verifica o comando inserido pelo usuário e dispara o evento correspondente
            switch (command.Key.ToString())
            {
                case "W": Console.WriteLine($"\n Comando:{command.Key.ToString()}"); OnMoveNorth(); break;
                case "S": Console.WriteLine($"\n Comando:{command.Key.ToString()}"); OnMoveSouth(); break;
                case "D": Console.WriteLine($"\n Comando:{command.Key.ToString()}"); OnMoveEast(); break;
                case "A": Console.WriteLine($"\n Comando:{command.Key.ToString()}"); OnMoveWest(); break;
                case "G": Console.WriteLine($"\n Comando:{command.Key.ToString()}"); OnGetItem(); break;
                case "quit": return false;
                default: Console.WriteLine($"\n Comando inválido:{command.Key.ToString()}"); break;
            }
        } while (!robot.Map.IsDone());
        return true;
    }
}

