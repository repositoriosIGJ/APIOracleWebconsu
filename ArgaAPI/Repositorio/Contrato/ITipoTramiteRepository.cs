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
    public interface ITipoTramiteRepository
    {

        ResponseDTO<IEnumerable<TipoTramite>> GetTiposTramites();
        ResponseDTO<TipoTramite> GetTramitesbyCodigoTramite(string codigo);
    }
}
