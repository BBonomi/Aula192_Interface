using Aula192_solucaoSemInterface.Entities;
using System;

namespace Aula192_solucaoSemInterface.Services
{
    internal class RentalService
    {
        public double PricePerHour { get; private set; } //atributo
        public double PricePerDay { get; private set; } //atributo

        private BrazilTaxService _brazilTaxService = new BrazilTaxService(); //não é a melhor forma de fazer (vinculando a classe BrazilTaxService)

        public RentalService(double pricePerHour, double pricePerDay)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
        }

        public void ProcessInvoice(CarRental carRental) //metodo
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);

            double basicPayment = 0.0;
            if (duration.TotalHours <= 12.0)
            {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours); //Math.Celling função que arredonda para cima as horas ex. 2.5 vai para 3
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }
            double tax = _brazilTaxService.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}