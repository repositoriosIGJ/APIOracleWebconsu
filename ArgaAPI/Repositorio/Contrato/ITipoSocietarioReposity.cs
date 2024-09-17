﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArgaAPI.Data;
using ArgaAPI.DTOs;
using ArgaAPI.Models;

namespace ArgaAPI.Repositorio.Contrato
{
    public interface ITipoSocietarioReposity
    {
       
        ResponseDTO<IEnumerable<TipoSocietario>> GetTiposSocietarios();
         ResponseDTO<IEnumerable<TipoSocietario>> GetTiposSocietariosCodigosSinCeroALaIzq();
         ResponseDTO<TipoSocietario> GetTipoSocietarioPorCodigo(string codigo);
         ResponseDTO<IEnumerable<TipoSocietario>> GetTipoSocietarioPorTipo(string tipo);
       
    }
}
