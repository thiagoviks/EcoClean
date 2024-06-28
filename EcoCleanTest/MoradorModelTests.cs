using EcoClean.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EcoCleanTest
{
    public class MoradorModelTests
    {

        [Fact]
        public void MoradorModel_PropertiesInitializedCorrectly()
        {
            // Arrange
            var morador = new MoradorModel();

            // Act - Nenhuma ação necessária, pois as propriedades são inicializadas automaticamente

            // Assert
            Assert.Equal(0, morador.Id); // Verifica se Id é inicializado como 0 (valor padrão para long)
            Assert.Null(morador.Nome); // Verifica se Nome é inicializado como null
            Assert.Null(morador.Email); // Verifica se Email é inicializado como null
            Assert.Equal(0, morador.EnderecoId); // Verifica se EnderecoId é inicializado como 0 (valor padrão para long)
            Assert.Null(morador.Endereco); // Verifica se Endereco é inicializado como null
            Assert.Null(morador.CreatedAt); // Verifica se CreatedAt é inicializado como null
            Assert.Null(morador.UpdatedAt); // Verifica se UpdatedAt é inicializado como null
        }

        [Fact]
        public void MoradorModel_RelationshipWithEndereco()
        {
            // Arrange
            var endereco = new EnderecoModel { Id = 1 }; // Exemplo de EnderecoModel

            // Act
            var morador = new MoradorModel
            {
                EnderecoId = endereco.Id,
                Endereco = endereco
            };

            // Assert
            Assert.Equal(endereco.Id, morador.EnderecoId); // Verifica se EnderecoId foi atribuído corretamente
            Assert.Same(endereco, morador.Endereco); // Verifica se a referência para Endereco é a mesma
        }

    }
}
