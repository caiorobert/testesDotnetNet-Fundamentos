using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTeste : IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste { get; }

        public VeiculoTeste(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Execução do  construtor.");
            veiculo = new Veiculo();
            veiculo.Tipo = TipoVeiculo.Automovel;
        }

        [Fact]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerarComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();
            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrearComParametro10()
        {
            //Arrange
            //var veiculo = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaTipoVeiculo()
        {
            //Arrange
            //var veiculo = new Veiculo();
            //Act
            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact(DisplayName = "ValidaNomeProprietarioDoVeiculo", Skip = "Teste ainda não implementado. Ignorar")]
        public void ValidaNomeProprietario()
        {

        }

        [Theory]
        [ClassData(typeof(Veiculo))]
        public void TestaVeiculoClass(Veiculo modelo)
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);
            modelo.Acelerar(10);

            //Assert
            Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void FichaDeInformacaoDoVeiculo()
        {
            //Arrange
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Davi Souza";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "ZAP-2010";
            veiculo.Cor = "Azul";
            veiculo.Modelo = "Fusca";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Veículo:", dados);
        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            //Arrange
            string nomeProprietario = "Ab";

            //Assert
            Assert.Throws<System.FormatException>(
               //Act
               () => new Veiculo(nomeProprietario)
            );
        }

        [Fact]
        public void TestaMensagemDeExecucaoDoQuartoCaractereDaPlaca()
        {
            //Arrange
            string placa = "PHGA6604";

            //Act
            var mensagem = Assert.Throws<System.FormatException>(
                    () => new Veiculo().Placa = placa
                );

            //Assert
            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }

        [Fact]
        public void TestaUltimosCaracteresPlacaVeiculoComoNumeros()
        {
            //Arrange
            string placaFormatoErrado = "ASD-995U";

            //Assert
            Assert.Throws<FormatException>(
                //Act
                () => new Veiculo().Placa = placaFormatoErrado
            );
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Execução do Cleanup: Limpando os objetos.");
        }
    }
}
