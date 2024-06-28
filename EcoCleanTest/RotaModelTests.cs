using EcoClean.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EcoCleanTest
{
    public class RotaModelTests
    {

        [Fact]
        public void RotaModel_PropertiesInitializedCorrectly()
        {
            // Arrange
            var rota = new RotaModel();

            // Act - Nenhuma ação necessária, pois as propriedades são inicializadas automaticamente

            // Assert
            Assert.Equal(0, rota.Id); // Verifica se Id é inicializado como 0 (valor padrão para long)
            Assert.Null(rota.Nome); // Verifica se Nome é inicializado como null
            Assert.Null(rota.CreatedAt); // Verifica se CreatedAt é inicializado como null
            Assert.Null(rota.UpdatedAt); // Verifica se UpdatedAt é inicializado como null
        }

        [Fact]
        public void RotaModel_SetDates()
        {
            // Arrange
            var rota = new RotaModel();
            var createdAt = new DateTime(2024, 6, 27, 10, 0, 0);
            var updatedAt = new DateTime(2024, 6, 27, 11, 0, 0);

            // Act
            rota.CreatedAt = createdAt;
            rota.UpdatedAt = updatedAt;

            // Assert
            Assert.Equal(createdAt, rota.CreatedAt);
            Assert.Equal(updatedAt, rota.UpdatedAt);
        }

    }
}
