using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace M2_Conversor
{
    class Program
    {
        static void Main(string[] args)

        {
            //Declaração de variaveis.
            string main_code, sec_code, thir_code, four_code, fiv_code, ret;
            string input_var_s, moedadolar = "", datadolar ="", moedaeuro = "", dataeuro = "";
            double input_var, conversao = 0;
            double dol_compra=0, dol_venda = 0, eur_compra = 0, eur_venda = 0;             

            //variaveis de controle, tratativas e apresentação em terminal
            bool continuar = true;
            bool sucesso = true;
            string erro =           "\n\n            _________________________________"  +
                                      "\n           |      ERRO! OPÇÃO INVÁLIDA       |" +
                                      "\n           |  Opção não consta na aplicação  |" +
                                      "\n           |        Presisone Enter          |" +
                                      "\n           |     E insira um valor válido    |" +
                                      "\n           |_________________________________|\n";

            string retorno =        "\n\n          ______________________________________"  +
                                      "\n         |                                      |" +
                                      "\n         | Retorno ao menu anterior selecionado |" +
                                      "\n         |    Pressione enter para prosseguir   |" +
                                      "\n         |______________________________________|\n";

            string ret_main_menu =   "\n\n         _______________________________________"  +
                                       "\n        |                                       |" +
                                       "\n        | Retorno ao menu principal selecionado |" +
                                       "\n        |    Pressione enter para prosseguir    |" +
                                       "\n        |_______________________________________|\n";

            string invalid_entrada = "\n\n         _______________________________________"  +
                                       "\n        |                                       |" +
                                       "\n        | !! Entrada para conversão Inválida !! |" +
                                       "\n        |     Favor informe um valor válido.    |" +
                                       "\n        |_______________________________________|\n";

            string prosseguir =        "\n         ______________________________________"  +
                                       "\n        |                                      |" +
                                       "\n        |   Pressione P     para PROSSEGUIR.   |" +
                                       "\n        |   Pressione S     para SAIR.         |" +
                                       "\n        |______________________________________|\n";


            //Apresentação da aplicação
            do
            {
                Console.Clear();
                //apresentação aplicação - Menu principal
                Console.WriteLine("\n    ______ |  Opções de conversão de valores  | ______ ");
                Console.WriteLine(  "   |                                                  |" +
                                  "\n   |   Conversor                   Cód de Entrada     |" +
                                  "\n   |                                                  |" +
                                  "\n   | Conversor de Medidas                  1          |" +
                                  "\n   | Conversor de Moedas                   2          |" +
                                  "\n   | Conversor de Massa                    3          |" +
                                  "\n   |                                                  |" +
                                  "\n   | Encerrar a aplicação                  4          |" +
                                  "\n   |__________________________________________________|");

                Console.Write("\n    Selecione o código da opção desejada: ");
                main_code = Console.ReadLine();
                
                //Processamento - Executa a opção selecionada
                switch (main_code)
                {
                    //Conversor - Medidas principal
                    case "1":

                        do
                        {

                            Console.Clear();
                            //apresentação aplicação - sub menu 1
                            Console.WriteLine("\n    ___________ |  Conversor de Medidas  | ___________ ");
                            Console.WriteLine("   |                                                  |" +
                                              "\n   |   Conversões                   Cód de Entrada    |" +
                                              "\n   |                                                  |" +
                                              "\n   | Conversões Métricas                    A         |" +
                                              "\n   | Conversões Volumétricas                B         |" +
                                              "\n   |                                                  |" +
                                              "\n   | Retornar ao Menu Principal             C         |" +
                                              "\n   |                                                  |" +
                                              "\n   | Encerrar Aplicação                     S         |" +
                                              "\n   |__________________________________________________|");

                            Console.Write("\n    Selecione o código da opção desejada: ");
                            sec_code = Console.ReadLine();

                            //seleção das opções
                            switch (sec_code)
                            {
                                //Conversor - Medidas métricas
                                case "A": case "a":

                                    do
                                    {
                                        //limpar a tela para a exibição de nova instância
                                        Console.Clear();
                                        //apresentação aplicação - sub menu 2
                                        Console.WriteLine("\n    ____________ |  Conversões Métricas  | ___________ ");
                                        Console.WriteLine("   |                                                  |" +
                                                          "\n   |   Conversões                   Cód de Entrada    |" +
                                                          "\n   |                                                  |" +
                                                          "\n   | Metro para centímetro                  1         |" +
                                                          "\n   | Centímetro para Metro                  2         |" +
                                                          "\n   |                                                  |" +
                                                          "\n   | Retornar ao Menu Anterior              3         |" +
                                                          "\n   | Retornar ao Menu Principal             4         |" +
                                                          "\n   |                                                  |" +
                                                          "\n   | Encerrar Aplicação                     S         |" +
                                                          "\n   |__________________________________________________|");

                                        Console.Write("\n    Selecione o código da opção desejada: ");
                                        fiv_code = Console.ReadLine();

                                        switch (fiv_code)
                                        {
                                            //Conversão de Metros para Centímetros
                                            case "1":

                                                Console.Clear();
                                                //looping de tratativa para entrada de dados inválidos
                                                do
                                                {

                                                    Console.Write("\n\n          _______________________________________" +
                                                                    "\n         |                                       |" +
                                                                    "\n         | Conversão de Metros para Centímetros  |" +
                                                                    "\n         |_______________________________________|\n");

                                                    Console.Write("\nInforme o valor em Metros a ser convertido em Centímetros: ");
                                                    input_var_s = (Console.ReadLine());

                                                    //tratativa de controle boleano para validação se o dado é númerico ou não
                                                    sucesso = (double.TryParse(input_var_s, out input_var));

                                                    //Se a entrada cumprir o parãmetro, passa a proxima tratativa de positivo ou negativo 
                                                    if (sucesso)
                                                    {
                                                        //tratativa de controle condicional, se a váriavel é negativa
                                                        if (input_var < 0) { Console.Write(invalid_entrada); continuar = true; }

                                                        else
                                                        {
                                                            //Satisfazendo a entrada como um dado númerico, a variavel de controlle bool, recebe outro valor
                                                            //e deste modo pode sair do looping e prosseguir no código
                                                            continuar = false;
                                                            conversao = input_var * 100;
                                                            Console.Write("\nA conversão de {0}m em centímetros é igual a: {1}cm \n\n", input_var, conversao);
                                                        }

                                                    }
                                                    else
                                                    {
                                                        //apresentação de entrada inválida
                                                        Console.Write(invalid_entrada);
                                                    }

                                                } while (continuar);

                                                //lopping de opções e tratativa para retorno ou saida da aplicação após conversão
                                                do
                                                {
                                                    Console.Write(prosseguir);
                                                    ret = Console.ReadLine();

                                                    //condição para retorno
                                                    if (ret == "P" || ret == "p") { fiv_code = "R"; }
                                                    //condição para saida da aplicação
                                                    if (ret == "S" || ret == "s") { Environment.Exit(0); }
                                                    //condição para entrada invalida
                                                    if ((ret != "P" && ret != "p") && (ret != "S" && ret != "s")) { Console.Write(erro); }

                                                } while ((ret != "P" && ret != "p") && (ret != "S" && ret != "s"));

                                            break;
                                            //Conversão de Centímetros para Metros
                                            case "2":

                                                Console.Clear();
                                                do
                                                {
                                                    Console.Write("\n\n          _______________________________________" +
                                                                    "\n         |                                       |" +
                                                                    "\n         | Conversão de Centímetros para Metros  |" +
                                                                    "\n         |_______________________________________|\n");

                                                    Console.Write("\nInforme o valor em Centímetros a ser convertido em Metros: ");
                                                    input_var_s = (Console.ReadLine());

                                                    sucesso = (double.TryParse(input_var_s, out input_var));

                                                    if (sucesso)
                                                    {

                                                        if (input_var < 0) { Console.Write(invalid_entrada); continuar = true; }
                                                        else
                                                        {
                                                            continuar = false;
                                                            conversao = input_var * 0.01;
                                                            Console.Write("\nA conversão de {0}cm em metros é igual a: {1}m \n\n", input_var, conversao);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.Write(invalid_entrada);
                                                    }

                                                } while (continuar);

                                                do
                                                {
                                                    Console.Write(prosseguir);
                                                    ret = Console.ReadLine();

                                                    if (ret == "P" || ret == "p") { fiv_code = "R"; }
                                                    if (ret == "S" || ret == "s") { Environment.Exit(0); }
                                                    if ((ret != "P" && ret != "p") && (ret != "S" && ret != "s")) { Console.Write(erro); }

                                                } while ((ret != "P" && ret != "p") && (ret != "S" && ret != "s"));

                                            break;
                                            //caso a opção selecionada seja retorno ao menu anterior
                                            case "3":
                                                Console.Write(retorno, sec_code = "R");
                                                Console.ReadKey();
                                            break;
                                            //caso a opção selecionada seja retorno ao menu principal
                                            case "4":
                                                Console.Write(ret_main_menu, main_code = "R");
                                                Console.ReadKey();
                                            break;
                                            //caso a opção selecionada seja encerrar a aplicação
                                            case "S": case "s":
                                                Environment.Exit(0);
                                            break;
                                            ////caso a opção selecionada seja retorno diferente do que aprensta as opções da aplicação
                                            default:
                                                Console.Write(erro);
                                                Console.ReadKey();
                                            break;
                                        }

                                    } while ((fiv_code != "1") && (fiv_code != "2") && (fiv_code != "3") &&
                                            (fiv_code != "4") && (fiv_code != "S" && fiv_code != "s"));
                                break;
                                //Conversor - Medidas Volumétricas
                                case "B": case "b":

                                    do
                                    {

                                        Console.Clear();
                                        //apresentação aplicação - sub menu 3
                                        Console.WriteLine("\n    _________ |  Conversões Volumétricas  | __________ ");
                                        Console.WriteLine(  "   |                                                  |" +
                                                          "\n   |   Conversões                   Cód de Entrada    |" +
                                                          "\n   |                                                  |" +
                                                          "\n   | Litro para Mililitro                   1         |" +
                                                          "\n   | Mililitro para Litro                   2         |" +
                                                          "\n   |                                                  |" +
                                                          "\n   | Retornar ao Menu Anterior              3         |" +
                                                          "\n   | Retornar ao Menu Principal             4         |" +
                                                          "\n   |                                                  |" +
                                                          "\n   | Encerrar Aplicação                     S         |" +
                                                          "\n   |__________________________________________________|");

                                        Console.Write("\n    Selecione o código da opção desejada: ");
                                        fiv_code = Console.ReadLine();

                                        switch (fiv_code)
                                        {

                                            case "1":

                                                Console.Clear();
                                                do
                                                {
                                                    Console.Write("\n\n          _______________________________________" +
                                                                    "\n         |                                       |" +
                                                                    "\n         |   Conversão de Litro para Mililitro   |" +
                                                                    "\n         |_______________________________________|\n");

                                                    Console.Write("\nInforme o valor em Litros a ser convertido em Mililitros: ");
                                                    input_var_s = (Console.ReadLine());

                                                    sucesso = (double.TryParse(input_var_s, out input_var));

                                                    if (sucesso)
                                                    {
                                                        if (input_var < 0) { Console.Write(invalid_entrada); continuar = true; }

                                                        else
                                                        {
                                                            continuar = false;
                                                            conversao = input_var * 1000;
                                                            Console.Write("\nA conversão de {0}L em Mililitros é igual a: {1}mL \n\n", input_var, conversao);
                                                        }

                                                    }
                                                    else
                                                    {
                                                        Console.Write(invalid_entrada);
                                                    }

                                                } while (continuar);

                                                do
                                                {
                                                    Console.Write(prosseguir);
                                                    ret = Console.ReadLine();

                                                    if (ret == "P" || ret == "p") { fiv_code = "R"; }
                                                    if (ret == "S" || ret == "s") { Environment.Exit(0); }
                                                    if ((ret != "P" && ret != "p") && (ret != "S" && ret != "s")) { Console.Write(erro); }

                                                } while ((ret != "P" && ret != "p") && (ret != "S" && ret != "s"));

                                            break;
                                            case "2":

                                                Console.Clear();
                                                do
                                                {
                                                    Console.Write("\n\n          _______________________________________" +
                                                                    "\n         |                                       |" +
                                                                    "\n         |   Conversão de Mililitro para Litro   |" +
                                                                    "\n         |_______________________________________|\n");

                                                    Console.Write("\nInforme o valor em Mililitros a ser convertido em Litros: ");
                                                    input_var_s = (Console.ReadLine());

                                                    sucesso = (double.TryParse(input_var_s, out input_var));

                                                    if (sucesso)
                                                    {

                                                        if (input_var < 0) { Console.Write(invalid_entrada); continuar = true; }
                                                        else
                                                        {
                                                            continuar = false;
                                                            conversao = input_var * 0.001;
                                                            Console.Write("\nA conversão de {0}mL em Litros é igual a: {1}L \n\n", input_var, conversao);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.Write(invalid_entrada);
                                                    }

                                                } while (continuar);

                                                do
                                                {
                                                    Console.Write(prosseguir);
                                                    ret = Console.ReadLine();

                                                    if (ret == "P" || ret == "p") { fiv_code = "R"; }
                                                    if (ret == "S" || ret == "s") { Environment.Exit(0); }
                                                    if ((ret != "P" && ret != "p") && (ret != "S" && ret != "s")) { Console.Write(erro); }

                                                } while ((ret != "P" && ret != "p") && (ret != "S" && ret != "s"));

                                            break;
                                            case "3":
                                                Console.Write(retorno, sec_code = "R");
                                                Console.ReadKey();
                                            break;
                                            case "4":
                                                Console.Write(ret_main_menu, main_code = "R");
                                                Console.ReadKey();
                                            break;
                                            case "S":
                                            case "s":
                                                Environment.Exit(0);
                                            break;
                                            default:
                                                Console.Write(erro);
                                                Console.ReadKey();
                                            break;
                                        }

                                    }while ((fiv_code != "1") && (fiv_code != "2") && (fiv_code != "3") &&
                                            (fiv_code != "4") && (fiv_code != "S" && fiv_code != "s"));

                                break;
                                case "C": case "c":
                                    Console.Write(retorno, main_code = "R");
                                    Console.ReadKey();
                                break;
                                case "S": case "s":
                                    Environment.Exit(0);
                                break;
                                default:
                                    Console.Write(erro);
                                    Console.ReadKey();
                                break;
                            }

                        } while ((sec_code != "A" && sec_code != "a") && (sec_code != "B" && sec_code != "b") &&
                                 (sec_code != "C" && sec_code != "c") && (sec_code != "S" && sec_code != "s"));

                    break;
                    //Conversor - Moedas principal
                    case "2":

                        do
                        {
                            //armazenar os dados baixados da pagina disponibilizados pela api
                            var requestdol = WebRequest.Create("https://economia.awesomeapi.com.br/USD-BRL");
                            //utilização do método get afim de armazenar os dados em um objeto
                            requestdol.Method = "GET";
                            var responsedol = (HttpWebResponse)requestdol.GetResponse();

                            //se o retorno obtiver dados, executa a sequencia de instruções abaixo
                            if (responsedol.StatusCode == HttpStatusCode.OK)
                            {
                                //utiliza-se o metodo abaixo, para ler o corpo de dados contidos no objeto
                                using (var stream = responsedol.GetResponseStream())
                                {
                                    var reader = new StreamReader(stream);
                                    var json = reader.ReadToEnd();

                                    //realiza um looping de pesquisa dentro dos dados arquivos na varivel  json, que efetuou a leitura
                                    //afim de buscar partes especificas da api, tais como a cotação da moeda, o nome e a data.
                                    var data = JsonConvert.DeserializeObject<dynamic[]>(json);
                                    foreach (dynamic temp in data)
                                    {
                                        //variaveis de busca consumindo os valores encontrados na leitura
                                        moedadolar = temp.name;

                                        dol_compra = temp.ask;

                                        dol_venda = temp.bid;

                                        datadolar = temp.create_date;

                                    }

                                }

                            }
                            //caso não encontre dados online, utiliza da base de dados na ultima vez atualizado manualmente
                            else { Console.Write("\n    Erro na busca de dados online. "); moedadolar = "Dólar Americano/Real Brasileiro"; dol_compra = 5.2199; dol_venda = 5.2182; datadolar = "2021-05-31 17:59:58"; }

                            var requesteur = WebRequest.Create("https://economia.awesomeapi.com.br/EUR-BRL");
                            requesteur.Method = "GET";
                            var responseeur = (HttpWebResponse)requesteur.GetResponse();

                            if (responseeur.StatusCode == HttpStatusCode.OK)
                            {
                                using (var stream = responseeur.GetResponseStream())
                                {
                                    var reader = new StreamReader(stream);
                                    var json = reader.ReadToEnd();


                                    var data = JsonConvert.DeserializeObject<dynamic[]>(json);
                                    foreach (dynamic temp in data)
                                    {
                                        moedaeuro = temp.name;

                                        eur_compra = temp.ask;

                                        eur_venda = temp.bid;

                                        dataeuro = temp.create_date;

                                    }

                                }

                            }
                            else { Console.Write("\n    Erro na busca de dados online. "); moedaeuro = "Euro/Real Brasileiro"; eur_compra = 6.3838; eur_venda = 6.3791; dataeuro = "2021-05-31 20:08:16"; }
                            
                            Console.Clear();
                            //apresentação aplicação - sub menu 4
                            Console.WriteLine("\n    _____________|  Conversor de Moedas  |____________ ");
                            Console.WriteLine(  "   |                                                  |" +
                                              "\n   |   Conversões                   Cód de Entrada    |" +
                                              "\n   |                                                  |" +
                                              "\n   | Utilizando USD Dolar    USD {0}      A        |" +
                                              "\n   | Utilizando EUR Euro     EUR {1}      B        |" +
                                              "\n   |                                                  |" +
                                              "\n   | Retornar ao Menu Principal              C        |" +
                                              "\n   |                                                  |" +
                                              "\n   | Encerrar Aplicação                      S        |" +
                                              "\n   |__________________________________________________|",dol_compra,eur_compra);

                            Console.Write("\n    Selecione o código da opção desejada: ");
                            thir_code = Console.ReadLine();
                            
                            switch (thir_code)
                            {
                                //Conversor - Moedas - USD/BRL
                                case "A": case "a":

                                    do
                                    {

                                        Console.Clear();
                                        //apresentação aplicação - sub menu 5
                                        Console.WriteLine("\n    _______________|  Conversões de Moedas  |_______________ ");
                                        Console.WriteLine(  "   |                                                        |" +
                                                          "\n   |        Moeda: {2}          |                            " +
                                                          "\n   |                                                        |" +
                                                          "\n   |   Conversões                        Cód de Entrada     |" +                                                
                                                          "\n   |                                                        |" +
                                                          "\n   | Dolar para Real -   VENDA    USD {0}       1        |" +
                                                          "\n   | Real para Dolar -   COMPRA   BRL {1}       2        |" +
                                                          "\n   |                                                        |" +                                                          
                                                          "\n   |        Data Cotação: {3}               |                " +
                                                          "\n   |                                                        |" +
                                                          "\n   | Retornar ao Menu Anterior                     3        |" +
                                                          "\n   | Retornar ao Menu Principal                    4        |" +
                                                          "\n   |                                                        |" +
                                                          "\n   | Encerrar Aplicação                            S        |" +
                                                          "\n   |________________________________________________________|", dol_venda, dol_compra,moedadolar, datadolar);

                                        Console.Write("\n    Selecione o código da opção desejada: ");
                                        fiv_code = Console.ReadLine();

                                        switch (fiv_code)
                                        {

                                            case "1":

                                                Console.Clear();
                                                do
                                                {

                                                    Console.Write("\n\n          _______________________________________" +
                                                                    "\n         |                                       |" +
                                                                    "\n         | Conversão de USD Dolar para BRL Real  |" +
                                                                    "\n         |_______________________________________|\n");

                                                    Console.Write("\nInforme o valor em Dólares a ser convertido em Reais: ");
                                                    input_var_s = (Console.ReadLine());

                                                    sucesso = (double.TryParse(input_var_s, out input_var));

                                                    if (sucesso)
                                                    {
                                                        if (input_var < 0) { Console.Write(invalid_entrada); continuar = true; }

                                                        else
                                                        {
                                                            continuar = false;
                                                            conversao = Math.Round(input_var * dol_venda,2);
                                                            Console.Write("\nA conversão de USD {0} em reais é igual a: BRL {1} \n\n", input_var, conversao);
                                                        }

                                                    }
                                                    else
                                                    {
                                                        Console.Write(invalid_entrada);
                                                    }

                                                } while (continuar);

                                                do
                                                {
                                                    Console.Write(prosseguir);
                                                    ret = Console.ReadLine();

                                                    if (ret == "P" || ret == "p") { thir_code = "R"; }
                                                    if (ret == "S" || ret == "s") { Environment.Exit(0); }
                                                    if ((ret != "P" && ret != "p") && (ret != "S" && ret != "s")) { Console.Write(erro); }

                                                } while ((ret != "P" && ret != "p") && (ret != "S" && ret != "s"));

                                            break;
                                            case "2":

                                                Console.Clear();
                                                do
                                                {
                                                    Console.Write("\n\n          _______________________________________" +
                                                                    "\n         |                                       |" +
                                                                    "\n         |  Conversão de BRL Real para USD Dolar |" +
                                                                    "\n         |_______________________________________|\n");

                                                    Console.Write("\nInforme o valor em Reais a ser convertido em Dolares: ");
                                                    input_var_s = (Console.ReadLine());

                                                    sucesso = (double.TryParse(input_var_s, out input_var));

                                                    if (sucesso)
                                                    {

                                                        if (input_var < 0) { Console.Write(invalid_entrada); continuar = true; }
                                                        else
                                                        {
                                                            continuar = false;
                                                            conversao = Math.Round(input_var / dol_compra,2);
                                                            Console.Write("\nA conversão de BRL {0} em dolares é igual a: USD {1} \n\n", input_var, conversao);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.Write(invalid_entrada);
                                                    }

                                                } while (continuar);

                                                do
                                                {
                                                    Console.Write(prosseguir);
                                                    ret = Console.ReadLine();

                                                    if (ret == "P" || ret == "p") { thir_code = "R"; }
                                                    if (ret == "S" || ret == "s") { Environment.Exit(0); }
                                                    if ((ret != "P" && ret != "p") && (ret != "S" && ret != "s")) { Console.Write(erro); }

                                                } while ((ret != "P" && ret != "p") && (ret != "S" && ret != "s"));

                                            break;
                                            case "3":
                                                Console.Write(retorno, thir_code = "R");
                                                Console.ReadKey();
                                            break;
                                            case "4":
                                                Console.Write(ret_main_menu, main_code = "R");
                                                Console.ReadKey();
                                            break;
                                            case "S": case "s":
                                                Environment.Exit(0);
                                            break;
                                            default:
                                                Console.Write(erro);
                                                Console.ReadKey();
                                            break;
                                        }

                                    }while ((fiv_code != "1") && (fiv_code != "2") && (fiv_code != "3") &&
                                            (fiv_code != "4") && (fiv_code != "S" && fiv_code != "s"));

                                break;
                                //Conversor - Moedas  - EUR/BRL
                                case "B": case "b":

                                    do
                                    {
                                        Console.Clear();
                                        //apresentação aplicação - sub menu 6
                                        Console.WriteLine("\n    _______________|  Conversões de Moedas  |_______________ ");
                                        Console.WriteLine(  "   |                                                        |" +
                                                          "\n   |        Moeda: {2}                     |                 " +
                                                          "\n   |                                                        |" +
                                                          "\n   |   Conversões                        Cód de Entrada     |" +
                                                          "\n   |                                                        |" +
                                                          "\n   | Euro para Real -   VENDA    USD {0}        1        |   " +
                                                          "\n   | Real para Euro -   COMPRA   BRL {1}        2        |   " +
                                                          "\n   |                                                        |" +
                                                          "\n   |        Data Cotação: {3}               |                " +
                                                          "\n   |                                                        |" +
                                                          "\n   | Retornar ao Menu Anterior                     3        |" +
                                                          "\n   | Retornar ao Menu Principal                    4        |" +
                                                          "\n   |                                                        |" +
                                                          "\n   | Encerrar Aplicação                            S        |" +
                                                          "\n   |________________________________________________________|", eur_venda, eur_compra, moedaeuro, dataeuro);

                                        Console.Write("\n    Selecione o código da opção desejada: ");
                                        fiv_code = Console.ReadLine();

                                        switch (fiv_code)
                                        {

                                            case "1":

                                                Console.Clear();
                                                do
                                                {

                                                    Console.Write("\n\n          _______________________________________" +
                                                                    "\n         |                                       |" +
                                                                    "\n         |  Conversão de EUR Euro para BRL Real  |" +
                                                                    "\n         |_______________________________________|\n");

                                                    Console.Write("\nInforme o valor em EuroS a ser convertido em Reais: ");
                                                    input_var_s = (Console.ReadLine());

                                                    sucesso = (double.TryParse(input_var_s, out input_var));

                                                    if (sucesso)
                                                    {
                                                        if (input_var < 0) { Console.Write(invalid_entrada); continuar = true; }

                                                        else
                                                        {
                                                            continuar = false;
                                                            conversao = Math.Round(input_var * eur_venda,2);
                                                            Console.Write("\nA conversão de EUR {0} em reais é igual a: BRL {1} \n\n", input_var, conversao);
                                                        }

                                                    }
                                                    else
                                                    {
                                                        Console.Write(invalid_entrada);
                                                    }

                                                } while (continuar);

                                                do
                                                {
                                                    Console.Write(prosseguir);
                                                    ret = Console.ReadLine();

                                                    if (ret == "P" || ret == "p") { thir_code = "R"; }
                                                    if (ret == "S" || ret == "s") { Environment.Exit(0); }
                                                    if ((ret != "P" && ret != "p") && (ret != "S" && ret != "s")) { Console.Write(erro); }

                                                } while ((ret != "P" && ret != "p") && (ret != "S" && ret != "s"));

                                            break;
                                            case "2":

                                                Console.Clear();
                                                do
                                                {
                                                    Console.Write("\n\n          _______________________________________" +
                                                                    "\n         |                                       |" +
                                                                    "\n         |  Conversão de BRL Real para EUR Euro  |" +
                                                                    "\n         |_______________________________________|\n");

                                                    Console.Write("\nInforme o valor em Reais a ser convertido em Euros: ");
                                                    input_var_s = (Console.ReadLine());

                                                    sucesso = (double.TryParse(input_var_s, out input_var));

                                                    if (sucesso)
                                                    {

                                                        if (input_var < 0) { Console.Write(invalid_entrada); continuar = true; }
                                                        else
                                                        {
                                                            continuar = false;
                                                            conversao = Math.Round(input_var / eur_compra,2);
                                                            Console.Write("\nA conversão de BRL {0} em euros é igual a: EUR {1} \n\n", input_var, conversao);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.Write(invalid_entrada);
                                                    }

                                                } while (continuar);

                                                do
                                                {
                                                    Console.Write(prosseguir);
                                                    ret = Console.ReadLine();

                                                    if (ret == "P" || ret == "p") { thir_code = "R"; }
                                                    if (ret == "S" || ret == "s") { Environment.Exit(0); }
                                                    if ((ret != "P" && ret != "p") && (ret != "S" && ret != "s")) { Console.Write(erro); }

                                                } while ((ret != "P" && ret != "p") && (ret != "S" && ret != "s"));

                                            break;
                                            case "3":
                                                Console.Write(retorno, thir_code = "R");
                                                Console.ReadKey();
                                            break;
                                            case "4":
                                                Console.Write(ret_main_menu, main_code = "R");
                                                Console.ReadKey();
                                            break;
                                            case "S": case "s":
                                                Environment.Exit(0);
                                            break;
                                            default:
                                                Console.Write(erro);
                                                Console.ReadKey();
                                            break;
                                        }

                                    }while ((fiv_code != "1") && (fiv_code != "2") && (fiv_code != "3") &&
                                            (fiv_code != "4") && (fiv_code != "S" && fiv_code != "s"));
                                   
                                break;
                                case "C": case "c":
                                    Console.Write(retorno, main_code = "R");
                                    Console.ReadKey();
                                break;
                                default:
                                    Console.Write(erro);
                                    Console.ReadKey();
                                break;

                            }

                        }while ((thir_code != "A" && thir_code != "a") && (thir_code != "B" && thir_code != "b") &&
                                 (thir_code != "C" && thir_code != "c") && (thir_code != "S" && thir_code != "s"));

                    break;
                    //Conversor - Massa
                    case "3":

                        do
                        {
                            Console.Clear();
                            //apresentação aplicação - sub menu 7
                            Console.WriteLine("\n    ____________ |  Conversor de Massa   | ___________ ");
                            Console.WriteLine(  "   |                                                  |" +
                                              "\n   |   Conversões                   Cód de Entrada    |" +
                                              "\n   |                                                  |" +
                                              "\n   | Quilo x Gramas                         1         |" +
                                              "\n   | Grama x Quilo                          2         |" +
                                              "\n   |                                                  |" +
                                              "\n   | Retornar ao Menu Principal             3         |" +
                                              "\n   |                                                  |" +
                                              "\n   | Encerrar Aplicação                     S         |" +
                                              "\n   |__________________________________________________|");

                            Console.Write("\n    Selecione o código da opção desejada: ");
                            four_code = Console.ReadLine();                            

                            switch (four_code)
                            {
                                case "1":

                                    Console.Clear();
                                    do
                                    {

                                        Console.Write("\n\n          _______________________________________" +
                                                        "\n         |                                       |" +
                                                        "\n         |    Conversão de Quilo para Gramas     |" +
                                                        "\n         |_______________________________________|\n");

                                        Console.Write("\nInforme o valor em Quilos a ser convertido em Gramas: ");
                                        input_var_s = (Console.ReadLine());

                                        sucesso = (double.TryParse(input_var_s, out input_var));

                                        if (sucesso)
                                        {
                                            if (input_var < 0) { Console.Write(invalid_entrada); continuar = true; }

                                            else
                                            {
                                                continuar = false;
                                                conversao = input_var * 1000;
                                                Console.Write("\nA conversão de {0}kg em gramas é igual a: {1}g \n\n", input_var, conversao);
                                            }

                                        }
                                        else
                                        {
                                            Console.Write(invalid_entrada);
                                        }

                                    } while (continuar);

                                    do
                                    {
                                        Console.Write(prosseguir);
                                        ret = Console.ReadLine();

                                        if (ret == "P" || ret == "p") { four_code = "R"; }
                                        if (ret == "S" || ret == "s") { Environment.Exit(0); }
                                        if ((ret != "P" && ret != "p") && (ret != "S" && ret != "s")) { Console.Write(erro); }

                                    } while ((ret != "P" && ret != "p") && (ret != "S" && ret != "s"));

                                break;
                                case "2":

                                    Console.Clear();
                                    do
                                    {
                                        Console.Write("\n\n          _______________________________________" +
                                                        "\n         |                                       |" +
                                                        "\n         |    Conversão de Gramas para Quilos    |" +
                                                        "\n         |_______________________________________|\n");

                                        Console.Write("\nInforme o valor em Gramas a ser convertido em Quilos: ");
                                        input_var_s = (Console.ReadLine());

                                        sucesso = (double.TryParse(input_var_s, out input_var));

                                        if (sucesso)
                                        {

                                            if (input_var < 0) { Console.Write(invalid_entrada); continuar = true; }
                                            else
                                            {
                                                continuar = false;
                                                conversao = input_var * 0.001;
                                                Console.Write("\nA conversão de {0}g em quilos é igual a: {1}kg \n\n", input_var, conversao);
                                            }
                                        }
                                        else
                                        {
                                            Console.Write(invalid_entrada);
                                        }

                                    } while (continuar);

                                    do
                                    {
                                        Console.Write(prosseguir);
                                        ret = Console.ReadLine();

                                        if (ret == "P" || ret == "p") { four_code = "R"; }
                                        if (ret == "S" || ret == "s") { Environment.Exit(0); }
                                        if ((ret != "P" && ret != "p") && (ret != "S" && ret != "s")) { Console.Write(erro); }

                                    } while ((ret != "P" && ret != "p") && (ret != "S" && ret != "s"));

                                break;
                                case "3":
                                    Console.Write(retorno, main_code = "R");
                                    Console.ReadKey();
                                break;
                                case "S": case "s":
                                    Environment.Exit(0);
                                break;
                                default:
                                    Console.Write(erro);
                                    Console.ReadKey();
                                break;

                            }

                        }while ((four_code != "1" && four_code != "2" && four_code != "3" && (four_code != "S" && four_code != "s")));

                    break;
                    //Sair da aplicação
                    case "4":
                        Environment.Exit(0);
                    break;
                    //Se a entrada for inválida
                    default:
                        Console.WriteLine(erro);
                        Console.ReadKey();
                    break;

                }

            //Se a entrada for inválida                    
            } while (main_code != "1" && main_code != "2" && main_code != "3" && main_code != "4");
            Console.ReadKey();
        }
    }
}
