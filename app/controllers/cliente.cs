using System;
using System.Collections.Generic;

namespace advanced
{
  public class Cliente : Pessoa
  {
    // ATRIBUTOS 
    private int pontuacao;
    private List<Operacao> historico;
    private string dados;
    public int id { get; }
    public string nome { get; }
    public string telefone { get; }
    public string documento { get; }
    public string email { get; }
    public static DateTime Now { get; }

    // CONSTRUTOR
    public Cliente() { }
    public Cliente(int pontuacao, string nome, string documento, string telefone, string email)
    {
      this.pontuacao = pontuacao;
      this.historico = new List<Operacao>(historico);
      this.nome = nome;
      this.email = email;
      this.documento = documento;
      this.telefone = telefone;


    }

    // MÉTODOS PÚBLICOS
    public static Cliente CadastrarCliente(int usuario_id, string nome, string email, string documento, string telefone, int pontuacao)
    {
      // remover 'pontuacao' e adicionar 'usuario_id' no DAO
      Console.WriteLine(ClienteDAO.InserirCliente(usuario_id, nome, email, documento, telefone, pontuacao));
      return new Cliente();
    }

    public bool Comprar(float valor)
    {
      var op = new Venda(this.id, Now, valor);
      var resp = op.RegistrarOperacao(this.id); // Vai inserir operação no banco

      if (resp)
      {
        this.historico.Add(op); // Adicionar operação no histórico
        this.pontuacao += (int)valor; // Adicionando valor da compra na pontuação 
        this.AtualizarPontuacao();

        return true;
      }
      else
      {
        return false;
      }

    }

    public bool Resgatar(Premio premio)
    {
      var op = new Resgate(this.id, Now, premio);
      var resp = op.RegistrarOperacao(this.id); // Vai inserir operação no banco

      if (resp)
      {
        this.historico.Add(op); // Adicionar operação no histórico
        this.pontuacao -= (int)premio.pontuacao;
        this.AtualizarPontuacao();

        return true;
      }
      else
      {
        return false;
      }
    }

    // MÉTODOS PRIVADOS
    private bool AtualizarPontuacao()
    {
      var resp = ClienteDAO.AtualizarPontucao(this.id, this.pontuacao);

      return resp;
    }

  }
}
