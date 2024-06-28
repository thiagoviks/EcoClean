using EcoClean.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoCleanTest
{
    public class NotificacaoModelTests
    {

    
        [Fact]
        public void NotificacaoModel_PropertiesInitializedCorrectly()
        {
            // Arrange
            var notificacao = new NotificacaoModel();

            // Act - Nenhuma ação necessária, pois as propriedades são inicializadas automaticamente

            // Assert
            Assert.Equal(0, notificacao.Id); // Verifica se Id é inicializado como 0 (valor padrão para long)
            Assert.Null(notificacao.Destinatario); // Verifica se Destinatario é inicializado como null
            Assert.Null(notificacao.Assunto); // Verifica se Assunto é inicializado como null
            Assert.Null(notificacao.Mensagem); // Verifica se Mensagem é inicializado como null
            Assert.Null(notificacao.DataEnvio); // Verifica se DataEnvio é inicializado como null
        }

        [Fact]
        public void NotificacaoModel_SetDataEnvio()
        {
            // Arrange
            var notificacao = new NotificacaoModel();
            var dataEnvio = new DateTime(2024, 6, 27, 10, 0, 0);

            // Act
            notificacao.DataEnvio = dataEnvio;

            // Assert
            Assert.Equal(dataEnvio, notificacao.DataEnvio);
        }

    }
}
