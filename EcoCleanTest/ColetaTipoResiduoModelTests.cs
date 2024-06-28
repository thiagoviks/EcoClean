using EcoClean.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoCleanTest
{
    public class ColetaTipoResiduoModelTests
    {
        [Fact]
        public void ColetaTipoResiduoModel_PropertiesInitializedCorrectly()
        {
            // Arrange
            var coletaTipoResiduo = new ColetaTipoResiduoModel();

            // Act - Nenhuma ação necessária, pois as propriedades são inicializadas automaticamente

            // Assert
            Assert.Equal(0, coletaTipoResiduo.ColetaId); // Verifica se ColetaId é inicializado como 0 (valor padrão para long)
            Assert.Null(coletaTipoResiduo.Coleta); // Verifica se Coleta é inicializado como null
            Assert.Equal(0, coletaTipoResiduo.TipoResiduoId); // Verifica se TipoResiduoId é inicializado como 0 (valor padrão para long)
            Assert.Null(coletaTipoResiduo.TipoResiduo); // Verifica se TipoResiduo é inicializado como null
        }

        [Fact]
        public void ColetaTipoResiduoModel_Relationships()
        {
            // Arrange
            var coleta = new ColetaModel { Id = 1 }; // Exemplo de ColetaModel
            var tipoResiduo = new TipoResiduoModel { Id = 1 }; // Exemplo de TipoResiduoModel

            // Act
            var coletaTipoResiduo = new ColetaTipoResiduoModel
            {
                ColetaId = coleta.Id,
                Coleta = coleta,
                TipoResiduoId = tipoResiduo.Id,
                TipoResiduo = tipoResiduo
            };

            // Assert
            Assert.Equal(coleta.Id, coletaTipoResiduo.ColetaId); // Verifica se ColetaId foi atribuído corretamente
            Assert.Same(coleta, coletaTipoResiduo.Coleta); // Verifica se a referência para Coleta é a mesma
            Assert.Equal(tipoResiduo.Id, coletaTipoResiduo.TipoResiduoId); // Verifica se TipoResiduoId foi atribuído corretamente
            Assert.Same(tipoResiduo, coletaTipoResiduo.TipoResiduo); // Verifica se a referência para TipoResiduo é a mesma
        }
    }
}
