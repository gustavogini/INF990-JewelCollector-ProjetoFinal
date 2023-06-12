using System.Diagnostics;
/// <summary>
/// Classe reponsável pelo Mapa.
/// </summary>
/// <param name="w">Quantidade inicial da largura</param>
/// <param name="h">Quantidade inicial da altura.</param>
[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class Map
{
    private ItemMap[,] Matrix;
    private int w;
    private int h;

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Map"/>.
    /// </summary>
    /// <param name="w">A largura do mapa.</param>
    /// <param name="h">A altura do mapa.</param>
    /// <param name="level">O nível do mapa.</param>
    public Map(int w = 10, int h = 10, int level = 1)
    {
        this.w = w <= 30 ? w : 30;
        this.h = h <= 30 ? h : 30;
        Matrix = new ItemMap[w, h];
        for (int i = 0; i < Matrix.GetLength(0); i++)
        {
            for (int j = 0; j < Matrix.GetLength(1); j++)
            {
                Matrix[i, j] = new Empty();
            }
        }
        if (level == 1)
        {
            GenerateFixed();
        }
        else
        {
            GenerateRandom();
        }
    }

    /// <summary>
    /// Insere um item na posição especificada.
    /// </summary>
    /// <param name="item">O item a ser inserido.</param>
    /// <param name="x">A posição horizontal.</param>
    /// <param name="y">A posição vertical.</param>
    public void Insert(ItemMap item, int x, int y)
    {
        Matrix[x, y] = item;
    }

    /// <summary>
    /// Atualiza a posição de um item no mapa.
    /// </summary>
    /// <param name="x_old">A posição horizontal atual.</param>
    /// <param name="y_old">A posição vertical atual.</param>
    /// <param name="x">A nova posição horizontal.</param>
    /// <param name="y">A nova posição vertical.</param>
    public void Update(int x_old, int y_old, int x, int y)
    {
        if (x < 0 || y < 0 || x > this.w - 1 || y > this.h - 1)
        {
            Console.WriteLine($"\nOutOfMapException: x({x}) > w({this.w - 1}) or y({y}) > h({this.w - 1})");
            throw new OutOfMapException();
        }

        if (!IsAllowed(x, y))
        {
            Console.WriteLine($"\nOccupiedPositionException: x({x}), y({y})");
            throw new OccupiedPositionException();
        }

        Matrix[x, y] = Matrix[x_old, y_old];
        Matrix[x_old, y_old] = new Empty();
    }

    public ItemMap GetItemAt(int x, int y)
    {
        if (x < 0 || y < 0 || x >= w || y >= h)
        {
            Console.WriteLine($"\nOutOfMapException: x({x}) > w({w - 1}) or y({y}) > h({h - 1})");
            throw new OutOfMapException();
        }

        return Matrix[x, y];
    }





    /// <summary>
    /// Obtém as joias próximas à posição especificada.
    /// </summary>
    /// <param name="x">A posição horizontal.</param>
    /// <param name="y">A posição vertical.</param>
    /// <returns>Uma lista de joias próximas.</returns>
    public List<Jewel> GetJewels(int x, int y)
    {
        List<Jewel> nearJewels = new List<Jewel>();
        int[,] coords = GenerateCoord(x, y);
        for (int i = 0; i < coords.GetLength(0); i++)
        {
            Jewel jewel = GetJewel(coords[i, 0], coords[i, 1]);
            if (jewel != null)
            {
                nearJewels.Add(jewel);
            }
        }

        return nearJewels;
    }





    /// <summary>
    /// Obtém a joia na posição especificada e remove-a do mapa.
    /// </summary>
    /// <param name="x">A posição horizontal.</param>
    /// <param name="y">A posição vertical.</param>
    /// <returns>A joia encontrada, ou null se não houver joia na posição.</returns>
    private Jewel? GetJewel(int x, int y)
    {
        if (Matrix[x, y] is Jewel jewel)
        {
            Matrix[x, y] = new Empty();
            return jewel;
        }

        return null;
    }

    /// <summary>
    /// Obtém o objeto recarregável na posição especificada.
    /// </summary>
    /// <param name="x">A posição horizontal.</param>
    /// <param name="y">A posição vertical.</param>
    /// <returns>O objeto recarregável encontrado, ou null se não houver objeto recarregável na posição.</returns>
    public Rechargeable? GetRechargeable(int x, int y)
    {
        int[,] coords = GenerateCoord(x, y);

        for (int i = 0; i < coords.GetLength(0); i++)
        {
            if (Matrix[coords[i, 0], coords[i, 1]] is Rechargeable r)
            {
                return r;
            }
        }

        return null;
    }

    /// <summary>
    /// Gera as coordenadas das posições adjacentes à posição especificada.
    /// </summary>
    /// <param name="x">A posição horizontal.</param>
    /// <param name="y">A posição vertical.</param>
    /// <returns>Uma matriz de coordenadas.</returns>
    private int[,] GenerateCoord(int x, int y)
    {
        int[,] coords = new int[4, 2]
        {
            { x, y + 1 < w - 1 ? y + 1 : w - 1 },
            { x, y - 1 > 0 ? y - 1 : 0 },
            { x + 1 < h - 1 ? x + 1 : h - 1, y },
            { x - 1 > 0 ? x - 1 : 0, y }
        };

        return coords;
    }

    /// <summary>
    /// Verifica se é permitido mover para a posição especificada.
    /// </summary>
    /// <param name="x">A posição horizontal.</param>
    /// <param name="y">A posição vertical.</param>
    /// <returns>True se a posição é permitida, False caso contrário.</returns>
    private bool IsAllowed(int x, int y)
    {
        return Matrix[x, y] is Empty || Matrix[x, y] is RadioactiveElement;
    }

    /// <summary>
    /// Imprime o mapa.
    /// </summary>
    public void Print()
    {
        for (int i = 0; i < Matrix.GetLength(0); i++)
        {
            for (int j = 0; j < Matrix.GetLength(1); j++)
            {
                Console.Write(Matrix[i, j]);
            }
            Console.Write("\n");
        }
    }

    // <summary>
    /// Verifica se o mapa foi concluído, ou seja, se não há mais joias no mapa.
    /// </summary>
    /// <returns>True se o mapa foi concluído, False caso contrário.</returns>
    public bool IsDone()
    {
        for (int i = 0; i < Matrix.GetLength(0); i++)
        {
            for (int j = 0; j < Matrix.GetLength(1); j++)
            {
                if (Matrix[i, j] is Jewel)
                {
                    return false;
                }
            }
        }
        return true;
    }

    /// <summary>
    /// Gera os elementos fixos do mapa.
    /// </summary>
    private void GenerateFixed()
    {
        Insert(new JewelRed(), 1, 9);
        Insert(new JewelRed(), 8, 8);
        Insert(new JewelGreen(), 9, 1);
        Insert(new JewelGreen(), 7, 6);
        Insert(new JewelBlue(), 3, 4);
        Insert(new JewelBlue(), 2, 1);
        Insert(new Water(), 5, 0);
        Insert(new Water(), 5, 1);
        Insert(new Water(), 5, 2);
        Insert(new Water(), 5, 3);
        Insert(new Water(), 5, 4);
        Insert(new Water(), 5, 5);
        Insert(new Water(), 5, 6);
        Insert(new Tree(), 5, 9);
        Insert(new Tree(), 3, 9);
        Insert(new Tree(), 8, 3);
        Insert(new Tree(), 2, 5);
        Insert(new Tree(), 1, 4);
        //Insert(new RadioactiveElement(), 4, 4);
    }

    /// <summary>
    /// Gera os elementos aleatórios do mapa.
    /// </summary>
    private void GenerateRandom()
    {
        Random r = new Random(1);
        for (int x = 0; x < 3; x++)
        {
            int xRandom = r.Next(0, w);
            int yRandom = r.Next(0, h);
            Insert(new JewelBlue(), xRandom, yRandom);
        }

        for (int x = 0; x < 3; x++)
        {
            int xRandom = r.Next(0, w);
            int yRandom = r.Next(0, h);
            Insert(new JewelGreen(), xRandom, yRandom);
        }

        for (int x = 0; x < 3; x++)
        {
            int xRandom = r.Next(0, w);
            int yRandom = r.Next(0, h);
            Insert(new JewelRed(), xRandom, yRandom);
        }

        for (int x = 0; x < 10; x++)
        {
            int xRandom = r.Next(0, w);
            int yRandom = r.Next(0, h);
            Insert(new Water(), xRandom, yRandom);
        }

        for (int x = 0; x < 10; x++)
        {
            int xRandom = r.Next(0, w);
            int yRandom = r.Next(0, h);
            Insert(new Tree(), xRandom, yRandom);
        }

        int radioactiveX = r.Next(0, w);
        int radioactiveY = r.Next(0, h);
        Insert(new RadioactiveElement(), radioactiveX, radioactiveY);
    }

    /// <summary>
    /// Obtém a representação de depuração do mapa.
    /// </summary>
    /// <returns>A representação em string do mapa.</returns>
    private string GetDebuggerDisplay()
    {
        return ToString();
    }

    internal RadioactiveElement GetItemAt(object x, object y)
    {
        throw new NotImplementedException();
    }
}





