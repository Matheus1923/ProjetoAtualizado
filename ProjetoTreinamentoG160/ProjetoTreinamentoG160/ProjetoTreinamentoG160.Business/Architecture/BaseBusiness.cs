using SGI.Common.BusinessSimple;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTreinamentoG160.Business.Architecture
{
    public abstract class BaseBusiness : BaseBusinessGeneric
    {
        public BaseBusiness()
        {
        }

        public ReadOnlyCollection<String> Erros
        {
            get
            {
                List<String> retorno = new List<string>();
                foreach (var item in this.RegrasQuebradasCodigo)
                {
                    if (!String.IsNullOrEmpty(item.Key.ToString()))
                    {
                        String mensagem = String.Empty;

                        if (!String.IsNullOrEmpty(item.Value))
                        {
                            mensagem += !String.IsNullOrEmpty(mensagem) ? " - " : String.Empty;
                            mensagem += item.Value;
                        }

                        retorno.Add(mensagem);
                    }
                    else
                    {
                        retorno.Add(item.Value);
                    }
                }
                return retorno.AsReadOnly();
            }
        }

        /// <summary>
        /// Valida as regras de negócio da instância Antes da Inclusão.
        /// </summary>
        /// <param name="instancia">A instância criada.</param>
        /// <returns></returns>
        public abstract void ExecutaInclusaoAntes();

        /// <summary>
        /// Valida as regras de negócio da instância Depois da Inclusão.
        /// </summary>
        /// <param name="instancia">A instância criada.</param>
        /// <returns></returns>
        public abstract void ExecutaInclusaoDepois();

        /// <summary>
        /// Valida as regras de negócio da instância Antes da Alteração.
        /// </summary>
        /// <param name="instancia">A instância criada.</param>
        /// <returns></returns>
        public abstract void ExecutaAlteracaoAntes();

        /// <summary>
        /// Valida as regras de negócio da instância Depois da Alteração.
        /// </summary>
        /// <param name="instancia">A instância criada.</param>
        /// <returns></returns>
        public abstract void ExecutaAlteracaoDepois();

        /// <summary>
        /// Valida as regras de negócio da instância Antes da Exclusão.
        /// </summary>
        /// <param name="instancia">A instância criada.</param>
        /// <returns></returns>
        public abstract void ExecutaExclusaoAntes();

        /// <summary>
        /// Valida as regras de negócio da instância Depois da Exclusão
        /// </summary>
        /// <param name="instancia">A instância criada.</param>
        /// <returns></returns>
        public abstract void ExecutaExclusaoDepois();
    }
}
