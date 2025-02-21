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
           
        }

        Console.WriteLine($"Anos decorridos: {anos}");
    }
}
