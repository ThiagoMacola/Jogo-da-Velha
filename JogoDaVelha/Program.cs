using System;

namespace JogoDaVelhaFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] matriz = new string[3, 3];
            int[,] mapa = new int[3, 3];
            string jogador1 = null, jogador2 = null;
            string dalt, resp;

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\t\t\t++++++++++++++++ JOGO DA VELHA ++++++++++++++++\n\n");
            Console.ResetColor();

            Console.Write("Olá jogadores, desejam ligar o recurso de acessibilidade para daltônicos?[S/N]: ");
            while (true)
            {
                try
                {
                    dalt = Console.ReadLine();
                    dalt = dalt.ToUpper();
                    if (dalt == "S" || dalt == "N") break;
                    Console.WriteLine("POR FAVOR DIGITE [S] PARA SIM OU [N] PARA NÃO!!");
                    Console.Write("Digite novamente: ");
                    continue;
                }
                catch (FormatException)
                {
                    Console.WriteLine("POR FAVOR DIGITE [S] PARA SIM OU [N] PARA NÃO!!");
                    Console.Write("Digite novamente: ");
                    continue;
                }
            }

            do
            {
                Console.WriteLine();
                nomeJogador(ref jogador1, ref jogador2);
                Console.WriteLine();

                mapaMatriz(mapa);
                Console.WriteLine("\n");

                posicao(matriz, jogador1, jogador2, dalt);

                Console.Write("\nDESEJA JOGAR NOVAMENTE??[S/N]: ");
                while (true)
                {
                    try
                    {
                        resp = Console.ReadLine();
                        resp = resp.ToUpper();
                        if (resp == "S" || resp == "N") break;
                        Console.WriteLine("POR FAVOR DIGITE [S] PARA SIM OU [N] PARA NÃO!!");
                        Console.Write("Digite novamente: ");
                        continue;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("POR FAVOR DIGITE [S] PARA SIM OU [N] PARA NÃO!!");
                        Console.Write("Digite novamente: ");
                        continue;
                    }
                }
                Array.Clear(matriz, 0, matriz.Length);
            } while (resp == "S");

            Console.ReadKey();
        }
        static void nomeJogador(ref string jogador1, ref string jogador2)
        {
            Console.Write("Digite o nome do primeiro Jogador: ");
            jogador1 = Console.ReadLine();
            Console.Write("Digite o nome do segundo Jogador: ");
            jogador2 = Console.ReadLine();
        }
        static void Imprimir_Jogo(string[,] matriz, string dalt)
        {
            if (dalt == "N")
            {
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int c = 0; c < matriz.GetLength(1); c++)
                    {
                        pad(4);
                        if (matriz[i, c] == "X")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write(matriz[i, c]);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(matriz[i, c]);
                            Console.ResetColor();
                        }
                        if (c != matriz.GetLength(1) - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("\t|");
                            Console.ResetColor();
                        }
                    }
                    if (i != matriz.GetLength(0) - 1)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        trace(26);
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int c = 0; c < matriz.GetLength(1); c++)
                    {
                        pad(4);
                        if (matriz[i, c] == "X")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write(matriz[i, c]);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(matriz[i, c]);
                            Console.ResetColor();
                        }
                        if (c != matriz.GetLength(1) - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("\t|");
                            Console.ResetColor();
                        }
                    }
                    if (i != matriz.GetLength(0) - 1)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        trace(26);
                        Console.ResetColor();
                        Console.WriteLine();

                    }
                }
            }
        }
        static void mapaMatriz(int[,] mapa)
        {
            Console.WriteLine(" ESCOLHA UM NÚMERO COM BASE NO MAPA A SEGUIR\n");
            int cont = 1;
            for (int i = 0; i < mapa.GetLength(0); i++)
            {
                pad(8);
                for (int c = 0; c < mapa.GetLength(1); c++)
                {
                    mapa[i, c] = cont;
                    cont++;
                    pad(1);
                    Console.Write("[" + mapa[i, c] + "]");
                    if (c != mapa.GetLength(1) - 1)
                    {
                        pad(1);
                        Console.Write("|");
                    }
                }
                if (i != mapa.GetLength(0) - 1)
                {
                    Console.WriteLine();
                    pad(8);
                    trace(17);
                    Console.WriteLine();
                }
            }
        }
        static void posicao(string[,] matriz, string jogador1, string jogador2, string dalt)
        {
            int pos = 0, cont = 0, parar = 0, linha, situacao;
            string xo = "";
            for (int l = 0; l < matriz.GetLength(0); l++)
            {
                for (int c = 0; c < matriz.GetLength(1); c++)
                {
                    while (cont < 9)
                    {
                        if (cont % 2 == 0)
                        {
                            Console.Write($"\n=-=-=-=-Vez do {jogador1}-=-=-=-=-=");
                            xo = "X";
                            Console.Write($"\n\nDigite a posição desejada {jogador1}: ");
                        }
                        else
                        {
                            Console.Write($"\n=-=-=-=-Vez do {jogador2}-=-=-=-=-=");
                            xo = "O";
                            Console.Write($"\n\nDigite a posição desejada {jogador2}: ");
                        }
                        try
                        {
                            pos = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nVOCÊ DEVE DIGITAR UM NÚMERO INTEIRO!!");
                            Console.ResetColor();
                            continue;
                        }
                        catch (OverflowException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nVOCÊ DEVE DIGITAR UM NÚMERO INTEIRO!!");
                            Console.ResetColor();
                            continue;
                        }

                        if (pos < 1 || pos > 9)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nO NÚMERO DEVE SER DE 1 A 9!!");
                            Console.ResetColor();
                            continue;
                        }
                        linha = 0;
                        if (pos >= 4 && pos < 7)
                        {
                            pos -= 3;
                            linha = 1;
                        }

                        else if (pos >= 7 && pos < 10)
                        {
                            pos -= 6;
                            linha = 2;
                        }

                        if (matriz[linha, pos - 1] == null)
                        {
                            matriz[linha, pos - 1] = xo;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nPOSIÇÃO JÁ PREENCHIDA!!!");
                            Console.ResetColor();
                            continue;
                        }
                        cont++;
                        Console.WriteLine();
                        Imprimir_Jogo(matriz, dalt);
                        Console.WriteLine();
                        situacao = verificarSituacao(matriz);

                        if (situacao == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"\n{jogador1.ToUpper()} GANHOU!!");
                            Console.ResetColor();
                            return;
                        }
                        else if (situacao == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine($"\n{jogador2.ToUpper()} GANHOU!!");
                            Console.ResetColor();
                            return;
                        }
                        else if (situacao == 0)
                        {
                            parar++;
                            if (parar == 9)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\nDEU VELHA!!!");
                                Console.ResetColor();
                            }
                        }
                    }
                }
            }
        }
        static int verificarSituacao(string[,] matriz)
        {
            //linha 1
            if ((matriz[0, 0] == matriz[0, 1] && matriz[0, 0] == matriz[0, 2]) && matriz[0, 0] != null)
                if (matriz[0, 0] == "X") return 1;
                else return 2;

            //linha 2
            else if ((matriz[1, 0] == matriz[1, 1] && matriz[1, 0] == matriz[1, 2]) && matriz[1, 0] != null)
                if (matriz[1, 0] == "X") return 1;
                else return 2;

            //linha 3
            else if ((matriz[2, 0] == matriz[2, 1] && matriz[2, 0] == matriz[2, 2]) && matriz[2, 0] != null)
                if (matriz[2, 0] == "X") return 1;
                else return 2;

            //coluna 1
            else if ((matriz[0, 0] == matriz[1, 0] && matriz[0, 0] == matriz[2, 0]) && matriz[2, 0] != null)
                if (matriz[0, 0] == "X") return 1;
                else return 2;

            //coluna 2
            else if ((matriz[0, 1] == matriz[1, 1] && matriz[0, 1] == matriz[2, 1]) && matriz[0, 1] != null)
                if (matriz[0, 1] == "X") return 1;
                else return 2;

            //coluna 3
            else if ((matriz[0, 2] == matriz[1, 2] && matriz[0, 2] == matriz[2, 2]) && matriz[0, 2] != null)
                if (matriz[0, 2] == "X") return 1;
                else return 2;

            //diagonal 1
            else if ((matriz[0, 0] == matriz[1, 1] && matriz[0, 0] == matriz[2, 2]) && matriz[2, 2] != null)
                if (matriz[0, 0] == "X") return 1;
                else return 2;

            //diagonal 2
            else if ((matriz[2, 0] == matriz[1, 1] && matriz[2, 0] == matriz[0, 2]) && matriz[0, 2] != null)
                if (matriz[2, 0] == "X") return 1;
                else return 2;

            else return 0;
        }
        static void pad(int tam)
        {
            for (int i = 0; i < tam; i++)
            {
                Console.Write(" ");
            }
        }
        static void trace(int qtd)
        {
            for (int i = 0; i < qtd; i++)
            {
                Console.Write("-");
            }
        }
    }
}