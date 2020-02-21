using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interface
{
    interface IFuncionarioRepository
    {
        List<FuncionarioDomain> Listar();

        FuncionarioDomain BuscarPorId (int id);

        void Cadastrar(FuncionarioDomain funcionario);

        void AtualizarId(FuncionarioDomain funcionario);

        void Deletar(int id);

    }
}
