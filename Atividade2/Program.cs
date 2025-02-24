using System;

class Program
{
    static void Main()
    {
        // prefeitura
        double caixaPrefeitura = 0;
        const int empregadosPrefeitura = 125;
        const int beneficiariosSociais = 55;
        const double salarioPrefeitura = 20000;
        const double bolsaSocial = 1000;

        // comercio
        double caixaComercio = 10000000;
        const int empregadosComercio = 200;
        const double salarioComercio = 7500;
        const double precoVendaComercio = 203.00;

        // industria
        double caixaIndustria = 50000000;
        const int empregadosIndustria = 675;
        const double salarioIndustria = 10000;
        const double custoProducaoIndustria = 42.75;
        const double precoVendaIndustria = 75.00;

        //impostos
        const double impostoSalarioEmpregador = 0.61;
        const double impostoSalarioTrabalhador = 0.25;
        const double impostoVendaComercio = 0.38;
        const double impostoVendaIndustria = 0.18;

        int anos = 0;
        bool loop = true;

        while (loop)
        {
            anos++;
            double impostosIndustria = 0, impostosComercio = 0, impostosPopulacao = 0;

            // Pagamento de salários e recolhimento de impostos
            double folhaSalarialPrefeitura = empregadosPrefeitura * salarioPrefeitura;
            double folhaSalarialComercio = empregadosComercio * salarioComercio;
            double folhaSalarialIndustria = empregadosIndustria * salarioIndustria;

            double totalSalarios = folhaSalarialPrefeitura + folhaSalarialComercio + folhaSalarialIndustria;

            double impostoEmpregadores = (folhaSalarialComercio + folhaSalarialIndustria) * impostoSalarioEmpregador;
            double impostoTrabalhadores = totalSalarios * impostoSalarioTrabalhador;
            double impostoTotalSalarios = impostoEmpregadores + impostoTrabalhadores;
            impostosPopulacao += impostoTrabalhadores;

            caixaPrefeitura += impostoTotalSalarios;
            caixaComercio -= folhaSalarialComercio;
            caixaIndustria -= folhaSalarialIndustria;

            // Pagamento de bolsa social
            double custoBolsaSocial = beneficiariosSociais * bolsaSocial;
            caixaPrefeitura -= custoBolsaSocial;

            // Consumo no comércio
            double dinheiroGasto = totalSalarios - impostoTrabalhadores + custoBolsaSocial;
            int itensComprados = (int)(dinheiroGasto / precoVendaComercio);

            double receitaComercio = itensComprados * precoVendaComercio;
            double impostoVendasComercio = receitaComercio * impostoVendaComercio;
            impostosComercio += impostoVendasComercio;
            caixaPrefeitura += impostoVendasComercio;

            caixaComercio += receitaComercio - impostoVendasComercio;

            // Reposição de estoque
            int estoqueReposto = itensComprados;
            double custoReposicao = estoqueReposto * precoVendaIndustria;
            if (caixaComercio < custoReposicao)
            {
                Console.WriteLine("O comércio não tem capital suficiente.");
                break;
            }

            caixaComercio -= custoReposicao;
            caixaIndustria += custoReposicao;

            // Indústria produz os itens
            double custoProducaoTotal = estoqueReposto * custoProducaoIndustria;
            if (caixaIndustria < custoProducaoTotal)
            {
                Console.WriteLine("A indústria não tem capital suficiente.");
                break;
            }

            caixaIndustria -= custoProducaoTotal;
            double impostoVendasIndustria = custoReposicao * impostoVendaIndustria;
            impostosIndustria += impostoVendasIndustria;
            caixaPrefeitura += impostoVendasIndustria;

            // Exibir relatório anual
            Console.WriteLine("Ano " + anos);
            Console.WriteLine($"Prefeitura: R$ {caixaPrefeitura:F2}");
            Console.WriteLine($"Comércio: R$ {caixaComercio:F2}");
            Console.WriteLine($"Indústria: R$ {caixaIndustria:F2}");
            Console.WriteLine($"Impostos da Indústria: R$ {impostosIndustria:F2}");
            Console.WriteLine($"Impostos da Comércio: R$ {impostosComercio:F2}");
            Console.WriteLine($"Impostos da População: R$ {impostosPopulacao:F2}");
            Console.WriteLine("-------------------------------------");
        }

        Console.WriteLine("Anos: "+anos);
    }
}
