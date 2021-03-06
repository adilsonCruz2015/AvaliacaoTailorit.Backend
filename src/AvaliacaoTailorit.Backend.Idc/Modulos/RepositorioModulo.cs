﻿using AvaliacaoTailorit.BackEnd.Cadastro.Dominio.Interfaces.Repositorio;
using AvaliacaoTailorit.BackEnd.Data.Persistencia.Repositorios;
using SimpleInjector;

namespace AvaliacaoTailorit.Backend.Idc.Modulos
{
    public static class RepositorioModulo
    {
        public static void Carregar(Container recipiente) 
        {
            recipiente.Register<IUsuarioRep, UsuarioRep>(Lifestyle.Scoped);
            recipiente.Register<ISexoRep, SexoRep>(Lifestyle.Scoped);
        }
    }
}
