using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Trab1_DuasPilhas
{
    internal class PilhaNumero
    {
        Numero topo;

        public PilhaNumero()
        {
            topo = null;
        }
        public void push(Numero aux)
        {
            if (vazia() == true)
            {
                topo = aux;
            }
            else
            {
                aux.setAnterior(topo);
                topo = aux;
            }
        }
        public int pop()
        {
            int valor = 0;
            if (!vazia())
            {
                valor = topo.getNumero();
                topo = topo.getAnterior();
            }
            return valor;
        }
        public int getContador()
        {
            int contador = 0;
            Numero aux = topo;
            if (!vazia())
            {
                do
                {
                    contador++;
                    aux = aux.getAnterior();
                } while (aux != null);
            }
            return contador;
        }
        bool vazia()
        {
            if (topo == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string print(int tipo)
        {
            Numero aux = topo;
            string texto = "";
            if (!vazia())
            {
                switch (tipo)
                {
                    case 0: // pares
                        do
                        {
                            if (aux != null)
                            {
                                if (aux.getNumero() % 2 == 0)
                                {
                                    texto += $"{aux.ToString()} ";
                                }
                            }
                            aux = aux.getAnterior();
                        } while (aux != null);
                        break;
                    case 1: // impares
                        do
                        {
                            if (aux != null)
                            {
                                if (aux.getNumero() % 2 != 0)
                                {
                                    texto += $"{aux.ToString()} ";
                                }
                            }
                            aux = aux.getAnterior();
                        } while (aux != null);
                        break;
                    default: // todos os numeros
                        do
                        {
                            texto += $"{aux.ToString()} ";
                            aux = aux.getAnterior();
                        } while (aux != null);
                        break;
                }
            }
            return texto;
        }
        public float getValores(int tamanho)
        {
            Numero aux = topo;
            int valor = 0, contador = 0;
            float valorResult = 0;
            if (!vazia())
            {
                switch (tamanho)
                {
                    case 0: // pega o menor valor
                        valorResult = aux.getNumero();
                        do
                        {
                            aux = aux.getAnterior();
                            if (aux != null)
                            {
                                valor = aux.getNumero();
                            }
                            if (valor < valorResult)
                            {
                                valorResult = valor;
                            }
                        } while (aux != null);
                        break;
                    case 1: // pega o maior valor
                        do
                        {
                            aux = aux.getAnterior();
                            if (aux != null)
                            {
                                valor = aux.getNumero();
                            }
                            if (valor > valorResult)
                            {
                                valorResult = valor;
                            }
                        } while (aux != null);
                        break;
                    default:
                        valor = aux.getNumero();
                        do
                        {
                            contador++;
                            aux = aux.getAnterior();
                            if (aux != null)
                            {
                                valor += aux.getNumero();
                            }
                        } while (aux != null);
                        if (contador > 0)
                        {
                            valorResult = (valor / contador);
                        }
                        break;
                }
            }
            return valorResult;
        }
    }
}
