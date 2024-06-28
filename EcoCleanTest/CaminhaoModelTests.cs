using EcoClean.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EcoCleanTest
{
    public class CaminhaoModelTests
    {

        [Fact]
        public void CaminhaoModel_PropertiesInitializedCorrectly()
        {
            // Arrange
            var caminhao = new CaminhaoModel();

            // Act - Nenhuma ação necessária, pois as propriedades são inicializadas automaticamente

            // Assert
            Assert.Equal(0, caminhao.Id); // Verifica se Id é inicializado como 0 (valor padrão para long)
            Assert.Null(caminhao.Placa); // Verifica se Placa é inicializado como null
            Assert.Null(caminhao.CoordenadaX); // Verifica se CoordenadaX é inicializado como null
            Assert.Null(caminhao.CoordenadaY); // Verifica se CoordenadaY é inicializado como null
            Assert.Null(caminhao.CreatedAt); // Verifica se CreatedAt é inicializado como null
            Assert.Null(caminhao.UpdatedAt); // Verifica se UpdatedAt é inicializado como null
        }

        [Fact]
        public void CaminhaoModel_SetProperties()
        {
            // Arrange
            var caminhao = new CaminhaoModel();
            var placa = "ABC1234";
            var coordenadaX = "10.12345";
            var coordenadaY = "20.54321";
            var createdAt = new DateTime(2024, 6, 27, 10, 0, 0);
            var updatedAt = new DateTime(2024, 6, 27, 11, 0, 0);

            // Act
            caminhao.Placa = placa;
            caminhao.CoordenadaX = coordenadaX;
            caminhao.CoordenadaY = coordenadaY;
            caminhao.CreatedAt = createdAt;
            caminhao.UpdatedAt = updatedAt;

            // Assert
            Assert.Equal(placa, caminhao.Placa);
            Assert.Equal(coordenadaX, caminhao.CoordenadaX);
            Assert.Equal(coordenadaY, caminhao.CoordenadaY);
            Assert.Equal(createdAt, caminhao.CreatedAt);
            Assert.Equal(updatedAt, caminhao.UpdatedAt);
        }


    }
}
