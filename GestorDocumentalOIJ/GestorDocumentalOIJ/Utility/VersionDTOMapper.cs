﻿using GestorDocumentalOIJ.BC.Modelos;
using GestorDocumentalOIJ.DTOs;
using System;

namespace GestorDocumentalOIJ.Utility
{
    public static class VersionDTOMapper
    {

        public static VersionDTO ConvertirVersionADTO(BC.Modelos.Version version)
        {
            return new VersionDTO()
            {
                Id = version.Id,
                DocumentoID = version.DocumentoID,
                NumeroVersion = version.NumeroVersion,
                FechaCreacion = version.FechaCreacion,
                eliminado = version.eliminado,
                usuarioID = version.usuarioID,
                DocDinamico = version.DocDinamico,
                Obsoleto = version.Obsoleto,
                NumeroSCD = version.NumeroSCD,
                justificacion = version.justificacion,
                archivo = SaveFiles.GetIFormFile(version.urlVersion),
                UsuarioLogID = version.UsuarioLogID,
                OficinaID = version.OficinaID,
                urlVersion = version.urlVersion
            };
        }

        public static BC.Modelos.Version ConvertirDTOAVersion(VersionDTO versionDTO, string rutaArchivo)
        {
            return new BC.Modelos.Version()
            {
                Id = versionDTO.Id,
                DocumentoID = versionDTO.DocumentoID,
                NumeroVersion = versionDTO.NumeroVersion,
                FechaCreacion = versionDTO.FechaCreacion,
                urlVersion = rutaArchivo,
                eliminado = versionDTO.eliminado,
                usuarioID = versionDTO.usuarioID,
                DocDinamico = versionDTO.DocDinamico,
                Obsoleto = versionDTO.Obsoleto,
                NumeroSCD = versionDTO.NumeroSCD,
                justificacion = versionDTO.justificacion,
                UsuarioLogID = versionDTO.UsuarioLogID,
                OficinaID = versionDTO.OficinaID
            };
        }

        public static IEnumerable<VersionDTO> ConvertirListaDeVersionesADTO(IEnumerable<BC.Modelos.Version> versiones)
        {
            return versiones.Select(v => new VersionDTO()
            {
                Id = v.Id,
                DocumentoID = v.DocumentoID,
                NumeroVersion = v.NumeroVersion,
                FechaCreacion = v.FechaCreacion,
                eliminado = v.eliminado,
                usuarioID = v.usuarioID,
                DocDinamico = v.DocDinamico,
                Obsoleto = v.Obsoleto,
                NumeroSCD = v.NumeroSCD,
                justificacion = v.justificacion,
                archivo = SaveFiles.GetIFormFile(v.urlVersion),
                UsuarioLogID = v.UsuarioLogID,
                OficinaID = v.OficinaID,
                urlVersion = v.urlVersion

            });
        }
    }
}
