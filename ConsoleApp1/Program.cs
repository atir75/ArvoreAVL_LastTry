using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ArvoreAVL
{
    class Arvore
    {
        public Arvore(int n) // Construtor
        {
            info = n;
            fb = 0;
            sae = sad = null;
        }

        public void Balancear(Arvore arv, int n)
        {
            int fatorbalanceamento = fb;
            if (fatorbalanceamento > 1 || this.sad.fb <= 0)
            {
                this.info = Rotacao(info);
            }
            else (fatorbalanceamento < 1 || this.sae.fb >= 0)
            {
                this.info = Rotacao(RAIZ);
            }
        }

        public void Rotacao(Arvore RAIZ)
        {
            if (this == RAIZ)
            {
                if (this.fb < -1)
                {
                    RAIZ = this.sae;
                    this.sae = null;
                    RAIZ.Insere(this);
                    this.fb++;
                    return;
                }
                else if (this.fb > 1)
                {
                    RAIZ = this.sad;
                    this.sad = null;
                    RAIZ.Insere(this);
                    this.fb--;
                }
            }
            if (this.sae != null)
            {
                if (this.sae.fb < -1)
                {
                    return;
                }
                if (this.sae.fb > 1)
                {
                    return;
                }
            }
            if (this.sad != null)
            {
                if (this.sad.fb < -1)
                {
                    return;
                }
                if (this.sad.fb > 1)
                {
                    return;
                }
            }
        }


        public void Insere(Arvore arv)
        {
            int aux;
            if (arv.info <= this.info)
            {
                if (this.sae == null)
                {
                    this.sae = arv;
                    this.fb = this.fb - 1;
                }
                else
                {
                    aux = this.sae.fb;
                    (this.sae).Insere(arv);
                    if (Math.Abs(this.sae.fb) > Math.Abs(aux))
                        this.fb = this.fb - 1;
                }
            }
            else
            {
                if (this.sad == null)
                {
                    this.sad = arv;
                    this.fb = this.fb + 1;
                }
                else
                {
                    aux = this.sad.fb;
                    (this.sad).Insere(arv);
                    if (Math.Abs(this.sad.fb) > Math.Abs(aux))
                        this.fb = this.fb + 1;
                }
            }
        }
        private int info;
        private int fb;
        Arvore sae;
        Arvore sad;
    }

    public void MostraArvorePreOrdem()
    {
        Console.Write("{0}", this.info);
        if (this.sae != null) (this.sae).MostraArvorePreOrdem();
        if (this.sad != null) (this.sad).MostraArvorePreOrdem();
    }

    public void MostraArvoreOrdemSimetrica()
    {
        if (this.sae != null) (this.sae).MostraArvoreOrdemSimetrica();
        Console.Write("{0}", this info);
        if (this.sad != null) (this.sae).MostraArvoreOrdemSimetrica();
    }

    public void MostraArvorePosOrdem(Arvore avr)
    {
        if (this.sae != null) (this.sae).MostraArvorePosOrdem();
        if (this.sad != null) (this.sad).MostraArvorePosOrdem();
        Console.Write("{0}", this.info);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Arvore RAIZ = null;
            Arvore arv;
            int n, escolha, resultado, maiornivel, nivelsa;
            do
            {
                Console.Clear();
                Console.WriteLine(" Menu Principal");
                Console.WriteLine("(1) - Insere um elemento na Árvore");
                Console.WriteLine("(2) - Pesquisa um elemento na Árvore");
                Console.WriteLine("(3) - Lista Arvore - Pré-Ordem");
                Console.WriteLine("(4) - Lista Arvore - Ordem Simétrica");
                Console.WriteLine("(5) - Lista Arvore - Pos-Ordem");
                Console.WriteLine("(6) - Lista Arvore - Em Ordem");
                Console.WriteLine("(7) - Calcula Maior Nivel");
                Console.WriteLine("(8) - Para SAIR");
                escolha = int.Parse(Console.ReadKey(true).KeyChar.ToString
               ());
                switch (escolha)
                {
                    case 1: // Insere um elemento na Arvore
                        Console.Clear();
                        Console.Write("Entre com um numero : ");
                        n = int.Parse(Console.ReadLine());
                        arv = new Arvore(n);
                        if (RAIZ == null)
                            RAIZ = arv;
                        else
                            RAIZ.Insere(arv);
                        break;
                }
            } while (escolha != 8);
        }
    }
}