using System;

namespace advanced
{
  // Interface usuário, menu principal
  public static class Home
  {


    public static void Menu(Usuario usuario)
    {
      Console.WriteLine();
      Console.WriteLine("---------- Home  ----------");
      Console.WriteLine();

      Console.WriteLine("Digite o número da opção desejada:");
      Console.WriteLine("1 - Realizar Cadastro de Cliente");
      Console.WriteLine("2 - Cadastrar Promoção");
      Console.WriteLine();


      int opcao = Int32.Parse(Console.ReadLine());

      if (opcao == 1)
      {
        CadastroCliente.Menu(usuario);
      }
      else if (opcao == 2)
      {
        CadastroPromocao.Menu(usuario);

      }
      else
      {
        Console.WriteLine("Opção Inválida");
      }
    }


  }
}
