/*
1 - dado duas pilhas p1 e p2 que armazenam numeros inteiros, faça um programa que contenha as seguintes funções:
a - uma função para testar se as duas pilhas são iguais. caso não forem, informe qual é a maior (tamanho)
b - uma função que forneça o maior, o menor e a média aritmética dos elementos da pilha  (separado por pilha)
c - uma função para transferir elementos da pilha que eu informar, para uma pilha auxiliar (imprimir a pilha nova)
d - uma função para retornar a quantidade de elementos impares, informando-os
e - uma função para retornar a quantidade de elementos pares, informando-os
*/
using Trab1_DuasPilhas;

internal class Program
{
    private static void Main(string[] args)
    {
        PilhaNumero pilha1 = new PilhaNumero();
        PilhaNumero pilha2 = new PilhaNumero();
        PilhaNumero pilhaAux = new PilhaNumero();
        PilhaNumero pilha_opc = new PilhaNumero(); ;
        int aleatorio, opc, opcpilha;

        aleatorio = new Random().Next(1, 20);
        for (int i = 0; i < aleatorio; i++)
        {
            pilha1.push(geraNumero());
        }

        aleatorio = new Random().Next(1, 20);
        for (int i = 0; i < aleatorio; i++)
        {
            pilha2.push(geraNumero());
        }

        do
        {
            Console.Clear();
            Console.WriteLine("1 - Verificar o tamanho das pilhas");
            Console.WriteLine("2 - Verificar maior, menor, média aritmética de uma pilha");
            Console.WriteLine("3 - Transferir uma pilha para outra auxiliar");
            Console.WriteLine("4 - Imprimir números pares/impares de uma pilha");
            Console.WriteLine("0 - Sair do programa");
            opc = int.Parse(Console.ReadLine());

            switch (opc)
            {
                case 0:
                    Console.WriteLine("Até mais");
                    break;
                case 1:
                    compararPilhas(pilha1, pilha2);
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 2:
                    do
                    {
                        Console.WriteLine("Digite 1 para a Pilha 1, 2 para a Pilha 2 ou 3 para a Pilha Auxiliar.");
                        opcpilha = int.Parse(Console.ReadLine());
                    } while ((opcpilha < 1) && (opcpilha > 3));
                    switch (opcpilha)
                    {
                        case 1:
                            pilha_opc = pilha1;
                            break;
                        case 2:
                            pilha_opc = pilha2;
                            break;
                        default:
                            pilha_opc = pilhaAux;
                            break;
                    }
                    retornarNumeros(pilha_opc, 2);
                    valoresPilhas(pilha_opc);
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 3:
                    do
                    {
                        Console.WriteLine("Digite:\n1 - para transferir da Pilha 1");
                        Console.WriteLine("2 - para transferir da Pilha 2");
                        opcpilha = int.Parse(Console.ReadLine());
                    } while ((opcpilha < 1) && (opcpilha > 2));
                    switch (opcpilha)
                    {
                        case 1:
                            pilhaAux = transferirPilha(pilha1);
                            break;
                        default:
                            pilhaAux = transferirPilha(pilha2);
                            break;
                    }
                    Console.WriteLine($"Todos os Números da Pilha {opcpilha} Transferida:");
                    retornarNumeros(pilhaAux, 2);
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                case 4:
                    do
                    {
                        Console.WriteLine("Digite 1 para a Pilha 1, 2 para a Pilha 2 ou 3 para a Pilha Auxiliar");
                        opcpilha = int.Parse(Console.ReadLine());
                    } while ((opcpilha < 1) && (opcpilha > 2));
                    switch (opcpilha)
                    {
                        case 1:
                            pilha_opc = pilha1;
                            break;
                        case 2:
                            pilha_opc = pilha2;
                            break;
                        default:
                            pilha_opc = pilhaAux;
                            break;
                    }
                    retornarNumeros(pilha_opc, 0);
                    retornarNumeros(pilha_opc, 1);
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        } while (opc != 0);
    }
    static void compararPilhas(PilhaNumero p1, PilhaNumero p2)
    {
        int p1s, p2s;
        p1s = p1.getContador();
        p2s = p2.getContador();

        if (p1s == p2s)
        {
            Console.WriteLine($"As pilhas são de tamanhos iguais: {p1s}.");
        }
        else if (p1s > p2s)
        {
            Console.WriteLine($"A Pilha 1 ({p1s}) é maior que a Pilha 2 ({p2s})");
        }
        else
        {
            Console.WriteLine($"A Pilha 2 ({p2s}) é maior que a Pilha 1 ({p1s})");
        }
    }
    static void valoresPilhas(PilhaNumero pilha)
    {
        float resultado = 0;
        resultado = pilha.getValores(0);
        Console.WriteLine($"O menor valor da pilha é: {resultado}");
        resultado = pilha.getValores(1);
        Console.WriteLine($"O maior valor da pilha é: {resultado}");
        resultado = pilha.getValores(2);
        Console.WriteLine($"A média aritmética pilha é: {resultado}");
    }
    static Numero geraNumero()
    {
        Numero numerotemp = new Numero(new Random().Next(1, 100));
        return numerotemp;
    }
    static void retornarNumeros(PilhaNumero pilha, int tipo)
    {
        switch (tipo)
        {
            case 0:
                Console.WriteLine("Números pares: " + pilha.print(0));
                break;
            case 1:
                Console.WriteLine("Números ímpares: " + pilha.print(1));
                break;
            case 2:
                Console.WriteLine(pilha.print(2));
                break;
        }
    }
    static PilhaNumero transferirPilha(PilhaNumero pilha)
    {
        int tamanhoPilha = 0;

        Numero aux, auxFinal;
        PilhaNumero tempAux = new PilhaNumero();
        PilhaNumero tempFinal = new PilhaNumero();

        Console.WriteLine("Todos os Números da pilha original:");
        retornarNumeros(pilha, 2);
        tamanhoPilha = pilha.getContador(); // verifico o tamanho da pilha que vou transferir 
        for (int i = 0; i < tamanhoPilha; i++)
        {
            aux = new Numero(pilha.pop()); // faço um pop na pilha e insiro numa pilha auxiliar
            tempAux.push(aux);
        }
        for (int i = 0; i < tamanhoPilha; i++)
        {
            auxFinal = new Numero(tempAux.pop()); // faço pop da auxiliar e insiro na auxiliar final
            tempFinal.push(auxFinal);
        }
        return tempFinal; // retorno a auxiliar final
    }
}