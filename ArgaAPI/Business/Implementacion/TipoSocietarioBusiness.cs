﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArgaAPI.Business.Contrato;
using ArgaAPI.DTOs;
using ArgaAPI.Models;
using ArgaAPI.Repositorio.Contrato;

namespace ArgaAPI.Business.Implementacion
{
    public class TipoSocietarioBusiness : ITipoSocietarioBusiness
    {
        private readonly ITipoSocietarioReposity _tipoSocietarioRepository;
      

         public TipoSocietarioBusiness(ITipoSocietarioReposity tipoSocietarioRepository){

             _tipoSocietarioRepository = tipoSocietarioRepository;
     
         }

         
      

        public ResponseDTO<IEnumerable<TipoSocietario>> GetTiposSocietarios()
        {
            var TiposSocietarios = _tipoSocietarioRepository.GetTiposSocietarios();

            return TiposSocietarios;
        }


        
       public ResponseDTO<TipoSocietario> GetTipoSocietarioPorCodigo(string codigo)
       {
          var TiposSocietario = _tipoSocietarioRepository.GetTipoSocietarioPorCodigo(codigo);

              return TiposSocietario;
       }



       #region Miembros de ITipoSocietarioBusiness


       public ResponseDTO<IEnumerable<TipoSocietario>> GetTipoSocietarioPorTipo(string tipo)
       {
           var TiposSocietario = _tipoSocietarioRepository.GetTipoSocietarioPorTipo(tipo);

           return TiposSocietario;
       }

       #endregion

       #region Miembros de ITipoSocietarioBusiness


     

       #endregion

       #region Miembros de ITipoSocietarioBusiness


       public ResponseDTO<IEnumerable<TipoSocietario>> GetTiposSocietariosCodigosSinCeroALaIzq()
       {
           var TiposSocietario = _tipoSocietarioRepository.GetTiposSocietariosCodigosSinCeroALaIzq();

           return TiposSocietario;
       }

       #endregion
    }
}