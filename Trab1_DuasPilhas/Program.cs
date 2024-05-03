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
            Console.WriteLine("\nOlá, duas pilhas foram criadas aleatoriamente.\n1 - Verificar o tamanho das pilhas");
            Console.WriteLine("2 - Verificar maior, menor, média aritmética de uma pilha");
            Console.WriteLine("3 - Transferir/Imprimir uma pilha para outra auxiliar");
            Console.WriteLine("4 - Imprimir números pares/impares de uma pilha");
            Console.WriteLine("5 - Limpar a tela");
            Console.WriteLine("0 - Sair do programa");
            opc = int.Parse(Console.ReadLine());

            switch (opc)
            {
                case 1:
                    compararPilhas(pilha1, pilha2);
                    break;
                case 2:
                    do
                    {
                        Console.WriteLine("Digite 1 para a Pilha 1 ou 2 para a Pilha 2.");
                        opcpilha = int.Parse(Console.ReadLine());
                    } while ((opcpilha < 1) && (opcpilha > 2));
                    switch (opcpilha)
                    {
                        case 1:
                            valoresPilhas(pilha1);
                            break;
                        default:
                            valoresPilhas(pilha2);
                            break;
                    }
                    break;
                case 3:
                    do
                    {
                        Console.WriteLine("Digite:\n1 - para transferir a Pilha 1");
                        Console.WriteLine("2 - para transferir a Pilha 2");
                        Console.WriteLine("0 - para imprimir a Pilha Transferida");
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
                    Console.WriteLine("Todos os Números da Pilha Transferida:");
                    retornarNumeros(pilhaAux, 2);
                    break;
                case 4:
                    do
                    {
                        Console.WriteLine("Digite 1 para a Pilha 1 ou 2 para a Pilha 2.");
                        opcpilha = int.Parse(Console.ReadLine());
                    } while ((opcpilha < 1) && (opcpilha > 2));
                    switch (opcpilha)
                    {
                        case 1:
                            retornarNumeros(pilha1, 2);
                            retornarNumeros(pilha1, 0);
                            retornarNumeros(pilha1, 1);
                            break;
                        default:
                            retornarNumeros(pilha2, 2);
                            retornarNumeros(pilha2, 0);
                            retornarNumeros(pilha2, 1);
                            break;
                    }
                    break;
                case 5:
                    Console.Clear();
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