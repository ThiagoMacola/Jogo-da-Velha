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
            string cor = null, escolhaModoDaltonico;

          
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\t\t\t++++++++++++++++ JOGO DA VELHA ++++++++++++++++\n\n");
            Console.ResetColor();

           
            TrocaCor(ref cor);                      //Chamada de função para se 'S' mudar a cor do 'X' do jogo! 
			
            do
            {
                Console.WriteLine();
                NomeJogador(ref jogador1, ref jogador2);
                Console.WriteLine();

                MapaMatriz(mapa);
                Console.WriteLine("\n");

                Posicao(matriz, jogador1, jogador2, cor, mapa);

                Console.Write("\nDESEJA JOGAR NOVAMENTE??[S/N]: ");
                while (true)
                {
                    try
                    {
                        escolhaModoDaltonico = Console.ReadLine();
                        escolhaModoDaltonico = escolhaModoDaltonico.ToUpper();
                        if (escolhaModoDaltonico == "S" || escolhaModoDaltonico == "N") break;
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
                Console.Clear();
                Array.Clear(matriz, 0, matriz.Length);
            } while (escolhaModoDaltonico == "S");                                      

            Console.ReadKey();
        }
        static void NomeJogador(ref string jogador1, ref string jogador2)
        {
            do
            {
                Console.Write("Digite o nome do primeiro Jogador: ");
                jogador1 = Console.ReadLine();
                Console.Write("Digite o nome do segundo Jogador: ");
                jogador2 = Console.ReadLine();

				if (jogador1 == ""|| jogador2 == "")
					Console.WriteLine("DIGITE OBRIGATORIAMENTE UMA IDENTIFICAÇÃO PARA OS 2 JOGADORES");
            } while (jogador1 == "" || jogador2 == "" );    //Funçao para inserir Nome de Jogadores

            Console.Clear();
        } 
        
        static void ImprimirJogo(string[,] matriz, string cor)                          //Função para Imprimir Jogo
        {
            if (cor == "N")
            {
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int c = 0; c < matriz.GetLength(1); c++)
                    {
                        Pad(4);
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
                        Trace(26);
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
                        Pad(4);
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
                        Trace(26);
                        Console.ResetColor();
                        Console.WriteLine();

                    }
                }
            }
        }
        static void MapaMatriz(int[,] mapa)                                             //Função para imprimri Mapado Jogo
        {
            Console.WriteLine(" ESCOLHA UM NÚMERO COM BASE NO MAPA A SEGUIR\n");
            int cont = 1;
            for (int i = 0; i < mapa.GetLength(0); i++)
            {
                Pad(8);
                for (int c = 0; c < mapa.GetLength(1); c++)
                {
                    mapa[i, c] = cont;
                    cont++;
                    Pad(1);
                    Console.Write("[" + mapa[i, c] + "]");
                    if (c != mapa.GetLength(1) - 1)
                    {
                        Pad(1);
                        Console.Write("|");
                    }
                }
                if (i != mapa.GetLength(0) - 1)
                {
                    Console.WriteLine();
                    Pad(8);
                    Trace(17);
                    Console.WriteLine();
                }
            }
        }                                           
        static void Posicao(string[,] matriz, string jogador1, string jogador2, string cor, int[,] mapa)
        {
            int posicionamento = 0, contadorRodadas = 0, parar = 0, linha, situacao;
            string xo = "";
            for (int l = 0; l < matriz.GetLength(0); l++)
            {
                for (int c = 0; c < matriz.GetLength(1); c++)
                {
                    while (contadorRodadas < 9)                                                //Atribuindo Numero de Jogadas Maximas com Contador
                    {
                        

                        if (contadorRodadas % 2 == 0)
                        {
                            Console.Write($"\n=-=-=-=-Vez do {jogador1}-=-=-=-=-=");
                            xo = "X";
                            Console.Write($"\n\nDigite a posição desejada {jogador1}: ");
                        }                                                                 // Pares = Jogador 1, Impares = Jogador 2
                        else
                        {
                            Console.Write($"\n=-=-=-=-Vez do {jogador2}-=-=-=-=-=");
                            xo = "O";
                            Console.Write($"\n\nDigite a posição desejada {jogador2}: ");
                        }
                        try
                        {
                            posicionamento = int.Parse(Console.ReadLine());
                            Console.Clear();
                        }
                        catch (Exception)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nVOCÊ DEVE DIGITAR UM NÚMERO INTEIRO de 1 a 9!!");       //Controle Usuario valor Decimal, Overflow, ou letras
                            Console.ResetColor();
                            MapaMatriz(mapa);
                            continue;
                        }
                       

                        if (posicionamento < 1 || posicionamento > 9)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nO NÚMERO DEVE SER DE 1 A 9!!");                    //Controle de Usuario Valor menor que 1 e maior que 9
                            Console.ResetColor();
                            continue;
                        }
                        linha = 0;
                        if (posicionamento >= 4 && posicionamento < 7)
                        {
                            posicionamento -= 3;
                            linha = 1;
                        }

                        else if (posicionamento >= 7 && posicionamento < 10)
                        {
                            posicionamento -= 6;
                            linha = 2;
                        }

                        if (matriz[linha, posicionamento - 1] == null)                                 //Inserindo Valor na posição da matriz de acordo com a lógica
                        {
                            matriz[linha, posicionamento - 1] = xo;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("POSIÇÃO JÁ PREENCHIDA!!!");
                            Console.ResetColor();
							Console.WriteLine("\n");
                            MapaMatriz(mapa);
                            Console.WriteLine("\n");
                            continue;
                        }
                        contadorRodadas++;
                        Console.WriteLine();
                        ImprimirJogo(matriz, cor);
                        Console.WriteLine();
                        if (contadorRodadas < 5) continue;
                        situacao = VerificarSituacao(matriz);

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
                            if (parar == 5)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\nDEU VELHA!!!");
                                Console.ResetColor();
                            }
                        }
                    }
                    MapaMatriz(mapa);
                }
            }
        }   
        static int VerificarSituacao(string[,] matriz)
        {
             //linha 1
            if ((matriz[0, 0] == matriz[0, 1] && matriz[0, 0] == matriz[0, 2]) && matriz[0, 0] != null)
            if (matriz[0, 0] == "X") return 1;
            else return 2;                                                                                          //Verfica Vitoria

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
        static void Pad(int tam)
        {
            for (int i = 0; i < tam; i++)
            {
                Console.Write(" ");
            }
        }
        static void Trace(int qtd)
        {
            for (int i = 0; i < qtd; i++)
            {
                Console.Write("-");
            }
        }
        static void TrocaCor(ref string cor)
        {
            Console.Write("Olá jogadores, desejam ligar o recurso de acessibilidade para daltônicos?[S/N]: ");
            while (true)
            {
                try
                {
                    cor = Console.ReadLine();
                    cor = cor.ToUpper();
                    if (cor == "S" || cor == "N") break;
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
            return;
        }
    }
}






