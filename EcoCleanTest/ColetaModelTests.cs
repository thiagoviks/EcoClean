using EcoClean.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EcoCleanTest
{
    public  class ColetaModelTests
    {


        [Fact]
        public void ColetaModel_PropertiesInitializedCorrectly()
        {
            // Arrange
            var coleta = new ColetaModel();

            // Act - Nenhuma ação necessária, pois as propriedades são inicializadas automaticamente

            // Assert
            Assert.Equal(0, coleta.Id); // Verifica se Id é inicializado como 0 (valor padrão para long)
            Assert.Equal(0, coleta.RotaId); // Verifica se RotaId é inicializado como 0 (valor padrão para long)
            Assert.Null(coleta.Rota); // Verifica se Rota é inicializado como null
            Assert.Equal(0, coleta.CaminhaoId); // Verifica se CaminhaoId é inicializado como 0 (valor padrão para long)
            Assert.Null(coleta.Caminhao); // Verifica se Caminhao é inicializado como null
            Assert.Equal(0, coleta.EnderecoId); // Verifica se EnderecoId é inicializado como 0 (valor padrão para long)
            Assert.Null(coleta.Endereco); // Verifica se Endereco é inicializado como null
            Assert.Null(coleta.PrevisaoHorario); // Verifica se PrevisaoHorario é inicializado como null
            Assert.Null(coleta.CreatedAt); // Verifica se CreatedAt é inicializado como null
            Assert.Null(coleta.UpdatedAt); // Verifica se UpdatedAt é inicializado como null
        }

        [Fact]
        public void ColetaModel_Relationships()
        {
            // Arrange
            var coleta = new ColetaModel();
            var rota = new RotaModel();
            var caminhao = new CaminhaoModel();
            var endereco = new EnderecoModel();
            var coletaTipoResiduo = new List<ColetaTipoResiduoModel>();

            // Act
            coleta.Rota = rota;
            coleta.Caminhao = caminhao;
            coleta.Endereco = endereco;
            coleta.ColetaTipoResiduo = coletaTipoResiduo;

            // Assert
            Assert.Same(rota, coleta.Rota); // Verifica se o objeto Rota atribuído é o mesmo
            Assert.Same(caminhao, coleta.Caminhao); // Verifica se o objeto Caminhao atribuído é o mesmo
            Assert.Same(endereco, coleta.Endereco); // Verifica se o objeto Endereco atribuído é o mesmo
            Assert.Same(coletaTipoResiduo, coleta.ColetaTipoResiduo); // Verifica se a lista ColetaTipoResiduo atribuída é a mesma
        }

    }
}
