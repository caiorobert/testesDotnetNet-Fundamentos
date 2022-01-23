using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {
        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Caio Robert";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Marrom";
            veiculo.Modelo = "HB20X";
            veiculo.Placa = "PHG-6604";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Caio Robert", "PHG-6604", "Marrom", "HB20X")]
        [InlineData("Gaby Souza", "GAB-2002", "Preto", "Celta")]
        [InlineData("Layanne Santos", "LAY-2022", "Vinho", "HRV")]
        public void validaFaturamentoComVariosVeiculos
        (
            string proprietario,
            string placa,
            string cor,
            string modelo
        )
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }
    }
}
