using EcoClean.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EcoCleanTest
{
    public class EnderecoModelTests
    {
       
        [Fact]
        public void EnderecoModel_PropertiesInitializedCorrectly()
        {
            // Arrange
            var endereco = new EnderecoModel();

            // Act - Nenhuma ação necessária, pois as propriedades são inicializadas automaticamente

            // Assert
            Assert.Equal(0, endereco.Id); // Verifica se Id é inicializado como 0 (valor padrão para long)
            Assert.Null(endereco.Cep); // Verifica se Cep é inicializado como null
            Assert.Null(endereco.Rua); // Verifica se Rua é inicializado como null
            Assert.Null(endereco.Bairro); // Verifica se Bairro é inicializado como null
            Assert.Equal(0, endereco.Numero); // Verifica se Numero é inicializado como 0 (valor padrão para int)
            Assert.Null(endereco.Complemento); // Verifica se Complemento é inicializado como null
            Assert.Null(endereco.Cidade); // Verifica se Cidade é inicializado como null
            Assert.Null(endereco.Estado); // Verifica se Estado é inicializado como null
            Assert.Null(endereco.CreatedAt); // Verifica se CreatedAt é inicializado como null
            Assert.Null(endereco.UpdatedAt); // Verifica se UpdatedAt é inicializado como null
        }

        [Fact]
        public void EnderecoModel_SetProperties()
        {
            // Arrange
            var endereco = new EnderecoModel();
            var cep = "12345-678";
            var rua = "Rua Teste";
            var bairro = "Bairro Teste";
            var numero = 123;
            var complemento = "Complemento Teste";
            var cidade = "Cidade Teste";
            var estado = "Estado Teste";
            var createdAt = new DateTime(2024, 6, 27, 10, 0, 0);
            var updatedAt = new DateTime(2024, 6, 27, 11, 0, 0);

            // Act
            endereco.Cep = cep;
            endereco.Rua = rua;
            endereco.Bairro = bairro;
            endereco.Numero = numero;
            endereco.Complemento = complemento;
            endereco.Cidade = cidade;
            endereco.Estado = estado;
            endereco.CreatedAt = createdAt;
            endereco.UpdatedAt = updatedAt;

            // Assert
            Assert.Equal(cep, endereco.Cep);
            Assert.Equal(rua, endereco.Rua);
            Assert.Equal(bairro, endereco.Bairro);
            Assert.Equal(numero, endereco.Numero);
            Assert.Equal(complemento, endereco.Complemento);
            Assert.Equal(cidade, endereco.Cidade);
            Assert.Equal(estado, endereco.Estado);
            Assert.Equal(createdAt, endereco.CreatedAt);
            Assert.Equal(updatedAt, endereco.UpdatedAt);
        }

    }
}
