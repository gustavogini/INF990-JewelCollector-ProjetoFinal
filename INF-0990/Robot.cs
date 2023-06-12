/// <summary>
/// Classe responsável pelo robo, sua interação com o mapa e os itens.
/// </summary>
public class Robot : ItemMap
{
    /// <summary>
    /// O mapa associado ao robô.
    /// </summary>
    public Map Map { get; private set; }
    private int x, y;
    private List<Jewel> Bag = new List<Jewel>();
    private readonly object X;
    private readonly object Y;

    /// <summary>
    /// A energia do robô.
    /// </summary>
    public int Energy { get; set; }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Robot"/>.
    /// </summary>
    /// <param name="map">O mapa associado ao robô.</param>
    /// <param name="x">A posição x inicial do robô.</param>
    /// <param name="y">A posição y inicial do robô.</param>
    /// <param name="energy">A energia inicial do robô.</param>
    public Robot(Map map, int x = 0, int y = 0, int energy = 5) : base("ME ")
    {
        this.Map = map;
        this.x = x;
        this.y = y;
        this.Energy = energy;
        this.Map.Insert(this, x, y);
    }

    /// <summary>
    /// Move o robô para cima.
    /// </summary>
    public void MoveNorth()
    {
        try
        {
            Map.Update(this.x, this.y, this.x - 1, this.y);
            this.x--;
            this.Energy--;
        }
        catch (OccupiedPositionException)
        {
            Console.WriteLine($"\nPosition {this.x - 1}, {this.y} is occupied");
        }
        catch (OutOfMapException)
        {
            Console.WriteLine($"\nPosition {this.x - 1}, {this.y} is out of map");
        }
        catch (Exception)
        {
            Console.WriteLine($"\nPosition is prohibited");
        }
    }

    /// <summary>
    /// Move o robô para baixo.
    /// </summary>
    public void MoveSouth()
    {
        try
        {
            Map.Update(this.x, this.y, this.x + 1, this.y);
            this.x++;
            this.Energy--;
        }
        catch (OccupiedPositionException)
        {
            Console.WriteLine($"\nPosition {this.x + 1}, {this.y} is occupied");
        }
        catch (OutOfMapException)
        {
            Console.WriteLine($"\nPosition {this.x + 1}, {this.y} is out of map");
        }
        catch (Exception)
        {
            Console.WriteLine($"\nPosition is prohibited");
        }
    }

    /// <summary>
    /// Move o robô para direita.
    /// </summary>
    public void MoveEast()
    {
        try
        {
            Map.Update(this.x, this.y, this.x, this.y + 1);
            this.y++;
            this.Energy--;
        }
        catch (OccupiedPositionException)
        {
            Console.WriteLine($"\nPosition {this.x}, {this.y + 1} is occupied");
        }
        catch (OutOfMapException)
        {
            Console.WriteLine($"\nPosition {this.x}, {this.y + 1} is out of map");
        }
        catch (Exception)
        {
            Console.WriteLine($"\nPosition is prohibited");
        }
    }

    /// <summary>
    /// Move o robô para esquerda.
    /// </summary>
    public void MoveWest()
    {
        try
        {
            Map.Update(this.x, this.y, this.x, this.y - 1);
            this.y--;
            this.Energy--;
        }
        catch (OccupiedPositionException)
        {
            Console.WriteLine($"\nPosition {this.x}, {this.y - 1} is occupied");
        }
        catch (OutOfMapException)
        {
            Console.WriteLine($"\nPosition {this.x}, {this.y - 1} is out of map");
        }
        catch (Exception)
        {
            Console.WriteLine($"\nPosition is prohibited");
        }
    }

    /// <summary>
    /// Realiza a ação de pegar itens.
    /// </summary>
    public void Get()
    {
        Rechargeable rechargeEnergy = Map.GetRechargeable(this.x, this.y);
        rechargeEnergy?.Recharge(this);
        List<Jewel> NearJewels = Map.GetJewels(this.x, this.y);
        foreach (Jewel j in NearJewels)
        {
            Bag.Add(j);
        }
    }

    /// <summary>
    /// Realiza a interação do robô com um elemento radioativo.
    /// </summary>
    public void InteractWithRadioactive()
    {
        // Verifica se há um elemento radioativo na posição atual do robô
        if (Map.GetItemAt(X, Y) is RadioactiveElement radioactiveElement)
        {
            // Chama o método de interação do elemento radioativo, passando o próprio robô como parâmetro
            radioactiveElement.Interact(this);
        }
    }

    // public void InteractWithRadioactive()
    // {
    //     // Verifica se há um elemento radioativo na posição atual do robô
    //     if (Map.GetItemAt(X, Y) is RadioactiveElement radioactiveElement)
    //     {
    //         // Chama o método de interação do elemento radioativo, passando o próprio robô como parâmetro
    //         radioactiveElement.Interact(this);
    //     }
    //     else
    //     {
    //         // Verifica a presença de elemento radioativo nas posições adjacentes ao redor do robô

    //         // Posição ao norte
    //         if (X - 1 >= 0 && Map.GetItemAt(X - 1, Y) is RadioactiveElement radioactiveElementNorth)
    //         {
    //             radioactiveElementNorth.Interact(this);
    //         }
    //         // Posição ao sul
    //         else if (X + 1 < Map.Width && Map.GetItemAt(X + 1, Y) is RadioactiveElement radioactiveElementSouth)
    //         {
    //             radioactiveElementSouth.Interact(this);
    //         }
    //         // Posição ao leste
    //         else if (Y + 1 < Map.Height && Map.GetItemAt(X, Y + 1) is RadioactiveElement radioactiveElementEast)
    //         {
    //             radioactiveElementEast.Interact(this);
    //         }
    //         // Posição ao oeste
    //         else if (Y - 1 >= 0 && Map.GetItemAt(X, Y - 1) is RadioactiveElement radioactiveElementWest)
    //         {
    //             radioactiveElementWest.Interact(this);
    //         }
    //         else
    //         {
    //             // Não há elementos radioativos nas posições adjacentes
    //             //Console.WriteLine("Não há elementos radioativos ao redor do robô.");
    //         }
    //     }
    // }

    /// <summary>
    /// Obtém informações sobre a mochila do robô.
    /// </summary>
    /// <returns>Uma tupla com o número de itens na mochila e o total de pontos.</returns>
    private (int, int) GetBagInfo()
    {
        int Points = 0;
        foreach (Jewel j in this.Bag)
        {
            Points += j.Points;
        }
        return (this.Bag.Count, Points);
    }

    /// <summary>
    /// Imprime o estado atual do robô.
    /// </summary>
    public void Print()
    {
        Map.Print();
        (int ItemsInBag, int TotalPoints) = this.GetBagInfo();
        Console.WriteLine($"\nItems in Bag: {ItemsInBag} - Total Points: {TotalPoints} - Energy: {this.Energy} - x: {this.x}, y: {this.y}\n\n");
    }

    /// <summary>
    /// Verifica se o robô ainda tem energia.
    /// </summary>
    /// <returns>True se o robô tem energia, False caso contrário.</returns>
    public bool HasEnergy()
    {
        return this.Energy > 0;
    }

    /// <summary>
    /// Adiciona uma joia à mochila do robô.
    /// </summary>
    /// <param name="jewel">A joia a ser adicionada.</param>
    public void AddToBag(Jewel jewel)
    {
        Bag.Add(jewel);
    }
}
