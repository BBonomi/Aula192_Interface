namespace Aula192_solucaoSemInterface.Services
{
    internal class BrazilTaxService
    {
        public double Tax(double ammount) //metodo cobrança de imposto Brasil
        {
            if (ammount <= 100.0) // menor ou igual a 100.00 cobra 20%
            {
                return ammount * 0.2;
            }
            else
            {
                return ammount * 0.15; //maior que 100.00 cobra 15%
            }
        }
    }
}