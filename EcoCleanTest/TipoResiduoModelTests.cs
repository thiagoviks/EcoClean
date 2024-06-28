using EcoClean.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EcoCleanTest
{
    public class TipoResiduoModelTests
    {
     
        [Fact]
        public void TipoResiduoModel_PropertiesInitializedCorrectly()
        {
            // Arrange
            var tipoResiduo = new TipoResiduoModel();

            // Act - Nenhuma ação necessária, pois as propriedades são inicializadas automaticamente

            // Assert
            Assert.Equal(0, tipoResiduo.Id); // Verifica se Id é inicializado como 0 (valor padrão para long)
            Assert.Null(tipoResiduo.Nome); // Verifica se Nome é inicializado como null
            Assert.Null(tipoResiduo.Descricao); // Verifica se Descricao é inicializado como null
            Assert.Null(tipoResiduo.CreatedAt); // Verifica se CreatedAt é inicializado como null
            Assert.Null(tipoResiduo.UpdatedAt); // Verifica se UpdatedAt é inicializado como null
        }

        [Fact]
        public void TipoResiduoModel_SetDates()
        {
            // Arrange
            var tipoResiduo = new TipoResiduoModel();
            var createdAt = new DateTime(2024, 6, 27, 10, 0, 0);
            var updatedAt = new DateTime(2024, 6, 27, 11, 0, 0);

            // Act
            tipoResiduo.CreatedAt = createdAt;
            tipoResiduo.UpdatedAt = updatedAt;

            // Assert
            Assert.Equal(createdAt, tipoResiduo.CreatedAt);
            Assert.Equal(updatedAt, tipoResiduo.UpdatedAt);
        }


    }
}
